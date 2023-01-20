using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Optimasi_Produksi
{
    class ClassFungsiBaru
    {
        private ClassFungsiBaru() { }

        public struct TSolusiBaru
        {
            public int Indeks;
            public int Hasil;
        }

        public static int[] ArrSolusi, ArrSolusiBaru;
        public static int[,] ArrSolusiM, ArrSolusiBaruM;

        //Auto Number
        public static string GenerateAutoNumber(string pcIndeks, string pcField, string pcTable)
        {
            string cF, Hasil, cIndex;
            int nIndex;
            string connectionString = ClassVariabel.connectionString;
            cF = "Select MAX(" + pcField + ") From " + pcTable + " Where LEFT(" + pcField + ",2) = '" + pcIndeks + "'";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            nIndex = 0; Hasil = "";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cF, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    cIndex = reader[0].ToString();
                    nIndex = Convert.ToInt32(cIndex.Substring(3));
                    nIndex += 1;
                    Hasil = pcIndeks + "-" + nIndex.ToString("00000");
                }
                reader.Close();
            }
            catch
            {
                nIndex = 1;
                Hasil = pcIndeks + "-" + nIndex.ToString("00000");
            }
            connection.Close();
            return Hasil;

        }

        //-----------------------------------------
        // Algoritma Modified Simulated Annealing
        //-----------------------------------------

        public static int[,] AlokasiMesinAwal_Array(int pnJlhProduk, int pnJlhMesin, int pnN, int[,] pnData) //ambil Waktu sebagai data pengecekan
        {
            int[,] solusi = new int[pnN + 1, pnJlhProduk + 1];
            Random rnd = new Random();
            int w, nLoop, Indeks;
            bool bValid;
            string connectionString = ClassVariabel.connectionString;
            string strQuery;
            string TempLap = "";

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "--------------------------" + Environment.NewLine +
                                        " Inisialisasi Solusi Awal " + Environment.NewLine +
                                        "--------------------------" + Environment.NewLine;

            for (int loop = 0; loop <= pnN; loop++)
            {
                nLoop = 0;
                do
                {
                    if (ClassVariabel.bLaporan)
                        TempLap = "Alternatif-" + loop.ToString() + ":" + Environment.NewLine;
                    for (int t = 0; t <= pnJlhProduk; t++)
                    {
                        w = rnd.Next(0, pnJlhMesin + 1);
                        while (pnData[w, t] == 0)
                        {
                            w += 1;
                            if (w > pnJlhMesin) w = 0;
                        }
                        solusi[loop, t] = w;

                        if (ClassVariabel.bLaporan)
                            TempLap += "Alternatif-" + loop.ToString() + ":" + Environment.NewLine +
                                       "Produk " + (t + 1).ToString() + " (" + ClassVariabel.ArrProduk[t].Nama +
                                       ") diproduksi pada Mesin " + (w + 1).ToString() + " (" +
                                       ClassVariabel.ArrMesin[w].Nama + ")" + Environment.NewLine;
                    }

                    //Cek dulu apakah solusi memenuhi persyaratan atau tidak
                    //Jumlah waktu yang digunakan tidak melebihi waktu kerja + lembur
                    int TotalWaktu = 0;
                    for (int i = 0; i <= pnJlhProduk; i++)
                        TotalWaktu += ClassVariabel.ArrWaktu[solusi[loop, i], i];

                    bValid = (TotalWaktu <= (ClassVariabel.Ar + ClassVariabel.Ao));

                    //Jumlah bahan baku yang diperlukan mencukupi
                    for (int i = 0; i <= ClassVariabel.ArrBahanBaku.GetUpperBound(0); i++)
                        ClassVariabel.ArrBahanBaku[i].QtyPakai = 0;

                    for (int i = 0; i <= pnJlhProduk; i++)
                    {
                        //Hitung total bahan baku yang diperlukan untuk memproduksi produk yang bersangkutan
                        SqlConnection connection = new SqlConnection();
                        connection.ConnectionString = connectionString;

                        strQuery = "Select KodeBahan, Qty, QtyProduk " +
                                   "From Formulasi Where KodeProduk = '" + ClassVariabel.ArrProduk[i].Kode + "' Order By KodeBahan";
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(strQuery, connection);
                            command.CommandType = CommandType.Text;
                            command.ExecuteNonQuery();
                            SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                Indeks = GetIndex(Convert.ToString(reader[0]));
                                ClassVariabel.ArrBahanBaku[Indeks].QtyPakai += (Convert.ToInt32(reader[1]) / Convert.ToInt32(reader[2]));
                            }
                            reader.Close();
                        }
                        catch
                        {

                        }
                        connection.Close();
                    }

                    for (int i = 0; i <= ClassVariabel.ArrBahanBaku.GetUpperBound(0); i++)
                        bValid = bValid &&
                            (ClassVariabel.ArrBahanBaku[i].SaldoAwal + ClassVariabel.ArrBahanBaku[i].QtyTerima >=
                            ClassVariabel.ArrBahanBaku[i].QtyPakai);

                    nLoop += 1;

                } while ((!bValid) && (nLoop < 100));
            }

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += TempLap + Environment.NewLine;

            return solusi;
        }


        public static TSolusiBaru[] KemungkinanSolusiBerikutnya_Array(int[,] solusiSekarang, int pnN, int[,] pnData) //ambil Waktu sebagai data pengecekan
        {
            int jumlahMesin = pnData.GetUpperBound(0) + 1; //Mesin = Mesin (Baris)
            int jumlahProduk = pnData.GetUpperBound(1) + 1; //Produk = Produk (Kolom)
            TSolusiBaru[] solusi = new TSolusiBaru[pnN + 1];

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "------------------------" + Environment.NewLine +
                                        " Bangkitkan Solusi Baru " + Environment.NewLine +
                                        "------------------------" + Environment.NewLine;

            for (int loop = 0; loop <= pnN; loop++)
            {
                //Tentukan produk secara acak
                Random rnd = new Random();
                int produk = rnd.Next(0, jumlahProduk);
                int Mesin = rnd.Next(0, jumlahMesin);

                while (pnData[Mesin, produk] == 0)
                {
                    Mesin += 1;
                    if (Mesin > jumlahMesin - 1)
                        Mesin = 0;
                }
                solusi[loop].Indeks = produk;
                solusi[loop].Hasil = Mesin;

                //Cek dulu apakah solusi memenuhi persyaratan atau tidak
                //Jumlah waktu yang digunakan tidak melebihi waktu kerja + lembur
                //Jumlah bahan baku yang diperlukan mencukupi



                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += "Produk " + (produk + 1).ToString() + " (" + ClassVariabel.ArrProduk[produk].Nama +
                                            ") diproduksi pada Mesin " + (Mesin + 1).ToString() + " (" + ClassVariabel.ArrMesin[Mesin].Nama + ")" +
                                            Environment.NewLine;

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += Environment.NewLine;

            }

            return solusi;
        }

        public static ClassVariabel.TEnergi HitungNilaiF_Array(int pnIndeksAlternatif)
        {
            int i;
            double TotalWaktu, TotalBiaya;
            ClassVariabel.TEnergi Hasil;
            int[] JlhPekerjaan = new int[ClassVariabel.ArrProduk.GetUpperBound(0) + 1];

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "-------------------" + Environment.NewLine +
                                        " Hitung nilai f(x) " + Environment.NewLine +
                                        "-------------------" + Environment.NewLine;

            TotalWaktu = 0;
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "Total Waktu = ";
            for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
            {
                //Hitung total waktu yang diperlukan
                TotalWaktu += ClassVariabel.ArrWaktu[ArrSolusiM[pnIndeksAlternatif,i], i];

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += (i == 0 ? "" : " + ") + ClassVariabel.ArrWaktu[ArrSolusiM[pnIndeksAlternatif,i], i];

                JlhPekerjaan[ArrSolusiM[pnIndeksAlternatif,i]] += 1;
            }

            for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
            {
                if (JlhPekerjaan[i] > 0)
                {
                    TotalWaktu += (JlhPekerjaan[i] - 1) * ClassVariabel.LamaMesin;

                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += "Tambahkan waktu pembersihan mesin :" + Environment.NewLine +
                                                "Total Waktu = " + (JlhPekerjaan[i] - 1).ToString() + " * " +
                                                ClassVariabel.LamaMesin.ToString() + " = " + TotalWaktu.ToString() + Environment.NewLine;
                }
            }


            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine +
                                        "Total Waktu = " + TotalWaktu.ToString("#,##0") + Environment.NewLine + Environment.NewLine;

            TotalBiaya = 0;
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "Total Biaya = ";
            for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
            {
                //Hitung total biaya yang diperlukan
                TotalBiaya += ClassVariabel.ArrBiaya[ArrSolusiM[pnIndeksAlternatif,i], i];

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += (i == 0 ? "" : " + ") + ClassVariabel.ArrBiaya[ArrSolusiM[pnIndeksAlternatif,i], i];
            }
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine +
                                        "Total Biaya = " + TotalBiaya.ToString("#,##0") + Environment.NewLine + Environment.NewLine;

            Hasil.Z1 = TotalBiaya;
            Hasil.Z2 = TotalWaktu;

            return Hasil;
        }

        public static ClassVariabel.TEnergi HitungNilaiFi_Array(int pnIndeksAlternatif)
        {
            int i;
            double TotalWaktu, TotalBiaya;
            ClassVariabel.TEnergi Hasil;
            int[] JlhPekerjaan = new int[ClassVariabel.ArrProduk.GetUpperBound(0) + 1];

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "--------------------" + Environment.NewLine +
                                        " Hitung nilai f(x') " + Environment.NewLine +
                                        "--------------------" + Environment.NewLine;

            TotalWaktu = 0;
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "Total Waktu = ";
            for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
            {
                //Hitung total waktu yang diperlukan
                TotalWaktu += ClassVariabel.ArrWaktu[ArrSolusiBaruM[pnIndeksAlternatif, i], i];

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += (i == 0 ? "" : " + ") + ClassVariabel.ArrWaktu[ArrSolusiBaruM[pnIndeksAlternatif, i], i];

                JlhPekerjaan[ArrSolusiBaruM[pnIndeksAlternatif, i]] += 1;
            }

            for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
            {
                if (JlhPekerjaan[i] > 0)
                {
                    TotalWaktu += (JlhPekerjaan[i] - 1) * ClassVariabel.LamaMesin;

                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += "Tambahkan waktu pembersihan mesin :" + Environment.NewLine +
                                                "Total Waktu = " + (JlhPekerjaan[i] - 1).ToString() + " * " +
                                                ClassVariabel.LamaMesin.ToString() + " = " + TotalWaktu.ToString() + Environment.NewLine;
                }
            }


            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine +
                                        "Total Waktu = " + TotalWaktu.ToString("#,##0") + Environment.NewLine + Environment.NewLine;

            TotalBiaya = 0;
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "Total Biaya = ";
            for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
            {
                //Hitung total biaya yang diperlukan
                TotalBiaya += ClassVariabel.ArrBiaya[ArrSolusiBaruM[pnIndeksAlternatif, i], i];

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += (i == 0 ? "" : " + ") + ClassVariabel.ArrBiaya[ArrSolusiBaruM[pnIndeksAlternatif, i], i];
            }
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine +
                                        "Total Biaya = " + TotalBiaya.ToString("#,##0") + Environment.NewLine + Environment.NewLine;

            Hasil.Z1 = TotalBiaya;
            Hasil.Z2 = TotalWaktu;

            return Hasil;
        }


        //--------------------------------
        // Algoritma Simulated Annealing
        //--------------------------------

        public static int[] AlokasiMesinAwal(int pnJlhProduk, int pnJlhMesin, int[,] pnData) //ambil Waktu sebagai data pengecekan
        {
            int[] solusi = new int[pnJlhProduk + 1];
            Random rnd = new Random();
            int w, nLoop, Indeks;
            bool bValid;
            string connectionString = ClassVariabel.connectionString;
            string strQuery;
            string TempLap = "";

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "--------------------------" + Environment.NewLine +
                                        " Inisialisasi Solusi Awal " + Environment.NewLine +
                                        "--------------------------" + Environment.NewLine;

            nLoop = 0;
            do
            {
                TempLap = "";
                for (int t = 0; t <= pnJlhProduk; t++)
                {
                    w = rnd.Next(0, pnJlhMesin + 1);
                    while (pnData[w, t] == 0)
                    {
                        w += 1;
                        if (w > pnJlhMesin) w = 0;
                    }
                    solusi[t] = w;

                    if (ClassVariabel.bLaporan)
                        TempLap += "Produk " + (t + 1).ToString() + " (" + ClassVariabel.ArrProduk[t].Nama +
                                   ") diproduksi pada Mesin " + (w + 1).ToString() + " (" + ClassVariabel.ArrMesin[w].Nama + ")" +
                                   Environment.NewLine;
                }

                //Cek dulu apakah solusi memenuhi persyaratan atau tidak
                //Jumlah waktu yang digunakan tidak melebihi waktu kerja + lembur
                int TotalWaktu = 0;
                for (int i = 0; i <= pnJlhProduk; i++)
                    TotalWaktu += ClassVariabel.ArrWaktu[solusi[i], i];

                bValid = (TotalWaktu <= (ClassVariabel.Ar + ClassVariabel.Ao));

                //Jumlah bahan baku yang diperlukan mencukupi
                for (int i = 0; i <= ClassVariabel.ArrBahanBaku.GetUpperBound(0); i++)
                    ClassVariabel.ArrBahanBaku[i].QtyPakai = 0;

                for (int i = 0; i <= pnJlhProduk; i++)
                {
                    //Hitung total bahan baku yang diperlukan untuk memproduksi produk yang bersangkutan
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = connectionString;

                    strQuery = "Select KodeBahan, Qty, QtyProduk " +
                               "From Formulasi Where KodeProduk = '" + ClassVariabel.ArrProduk[i].Kode + "' Order By KodeBahan";
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(strQuery, connection);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Indeks = GetIndex(Convert.ToString(reader[0]));
                            ClassVariabel.ArrBahanBaku[Indeks].QtyPakai += (Convert.ToInt32(reader[1]) / Convert.ToInt32(reader[2]));
                        }
                        reader.Close();
                    }
                    catch
                    {

                    }
                    connection.Close();        
                }

                for (int i = 0; i <= ClassVariabel.ArrBahanBaku.GetUpperBound(0); i++)
                    bValid = bValid && 
                        (ClassVariabel.ArrBahanBaku[i].SaldoAwal + ClassVariabel.ArrBahanBaku[i].QtyTerima >= 
                        ClassVariabel.ArrBahanBaku[i].QtyPakai);

                nLoop += 1;

            } while ((!bValid) && (nLoop < 100));


            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += TempLap + Environment.NewLine;

            return solusi;
        }

        public static int GetIndex(string pcKodeBahan)
        {
            int i;

            for (i = 0; i <= ClassVariabel.ArrBahanBaku.GetUpperBound(0); i++)
                if (ClassVariabel.ArrBahanBaku[i].Kode == pcKodeBahan)
                    return i;

            return -1;
        }

        public static TSolusiBaru KemungkinanSolusiBerikutnya(int[] solusiSekarang, int[,] pnData) //ambil Waktu sebagai data pengecekan
        {
            int jumlahMesin = pnData.GetUpperBound(0) + 1; //Mesin = Mesin (Baris)
            int jumlahProduk = pnData.GetUpperBound(1) + 1; //Produk = Produk (Kolom)
            TSolusiBaru solusi;

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "------------------------" + Environment.NewLine +
                                        " Bangkitkan Solusi Baru " + Environment.NewLine +
                                        "------------------------" + Environment.NewLine;

            //Tentukan produk secara acak
            Random rnd = new Random();
            int produk = rnd.Next(0, jumlahProduk);
            int Mesin = rnd.Next(0, jumlahMesin);

            while (pnData[Mesin, produk] == 0)
            {
                Mesin += 1;
                if (Mesin > jumlahMesin - 1)
                    Mesin = 0;
            }
            solusi.Indeks = produk;
            solusi.Hasil = Mesin;

            //Cek dulu apakah solusi memenuhi persyaratan atau tidak
            //Jumlah waktu yang digunakan tidak melebihi waktu kerja + lembur
            //Jumlah bahan baku yang diperlukan mencukupi



            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "Produk " + (produk + 1).ToString() + " (" + ClassVariabel.ArrProduk[produk].Nama +
                                        ") diproduksi pada Mesin " + (Mesin + 1).ToString() + " (" + ClassVariabel.ArrMesin[Mesin].Nama + ")" +
                                        Environment.NewLine;

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine;

            return solusi;
        }

        public static ClassVariabel.TEnergi HitungNilaiF()
        {
            int i;
            double TotalWaktu, TotalBiaya;
            ClassVariabel.TEnergi Hasil;
            int[] JlhPekerjaan = new int[ClassVariabel.ArrProduk.GetUpperBound(0) + 1];

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "-------------------" + Environment.NewLine +
                                        " Hitung nilai f(x) " + Environment.NewLine +
                                        "-------------------" + Environment.NewLine;

            TotalWaktu = 0;
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "Total Waktu = ";
            for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
            {
                //Hitung total waktu yang diperlukan
                TotalWaktu += ClassVariabel.ArrWaktu[ArrSolusi[i], i];

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += (i == 0 ? "" :  " + ") + ClassVariabel.ArrWaktu[ArrSolusi[i], i];

                JlhPekerjaan[ArrSolusi[i]] += 1;
            }

            for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
            {
                if (JlhPekerjaan[i] > 0)
                {
                    TotalWaktu += (JlhPekerjaan[i] - 1) * ClassVariabel.LamaMesin;

                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += "Tambahkan waktu pembersihan mesin :" + Environment.NewLine +
                                                "Total Waktu = " + (JlhPekerjaan[i] - 1).ToString() + " * " +
                                                ClassVariabel.LamaMesin.ToString() + " = " + TotalWaktu.ToString() + Environment.NewLine;
                }
            }


            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine +
                                        "Total Waktu = " + TotalWaktu.ToString("#,##0") + Environment.NewLine + Environment.NewLine;

            TotalBiaya = 0;
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "Total Biaya = ";
            for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
            {
                //Hitung total biaya yang diperlukan
                TotalBiaya += ClassVariabel.ArrBiaya[ArrSolusi[i], i];

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += (i == 0 ? "" : " + ") + ClassVariabel.ArrBiaya[ArrSolusi[i], i];
            }
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine +
                                        "Total Biaya = " + TotalBiaya.ToString("#,##0") + Environment.NewLine + Environment.NewLine;

            Hasil.Z1 = TotalBiaya;
            Hasil.Z2 = TotalWaktu;

            return Hasil;
        }

        public static ClassVariabel.TEnergi HitungNilaiFi()
        {
            int i;
            double TotalWaktu, TotalBiaya;
            ClassVariabel.TEnergi Hasil;
            int[] JlhPekerjaan = new int[ClassVariabel.ArrProduk.GetUpperBound(0) + 1];

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "--------------------" + Environment.NewLine +
                                        " Hitung nilai f(x') " + Environment.NewLine +
                                        "--------------------" + Environment.NewLine;

            TotalWaktu = 0;
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "Total Waktu = ";
            for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
            {
                //Hitung total waktu yang diperlukan
                TotalWaktu += ClassVariabel.ArrWaktu[ArrSolusiBaru[i], i];

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += (i == 0 ? "" : " + ") + ClassVariabel.ArrWaktu[ArrSolusiBaru[i], i];

                JlhPekerjaan[ArrSolusiBaru[i]] += 1;
            }

            for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
            {
                if (JlhPekerjaan[i] > 0)
                {
                    TotalWaktu += (JlhPekerjaan[i] - 1) * ClassVariabel.LamaMesin;

                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += "Tambahkan waktu pembersihan mesin :" + Environment.NewLine +
                                                "Total Waktu = " + (JlhPekerjaan[i] - 1).ToString() + " * " +
                                                ClassVariabel.LamaMesin.ToString() + " = " + TotalWaktu.ToString() + Environment.NewLine;
                }
            }


            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine +
                                        "Total Waktu = " + TotalWaktu.ToString("#,##0") + Environment.NewLine + Environment.NewLine;

            TotalBiaya = 0;
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += "Total Biaya = ";
            for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
            {
                //Hitung total biaya yang diperlukan
                TotalBiaya += ClassVariabel.ArrBiaya[ArrSolusiBaru[i], i];

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += (i == 0 ? "" : " + ") + ClassVariabel.ArrBiaya[ArrSolusiBaru[i], i];
            }
            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine +
                                        "Total Biaya = " + TotalBiaya.ToString("#,##0") + Environment.NewLine + Environment.NewLine;

            Hasil.Z1 = TotalBiaya;
            Hasil.Z2 = TotalWaktu;

            return Hasil;
        }



    }
}
