using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace Optimasi_Produksi
{
    class ClassFungsi
    {
        private ClassFungsi() { }

        //public static void SimulatedAnnealing(int pnM, int pnT, double pnAlpha)
        //{
        //    int k, i;
        //    ClassVariabel.TEnergi Fx, Fxi;
        //    double p, RFx = 0, RFxi = 0, Tk = pnT, Delta, Z;

        //    //Set initial solution x (current solution) --> tentukan secara acak
        //    GenerateSolusiAwal();

        //    //Set nilai awal lainnya
        //    Fx.Z1 = 0; Fx.Z2 = 0;
        //    Fxi.Z1 = 0; Fxi.Z2 = 0;

        //    //Hitung nilai fitness untuk setiap solusi x
        //    Fx = HitungEnergi(false);

        //    //Looping hingga temperatur = 0
        //    while (Tk > 0)
        //    {
        //        //Set nilai awal k
        //        k = 0;

        //        //Looping hingga k = m
        //        while (k != pnM)
        //        {
        //            //Inkremen nilai k
        //            k += 1;

        //            //Generate solusi baru x'
        //            GenerateSolusiBaru();

        //            //Hitung nilai fitness untuk setiap solusi x dan x'
        //            Fxi = HitungEnergi(true);

        //            RFx = Fx.Z1 + Fx.Z2;
        //            RFxi = Fxi.Z1 + Fxi.Z2;

        //            //Check condition
        //            if (RFxi <= RFx)
        //            {
        //                Fx = Fxi;

        //                //Passing semua nilai xi ke x (x = xi);
        //                for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
        //                    ClassVariabel.ArrProduk[i].X = ClassVariabel.ArrProduk[i].Xi;
        //            }
        //            else
        //            {
        //                Delta = Math.Abs(RFxi - RFx);
        //                p = Math.Exp(-Delta / pnT);

        //                Random r = new Random();
        //                Z = r.Next(1, 100000);
        //                if (p < Z)
        //                {
        //                    Fx = Fxi;

        //                    //Passing semua nilai xi ke x (x = xi);
        //                    for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
        //                        ClassVariabel.ArrProduk[i].X = ClassVariabel.ArrProduk[i].Xi;
        //                }
        //            }
        //        }

        //        //Kurangi temperatur
        //        Tk = Math.Round(0.95 * Tk, 2);
        //    }
        //}

        //public static void ModifiedSimulatedAnnealing(int pnM, int pnT, double pnAlpha)
        //{
        //    int k, i;
        //    ClassVariabel.TEnergi Fx, Fxi;
        //    double p, RFx = 0, RFxi = 0, Tk = pnT, Delta, Z;

        //    //Set initial solution x (current solution) --> tentukan secara acak
        //    GenerateSolusiAwalArray();

        //    //Set nilai awal lainnya
        //    Fx.Z1 = 0; Fx.Z2 = 0;
        //    Fxi.Z1 = 0; Fxi.Z2 = 0;

        //    //Hitung nilai fitness untuk setiap solusi x
        //    Fx = HitungEnergi(false);

        //    //Looping hingga temperatur = 0
        //    while (Tk > 0)
        //    {
        //        //******************
        //        //Cari nilai f(xi)
        //        //******************


        //        //Set nilai awal k
        //        k = 0;

        //        //Looping hingga k = m
        //        while (k != pnM)
        //        {
        //            //Inkremen nilai k
        //            k += 1;

        //            //Generate solusi baru x'
        //            GenerateSolusiBaruArray();

        //            //Hitung nilai fitness untuk setiap solusi x dan x'
        //            Fxi = HitungEnergi(true);

        //            //Check condition
        //            if (RFxi <= RFx)
        //            {
        //                Fx = Fxi;

        //                //Passing semua nilai xi ke x (x = xi);
        //                for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
        //                    ClassVariabel.ArrProduk[i].X = ClassVariabel.ArrProduk[i].Xi;
        //            }
        //            else
        //            {
        //                Delta = Math.Abs(RFxi - RFx);
        //                p = Math.Exp(-Delta / pnT);

        //                Random r = new Random();
        //                Z = r.Next(1, 100000);
        //                if (p < Z)
        //                {                            
        //                    Fx = Fxi;

        //                    //Passing semua nilai xi ke x (x = xi);
        //                    for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
        //                        ClassVariabel.ArrProduk[i].X = ClassVariabel.ArrProduk[i].Xi;
        //                }
        //            }
        //        }

        //        //Kurangi temperatur
        //        Tk = Math.Round(0.95 * Tk, 2);
        //    }
        //}

        //public static ClassVariabel.TEnergi HitungEnergi(Boolean pbSolusiBaru)
        //{
        //    int i;
        //    double SaldoAkhir;
        //    ClassVariabel.TEnergi Temp;

        //    //Hitung nilai Z1 --> Biaya Produksi + Biaya Penyimpanan
        //    Temp.Z1 = 0; SaldoAkhir = 0;
        //    for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
        //    {
        //        if (pbSolusiBaru)
        //        {
        //            //Hitung biaya produksi
        //            Temp.Z1 += ClassVariabel.ArrProduk[i].BiayaProduksi * ClassVariabel.ArrProduk[i].Xi;

        //            //Hitung saldo akhir stock
        //            SaldoAkhir = ClassVariabel.ArrProduk[i].Xi + ClassVariabel.ArrProduk[i].SaldoAwal - ClassVariabel.ArrProduk[i].Permintaan;

        //            //Hitung biaya penyimpanan
        //            Temp.Z1 += ClassVariabel.ArrProduk[i].BiayaSimpan * SaldoAkhir;
        //        }
        //        else
        //        {
        //            //Hitung biaya produksi
        //            Temp.Z1 += ClassVariabel.ArrProduk[i].BiayaProduksi * ClassVariabel.ArrProduk[i].X;

        //            //Hitung saldo akhir stock
        //            SaldoAkhir = ClassVariabel.ArrProduk[i].X + ClassVariabel.ArrProduk[i].SaldoAwal - ClassVariabel.ArrProduk[i].Permintaan;

        //            //Hitung biaya penyimpanan
        //            Temp.Z1 += ClassVariabel.ArrProduk[i].BiayaSimpan * SaldoAkhir;
        //        }
        //    }

        //    //Hitung biaya penyimpanan sisa bahan baku
        //    for (i = 0; i <= ClassVariabel.ArrBahanBaku.GetUpperBound(0); i++)
        //    {
        //        if (pbSolusiBaru)
        //            Temp.Z1 += ClassVariabel.ArrBahanBaku[i].Sisa_Xi * ClassVariabel.ArrBahanBaku[i].BiayaSimpan;
        //        else
        //            Temp.Z1 += ClassVariabel.ArrBahanBaku[i].Sisa_X * ClassVariabel.ArrBahanBaku[i].BiayaSimpan;
        //    }

        //    //Hitung nilai Z2 --> Biaya Pekerja + Biaya Overtime
        //    //Biaya pekerja --> asumsi 25 hari kerja
        //    Temp.Z2 = ClassVariabel.Wt * ClassVariabel.wt * 25;

        //    if (pbSolusiBaru)
        //        //Biaya lembur (overtime)
        //        Temp.Z2 += ClassVariabel.JlhJamLembur_i * ClassVariabel.ot;
        //    else
        //        //Biaya lembur (overtime)
        //        Temp.Z2 += ClassVariabel.JlhJamLembur * ClassVariabel.ot;

        //    return Temp;
        //}

        ////Solusi dikatakan valid, jika:
        ////- jumlah stock bahan baku mencukupi untuk proses produksi
        ////- jumlah waktu kerja mencukupi 
        ////- jumlah waktu lembur tidak melebihi batasan yang diperbolehkan
        //public static bool ValidSolution(bool pbSolusiBaru)
        //{
        //    int i, Waktu, Idx;
        //    double TotalJamKerja;
        //    bool Hasil;
        //    string connectionString = ClassVariabel.connectionString;
        //    string strQuery;
        //    MySqlCommand command;
        //    MySqlDataReader reader;
        //    MySqlConnection connection;

        //    //Reset nilai awal
        //    Hasil = true; TotalJamKerja = 0; Waktu = 0;
        //    for (i = 0; i <= ClassVariabel.ArrBahanBaku.GetUpperBound(0); i++)
        //    {
        //        if (pbSolusiBaru)
        //            ClassVariabel.ArrBahanBaku[i].Sisa_Xi = ClassVariabel.ArrBahanBaku[i].SaldoAwal;
        //        else
        //            ClassVariabel.ArrBahanBaku[i].Sisa_X = ClassVariabel.ArrBahanBaku[i].SaldoAwal;
        //    }

        //    for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
        //    {
        //        if (pbSolusiBaru)
        //        {
        //            //Baca data bahan baku yang diperlukan untuk memproduksi produk tersebut
        //            connection = new MySqlConnection();
        //            connection.ConnectionString = connectionString;

        //            strQuery = "Select F.KodeBahan, NamaBahan, Qty, Harga, Qty * Harga, Waktu, QtyProduk " +
        //                       "From Formulasi F INNER JOIN Bahan B ON F.KodeBahan = B.KodeBahan Where KodeProduk = '" +
        //                       ClassVariabel.ArrProduk[i].Kode + "'";

        //            try
        //            {
        //                connection.Open();
        //                command = new MySqlCommand(strQuery, connection);
        //                command.CommandType = CommandType.Text;
        //                command.ExecuteNonQuery();
        //                reader = command.ExecuteReader();

        //                while (reader.Read())
        //                {
        //                    Waktu = Convert.ToInt32(reader[5]);
        //                    Idx = GetIndex(Convert.ToString(reader[0]));

        //                    //Hitung sisa bahan baku
        //                    ClassVariabel.ArrBahanBaku[Idx].Sisa_Xi -= Convert.ToDouble(reader[2]) * ClassVariabel.ArrProduk[i].Xi / Convert.ToDouble(reader[6]);
        //                }
        //                reader.Close();
        //            }
        //            catch
        //            {
                        
        //            }
        //            connection.Close();

        //            //Baca data waktu yang diperlukan untuk memproduksi produk tersebut
        //            TotalJamKerja += Waktu * ClassVariabel.ArrProduk[i].Xi;
        //        }
        //        else
        //        {
        //            //Baca data bahan baku yang diperlukan untuk memproduksi produk tersebut
        //            connection = new MySqlConnection();
        //            connection.ConnectionString = connectionString;

        //            strQuery = "Select F.KodeBahan, NamaBahan, Qty, F.Harga, Qty * F.Harga, Waktu, QtyProduk " +
        //                       "From Formulasi F INNER JOIN Bahan B ON F.KodeBahan = B.KodeBahan Where KodeProduk = '" +
        //                       ClassVariabel.ArrProduk[i].Kode + "'";

        //            try
        //            {
        //                connection.Open();
        //                command = new MySqlCommand(strQuery, connection);
        //                command.CommandType = CommandType.Text;
        //                command.ExecuteNonQuery();
        //                reader = command.ExecuteReader();

        //                while (reader.Read())
        //                {
        //                    Waktu = Convert.ToInt32(reader[5]);
        //                    Idx = GetIndex(Convert.ToString(reader[0]));

        //                    //Hitung sisa bahan baku
        //                    ClassVariabel.ArrBahanBaku[Idx].Sisa_X -= Convert.ToDouble(reader[2]) * ClassVariabel.ArrProduk[i].X / Convert.ToDouble(reader[6]);
        //                }
        //                reader.Close();
        //            }
        //            catch
        //            {

        //            }
        //            connection.Close();

        //            //Baca data waktu yang diperlukan untuk memproduksi produk tersebut
        //            TotalJamKerja += Waktu * ClassVariabel.ArrProduk[i].X;
        //        }
        //    }

        //    //Cek sisa bahan baku
        //    for (i = 0; i <= ClassVariabel.ArrBahanBaku.GetUpperBound(0); i++)
        //    {
        //        if ((pbSolusiBaru) && (ClassVariabel.ArrBahanBaku[i].Sisa_Xi < 0))
        //            return false;
        //        else if ((!pbSolusiBaru) && (ClassVariabel.ArrBahanBaku[i].Sisa_X < 0))
        //            return false;
        //    }

        //    //Jumlah waktu kerja tidak mencukupi untuk memproduksi semua produk
        //    if (TotalJamKerja > (ClassVariabel.Ar + ClassVariabel.Ao) * 25)
        //        Hasil = false;

        //    //Total jumlah jam kerja
        //    ClassVariabel.JlhJamKerja = TotalJamKerja;

        //    //Total jumlah jam lembur
        //    if (pbSolusiBaru)
        //        ClassVariabel.JlhJamLembur_i = ClassVariabel.JlhJamKerja - 25 * ClassVariabel.Ar;
        //    else
        //        ClassVariabel.JlhJamLembur = ClassVariabel.JlhJamKerja - 25 * ClassVariabel.Ar;

        //    return Hasil;
        //}

        ////Tentukan solusi awal dari permasalahan
        //public static void GenerateSolusiAwalArray()
        //{
        //    int i, j, nLoop;

        //    //Bangkitkan nilai acak sebagai jumlah produksi dari setiap produk
        //    Random r = new Random();

        //    ClassVariabel.ArrX = new double[ClassVariabel.ArrProduk.GetUpperBound(0) + 1, ClassVariabel.nN + 1];

        //    nLoop = 0;
        //    do
        //    {
        //        for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
        //        {
        //            for (j = 0; j <= ClassVariabel.nN; j++)
        //            {
        //                if (nLoop == 0)
        //                    //Generate solusi awal x --> minimal harus memenuhi jumlah permintaan, jadi set sebesar angka yang mampu menutupi jlh permintaan saja
        //                    ClassVariabel.ArrX[i, j] = ClassVariabel.ArrProduk[i].Permintaan - ClassVariabel.ArrProduk[i].SaldoAwal;
        //                else
        //                    ClassVariabel.ArrX[i, j] = r.Next(1, ClassVariabel.ArrProduk[i].Permintaan * nLoop);

        //                //Ternyata jumlah saldo awal sudah mampu memenuhi jumlah permintaan
        //                //Tapi kalo 0 berarti proses produksi tidak jalan --> terpaksa ambil angka secara acak saja
        //                if (ClassVariabel.ArrX[i, j] <= 0)
        //                    ClassVariabel.ArrX[i, j] = r.Next(1, ClassVariabel.ArrProduk[i].Permintaan);
        //            }
        //        }
        //        nLoop += 1;
        //    } while (!ValidSolution(false));
        //}

        ////Tentukan solusi baru sebagai perbandingan dengan solusi sekarang
        //public static void GenerateSolusiBaruArray()
        //{
        //    //Ambil angka baru diantara angka sekarang, range nilai (Nilai_Sekarang - 100) sampai (Nilai_Sekarang + 100)
        //    int i, j, Sign, nLoop;
        //    Random r = new Random();

        //    ClassVariabel.ArrXi = new double[ClassVariabel.ArrProduk.GetUpperBound(0) + 1, ClassVariabel.nN + 1];

        //    nLoop = 0;
        //    do
        //    {
        //        for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
        //        {
        //            for (j = 0; j <= ClassVariabel.nN; j++)
        //            {
        //                Sign = r.Next(0, 100);
        //                if ((Sign % 2) == 0)
        //                    ClassVariabel.ArrXi[i, j] = ClassVariabel.ArrX[i, j] - r.Next(1, 100);
        //                else
        //                    ClassVariabel.ArrXi[i, j] = ClassVariabel.ArrX[i, j] + r.Next(1, 100);
        //            }
        //        }
        //        nLoop += 1;
        //    } while (!ValidSolution(true));
        //}

        ////Tentukan solusi awal dari permasalahan
        //public static void GenerateSolusiAwal()
        //{
        //    int i, nLoop;

        //    //Bangkitkan nilai acak sebagai jumlah produksi dari setiap produk
        //    Random r = new Random();

        //    nLoop = 0;
        //    do
        //    {
        //        for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
        //        {
        //            if (nLoop == 0)
        //                //Generate solusi awal x --> minimal harus memenuhi jumlah permintaan, jadi set sebesar angka yang mampu menutupi jlh permintaan saja
        //                ClassVariabel.ArrProduk[i].X = ClassVariabel.ArrProduk[i].Permintaan - ClassVariabel.ArrProduk[i].SaldoAwal;
        //            else
        //                ClassVariabel.ArrProduk[i].X = r.Next(1, ClassVariabel.ArrProduk[i].Permintaan * nLoop);

        //            //Ternyata jumlah saldo awal sudah mampu memenuhi jumlah permintaan
        //            //Tapi kalo 0 berarti proses produksi tidak jalan --> terpaksa ambil angka secara acak saja
        //            if (ClassVariabel.ArrProduk[i].X <= 0)
        //                ClassVariabel.ArrProduk[i].X = r.Next(1, ClassVariabel.ArrProduk[i].Permintaan);
        //        }
        //        nLoop += 1;
        //    } while (!ValidSolution(false));
        //}

        ////Tentukan solusi baru sebagai perbandingan dengan solusi sekarang
        //public static void GenerateSolusiBaru()
        //{
        //    //Ambil angka baru diantara angka sekarang, range nilai (Nilai_Sekarang - 100) sampai (Nilai_Sekarang + 100)
        //    int i, Sign, nLoop;
        //    Random r = new Random();

        //    nLoop = 0;
        //    do
        //    {
        //        for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
        //        {
        //            Sign = r.Next(0, 100);
        //            if ((Sign % 2) == 0)
        //                ClassVariabel.ArrProduk[i].Xi = ClassVariabel.ArrProduk[i].X - r.Next(1, 100);
        //            else
        //                ClassVariabel.ArrProduk[i].Xi = ClassVariabel.ArrProduk[i].X + r.Next(1, 100);
        //        }
        //        nLoop += 1;
        //    } while (!ValidSolution(true));
        //}

        public static void LoadDataBahanBaku()
        {
            int i;

            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select COUNT(KodeBahan) From Bahan";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    ClassVariabel.ArrBahanBaku = new ClassVariabel.TBahanBaku[Convert.ToInt32(reader[0])];

                reader.Close();
            }
            catch
            {
                
            }
            connection.Close();

            connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select B.KodeBahan, B.NamaBahan, B.SaldoAwal, " +
                       "(Select SUM(D.Qty) From TerimaD D Where D.KodeBahan = B.KodeBahan) " +
                       "From Bahan B Order By B.KodeBahan";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                i = 0;
                while (reader.Read())
                {
                    ClassVariabel.ArrBahanBaku[i].Kode = Convert.ToString(reader[0]);
                    ClassVariabel.ArrBahanBaku[i].Nama = Convert.ToString(reader[1]);
                    ClassVariabel.ArrBahanBaku[i].SaldoAwal = Convert.ToInt32(reader[2]);
                    ClassVariabel.ArrBahanBaku[i].QtyTerima = Convert.ToInt32(reader[3]);
                    i += 1;
                }
                reader.Close();
            }
            catch 
            {
                
            }
            connection.Close();        
        }

        //Pengecekan apakah kode telah ada atau belum
        public static Boolean IsExistKode(string pcKode, string pcField, string pcTabel)
        {
            string cF;
            string connectionString = ClassVariabel.connectionString;
            Boolean Hasil = false;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            cF = "Select * From " + pcTabel + " Where " + pcField + " = '" + pcKode + "'";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(cF, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Hasil = true;
                }
                reader.Close();
            }
            catch
            {
                Hasil = false;
            }
            connection.Close();
            return Hasil;
        }



    }
}
