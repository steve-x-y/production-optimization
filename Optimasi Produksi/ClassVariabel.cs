using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optimasi_Produksi
{
    class ClassVariabel
    {
        //Data input yang diperlukan
        //---------------------------
        //Dnt = prediksi permintaan untuk produk n per periode t
        //Ar = jumlah waktu kerja standar
        //Ao = jumlah waktu lembur yang diperbolehkan
        //Mn = jumlah waktu yang diperlukan untuk memproduksi 1 ton produk
        //cnt = biaya produksi per ton produk n pada periode t
        //int = biaya penyimpanan produk per ton dari produk n
        //wt = biaya pekerja
        //ot = biaya lembur
        //Int-1 = jumlah produk n per periode t-1 (saldo awal stock)

        //Ot = jumlah waktu lembur
        //Wt = jumlah pekerja
        //Pnt = produksi dari produk n per periode t
        //Int = jumlah produk n = Int-1 + Pnt (tidak perlu dicari, cuman dihitung aja)
        //Biaya produksi / barang dapat dihitung dengan menggunakan formulasi produksi

        //Rumus dasar yang digunakan
        //Int = P + It-1 - D (Saldo akhir = produksi + saldo awal - permintaan)

        //Output = P (jumlah produksi)
        //Dari jumlah produksi, dapat dihitung stok akhir (Int)
        //juga dapat dihitung total waktu yang diperlukan untuk produksi barang --> ada Mn (jumlah waktu produksi / satuan barang)

        public struct TBahanBaku
        {
            public string Kode;
            public string Nama;
            public int SaldoAwal;
            public int QtyTerima;
            public int QtyPakai;
        }

        public struct TBahan
        {
            public string Kode;
            public string Nama;
            public double Qty;
            public double Harga;
            public double SubTotal;
        }

        public struct TProduk
        {
            public string Kode;
            public string Nama;
            public int Permintaan;
            public int SaldoAwal;
            public int QtyProduksi;
            public int Waktu;
            public double BiayaProduksi;
            public double BiayaSimpan;
            public double X;
            public double Xi;
        }

        public struct TEnergi
        {
            public double Z1;
            public double Z2;
        }

        public struct TMesin
        {
            public string Kode;
            public string Nama;
        }

        public static TMesin[] ArrMesin;

        public static double[,] ArrBiaya; //Mesin, Produk
        public static int[,] ArrWaktu;

        public static double LamaMesin;
        public static int nN;
        public static TBahanBaku[] ArrBahanBaku;
        public static TProduk DataProduk;
        public static TBahan DataBahan;
        public static TProduk[] ArrProduk;
        public static double Ar, Ao;
        public static bool bLaporan;
        public static int TipeUser;
        public static string cF;

        public static string PassData, TagForm, strLap;
        public static string connectionString = "Server = " + "localhost" + "; User Id = " + "root" + "; Password=" + "" + "; Database=" + "produksi" + "";
       // public static string connectionString = "Server=USER-PC\\SQLEXPRESS;database=Produksi;trusted_connection=true";

       // public static string connectionStringReport = "Provider=SQLNCLI11;Database=Produksi;Server=USER-PC\\SQLEXPRESS;trusted_connection=yes;";
        public static string connectionStringReport = "Server = " + "localhost" + "; User Id = " + "root" + "; Password=" + "" + "; Database=" + "produksi" + "";
    }
}
