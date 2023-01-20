using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Optimasi_Produksi
{
    public partial class frmPerbandingan : Form
    {
        private static double WaktuBersih;

        public frmPerbandingan()
        {
            InitializeComponent();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            ListViewItem ListItem;
            int StartTime, StartTime1, EndTime, Selisih, EksekusiSA, EksekusiMSA, N;
            double BiayaProduksi, BiayaMesin, LamaProduksi, TotalBiayaSA, TotalBiayaMSA, TotalWaktuSA, TotalWaktuMSA;
            int JlhPerulangan, TemperaturAwal, i, j;

            ClassVariabel.bLaporan = false;

            StartTime = Environment.TickCount & Int32.MaxValue;

            JlhPerulangan = Convert.ToInt32(txtM.Text);
            TemperaturAwal = Convert.ToInt32(txtTemperatur.Text);

            //Panggil fungsi SA
            BiayaProduksi = 0; BiayaMesin = 0; LamaProduksi = 0;
            if (JlhPerulangan > 0 && TemperaturAwal > 0)
            {
                //Passing data bahan baku
                ClassFungsi.LoadDataBahanBaku();

                //Proses simulated annealing
                SimulatedAnnealing(JlhPerulangan, TemperaturAwal, 0.95);

                //Tampilkan solusi
                //lstUji.Items.Clear();
                for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
                {
                    BiayaProduksi += ClassVariabel.ArrProduk[i].BiayaProduksi;
                    BiayaMesin += ClassVariabel.ArrBiaya[ClassFungsiBaru.ArrSolusi[i], i];
                    LamaProduksi += ClassVariabel.ArrWaktu[ClassFungsiBaru.ArrSolusi[i], i];
                }

                //Reset nilai
                for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
                    for (j = 0; j <= ClassVariabel.ArrProduk.GetUpperBound(0); j++)
                    {
                        ClassVariabel.ArrWaktu[i, j] /= ClassVariabel.ArrProduk[j].QtyProduksi;
                        ClassVariabel.ArrBiaya[i, j] /= ClassVariabel.ArrProduk[j].QtyProduksi;
                    }
            }

            TotalBiayaSA = (BiayaProduksi + BiayaMesin);
            TotalWaktuSA = WaktuBersih;

            //Panggil fungsi MSA
            StartTime1 = Environment.TickCount & Int32.MaxValue;

            JlhPerulangan = Convert.ToInt32(txtM.Text);
            TemperaturAwal = Convert.ToInt32(txtTemperatur.Text);

            BiayaProduksi = 0; BiayaMesin = 0; LamaProduksi = 0;
            if (JlhPerulangan > 0 && TemperaturAwal > 0)
            {
                N = 2;

                //Proses simulated annealing
                ModifiedSimulatedAnnealing(JlhPerulangan, TemperaturAwal, 0.95, N, pb1, lblKet);

                //Tampilkan solusi
                for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
                {
                    BiayaProduksi += ClassVariabel.ArrProduk[i].BiayaProduksi;
                    BiayaMesin += ClassVariabel.ArrBiaya[ClassFungsiBaru.ArrSolusiM[i, 0], i];
                    LamaProduksi += ClassVariabel.ArrWaktu[ClassFungsiBaru.ArrSolusiM[i, 0], i];
                }

                //Reset nilai
                for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
                    for (j = 0; j <= ClassVariabel.ArrProduk.GetUpperBound(0); j++)
                    {
                        ClassVariabel.ArrWaktu[i, j] /= ClassVariabel.ArrProduk[j].QtyProduksi;
                        ClassVariabel.ArrBiaya[i, j] /= ClassVariabel.ArrProduk[j].QtyProduksi;
                    }
            }
            else
            {
                MessageBox.Show("Data input tidak lengkap !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EndTime = Environment.TickCount & Int32.MaxValue;
            EksekusiSA = EndTime - StartTime;

            Selisih = EndTime - StartTime1;
            TotalBiayaMSA = (BiayaProduksi + BiayaMesin);
            TotalWaktuMSA = WaktuBersih;
            EksekusiMSA = Selisih;

            ListItem = lstUji.Items.Add((lstUji.Items.Count + 1).ToString());
            ListItem.SubItems.Add(txtM.Text);
            ListItem.SubItems.Add(txtTemperatur.Text);
            ListItem.SubItems.Add(TotalBiayaSA.ToString("#,##0"));
            ListItem.SubItems.Add(TotalBiayaMSA.ToString("#,##0"));
            ListItem.SubItems.Add(TotalWaktuSA.ToString("#,##0"));
            ListItem.SubItems.Add(TotalWaktuMSA.ToString("#,##0"));
            ListItem.SubItems.Add(EksekusiSA.ToString("#,##0"));
            ListItem.SubItems.Add(EksekusiMSA.ToString("#,##0"));
        }


        public static void SimulatedAnnealing(int pnM, int pnT, double pnAlpha)
        {

            int k, i, j;
            ClassVariabel.TEnergi Fx, Fxi;
            double p, Tk = pnT, Delta, Z;
            ClassFungsiBaru.TSolusiBaru temp;

            for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
            {
                ClassVariabel.ArrProduk[i].QtyProduksi = ClassVariabel.ArrProduk[i].Permintaan - ClassVariabel.ArrProduk[i].SaldoAwal;

                if (ClassVariabel.ArrProduk[i].QtyProduksi < 0)
                {
                    ClassVariabel.ArrProduk[i].QtyProduksi = 0;
                }
            }

            //Set matriks waktu dan biaya sesuai dengan data jumlah qty produksinya
            for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
                for (j = 0; j <= ClassVariabel.ArrProduk.GetUpperBound(0); j++)
                {
                    ClassVariabel.ArrWaktu[i, j] *= ClassVariabel.ArrProduk[j].QtyProduksi;
                }

            for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
                for (j = 0; j <= ClassVariabel.ArrProduk.GetUpperBound(0); j++)
                {
                    ClassVariabel.ArrBiaya[i, j] *= ClassVariabel.ArrProduk[j].QtyProduksi;
                }

            //Set initial solution x (current solution) --> tentukan secara acak
            //ArrSolusi = new int[ClassVariabel.ArrMesin.GetUpperBound(0) + 1, ClassVariabel.ArrProduk.GetUpperBound(0) + 1];
            ClassFungsiBaru.ArrSolusi = ClassFungsiBaru.AlokasiMesinAwal(ClassVariabel.ArrProduk.GetUpperBound(0), ClassVariabel.ArrMesin.GetUpperBound(0),
                                         ClassVariabel.ArrWaktu);

            //Set nilai awal lainnya
            Fx.Z1 = 0; Fx.Z2 = 0;
            Fxi.Z1 = 0; Fxi.Z2 = 0;

            //Hitung nilai fitness untuk setiap solusi x
            Fx = ClassFungsiBaru.HitungNilaiF();

            //Looping hingga temperatur = 0
            ClassFungsiBaru.ArrSolusiBaru = new int[ClassFungsiBaru.ArrSolusi.GetUpperBound(0) + 1];

            while (Math.Round(Tk, 2) > 0)
            {
                //Set nilai awal k
                k = 0;

                //Looping hingga k = m
                while (k != pnM)
                {
                    //Inkremen nilai k
                    k += 1;

                    //Generate solusi baru x'
                    for (i = 0; i <= ClassFungsiBaru.ArrSolusi.GetUpperBound(0); i++)
                    {
                        ClassFungsiBaru.ArrSolusiBaru[i] = ClassFungsiBaru.ArrSolusi[i];
                    }
                    temp = ClassFungsiBaru.KemungkinanSolusiBerikutnya(ClassFungsiBaru.ArrSolusi, ClassVariabel.ArrWaktu);
                    ClassFungsiBaru.ArrSolusiBaru[temp.Indeks] = temp.Hasil;

                    //Hitung nilai fitness untuk setiap solusi x dan x'
                    Fxi = ClassFungsiBaru.HitungNilaiFi();

                    //Check condition
                    if (Fxi.Z1 <= Fx.Z1)
                    {
                        Fx.Z1 = Fxi.Z1;
                        Fx.Z2 = Fxi.Z2;

                        //Passing semua nilai xi ke x (x = xi);
                        for (i = 0; i <= ClassFungsiBaru.ArrSolusi.GetUpperBound(0); i++)
                        {
                            ClassFungsiBaru.ArrSolusi[i] = ClassFungsiBaru.ArrSolusiBaru[i];
                        }
                    }
                    else
                    {
                        Delta = Math.Abs(Fxi.Z1 - Fx.Z1);
                        p = Math.Exp(-Delta / pnT);

                        Random r = new Random();
                        Z = r.Next(1, 100000);

                        if (p < Z)
                        {
                            Fx.Z1 = Fxi.Z1;
                            Fx.Z2 = Fxi.Z2;

                            //Passing semua nilai xi ke x (x = xi);
                            for (i = 0; i <= ClassFungsiBaru.ArrSolusi.GetUpperBound(0); i++)
                            {
                                ClassFungsiBaru.ArrSolusi[i] = ClassFungsiBaru.ArrSolusiBaru[i];
                            }
                        }
                    }
                }

                //Kurangi temperatur
                Tk = 0.95 * Tk;

                double Nilai_Tk = Math.Round(Tk, 2);
            }

            WaktuBersih = Fx.Z2;
        }



        public static void ModifiedSimulatedAnnealing(int pnM, int pnT, double pnAlpha, int pnN, ProgressBar pb1, Label lblKet)
        {
            int k, i, j, k1;
            ClassVariabel.TEnergi[] Fx, Fxi;
            double p, Tk = pnT, Delta, Z;
            int[] temp1;
            ClassFungsiBaru.TSolusiBaru[] temp;

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap = "----------------------------" + Environment.NewLine +
                                       " Daftar Produk yang Diminta " + Environment.NewLine +
                                       "----------------------------" + Environment.NewLine;

            pb1.Value = 0;
            lblKet.Text = "";
            pb1.Visible = true;
            lblKet.Visible = true;

            for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
            {
                ClassVariabel.ArrProduk[i].QtyProduksi = ClassVariabel.ArrProduk[i].Permintaan - ClassVariabel.ArrProduk[i].SaldoAwal;

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += ClassVariabel.ArrProduk[i].Nama +
                                            " (Qty yang akan diproduksi = " + ClassVariabel.ArrProduk[i].Permintaan + " - " +
                                            ClassVariabel.ArrProduk[i].SaldoAwal + " = " +
                                            ClassVariabel.ArrProduk[i].QtyProduksi + ")";

                if (ClassVariabel.ArrProduk[i].QtyProduksi < 0)
                {
                    ClassVariabel.ArrProduk[i].QtyProduksi = 0;

                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += " --> berarti tidak perlu diproduksi lagi, karena stock telah mencukupi.";
                }

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += Environment.NewLine;
            }

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine;

            if (ClassVariabel.bLaporan)
            {
                ClassVariabel.strLap = "-----------------------------" + Environment.NewLine +
                                       " Daftar Mesin yang Digunakan " + Environment.NewLine +
                                       "-----------------------------" + Environment.NewLine;

                for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
                    ClassVariabel.strLap += ClassVariabel.ArrMesin[i].Nama + Environment.NewLine;

                ClassVariabel.strLap += Environment.NewLine;
            }

            //Set matriks waktu dan biaya sesuai dengan data jumlah qty produksinya
            for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
                for (j = 0; j <= ClassVariabel.ArrProduk.GetUpperBound(0); j++)
                {
                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += "Waktu kerja Mesin " + (i + 1).ToString() + " untuk memproduksi produk " +
                                                (j + 1).ToString() + " : " + ClassVariabel.ArrWaktu[i, j] + " * " +
                                                ClassVariabel.ArrProduk[j].QtyProduksi + " = ";
                    ClassVariabel.ArrWaktu[i, j] *= ClassVariabel.ArrProduk[j].QtyProduksi;

                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += ClassVariabel.ArrWaktu[i, j] + Environment.NewLine;
                }

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine;

            for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
                for (j = 0; j <= ClassVariabel.ArrProduk.GetUpperBound(0); j++)
                {
                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += "Biaya Mesin " + (i + 1).ToString() + " untuk memproduksi produk " +
                                                (j + 1).ToString() + " : " + ClassVariabel.ArrBiaya[i, j] + " * " +
                                                ClassVariabel.ArrProduk[j].QtyProduksi + " = ";
                    ClassVariabel.ArrBiaya[i, j] *= ClassVariabel.ArrProduk[j].QtyProduksi;

                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += ClassVariabel.ArrBiaya[i, j] + Environment.NewLine;
                }

            if (ClassVariabel.bLaporan)
                ClassVariabel.strLap += Environment.NewLine;

            //Set initial solution x (current solution) --> tentukan secara acak
            //ArrSolusi = new int[ClassVariabel.ArrMesin.GetUpperBound(0) + 1, ClassVariabel.ArrProduk.GetUpperBound(0) + 1];
            ClassFungsiBaru.ArrSolusiM = ClassFungsiBaru.AlokasiMesinAwal_Array(ClassVariabel.ArrProduk.GetUpperBound(0), ClassVariabel.ArrMesin.GetUpperBound(0), pnN,
                                         ClassVariabel.ArrWaktu);

            //Set nilai awal lainnya
            Fx = new ClassVariabel.TEnergi[pnN + 1];
            Fxi = new ClassVariabel.TEnergi[pnN + 1];

            for (i = 0; i <= pnN; i++)
            {
                //Hitung nilai fitness untuk setiap solusi x
                Fx[i] = ClassFungsiBaru.HitungNilaiF_Array(i);
            }

            //Urutkan nilai Fx
            double nTemp;
            temp1 = new int[ClassFungsiBaru.ArrSolusiM.GetUpperBound(1) + 1];
            ClassFungsiBaru.ArrSolusiBaruM = new int[ClassFungsiBaru.ArrSolusiM.GetUpperBound(0) + 1, ClassFungsiBaru.ArrSolusiM.GetUpperBound(1) + 1];
            for (i = 0; i <= pnN - 1; i++)
                for (j = i + 1; j <= pnN; j++)
                    if (Fx[i].Z1 > Fx[j].Z1)
                    {
                        //Swap nilai f
                        nTemp = Fx[i].Z1;
                        Fx[i].Z1 = Fx[j].Z1;
                        Fx[j].Z1 = nTemp;

                        nTemp = Fx[i].Z2;
                        Fx[i].Z2 = Fx[j].Z2;
                        Fx[j].Z2 = nTemp;

                        //temp = i
                        for (k = 0; k <= ClassFungsiBaru.ArrSolusiM.GetUpperBound(1); k++)
                            temp1[k] = ClassFungsiBaru.ArrSolusiM[i, k];

                        //i = j
                        for (k = 0; k <= ClassFungsiBaru.ArrSolusiM.GetUpperBound(1); k++)
                            ClassFungsiBaru.ArrSolusiM[i, k] = ClassFungsiBaru.ArrSolusiM[j, k];

                        //j = temp
                        for (k = 0; k <= ClassFungsiBaru.ArrSolusiM.GetUpperBound(1); k++)
                            ClassFungsiBaru.ArrSolusiM[j, k] = temp1[k];
                    }

            //Looping hingga temperatur = 0
            //ClassFungsiBaru.ArrSolusiBaruM = new int[ClassFungsiBaru.ArrSolusiM.GetUpperBound(0) + 1];

            while (Math.Round(Tk, 2) > 0)
            {
                //Set nilai awal k
                k = 0;
                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += "k = 0" + Environment.NewLine;

                pb1.Maximum = pnM;
                pb1.Value = 0;
                Application.DoEvents();

                //Looping hingga k = m
                while (k != pnM)
                {
                    //Inkremen nilai k
                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += "k = " + k.ToString() + " + 1 = ";
                    k += 1;
                    if (ClassVariabel.bLaporan)
                        ClassVariabel.strLap += k.ToString() + Environment.NewLine;

                    pb1.Value += 1;
                    lblKet.Text = "Perhitungan untuk suhu T = " + Math.Round(Tk, 2) + " dan k = " + k.ToString();
                    Application.DoEvents();

                    //Generate solusi baru x'
                    for (i = 0; i <= ClassFungsiBaru.ArrSolusiM.GetUpperBound(0); i++)
                        for (j = 0; j <= ClassFungsiBaru.ArrSolusiM.GetUpperBound(1); j++)
                        {
                            ClassFungsiBaru.ArrSolusiBaruM[i, j] = ClassFungsiBaru.ArrSolusiM[i, j];
                        }

                    temp = ClassFungsiBaru.KemungkinanSolusiBerikutnya_Array(ClassFungsiBaru.ArrSolusiBaruM, pnN, ClassVariabel.ArrWaktu);
                    for (i = 0; i <= temp.GetUpperBound(0); i++)
                        ClassFungsiBaru.ArrSolusiBaruM[i, temp[i].Indeks] = temp[i].Hasil;

                    //Hitung nilai fitness untuk setiap solusi x'
                    for (i = 0; i <= pnN; i++)
                        Fxi[i] = ClassFungsiBaru.HitungNilaiFi_Array(i);

                    //Urutkan nilai f(x')
                    for (i = 0; i <= pnN - 1; i++)
                        for (j = i + 1; j <= pnN; j++)
                            if (Fxi[i].Z1 > Fxi[j].Z1)
                            {
                                //Swap nilai f
                                nTemp = Fxi[i].Z1;
                                Fxi[i].Z1 = Fxi[j].Z1;
                                Fxi[j].Z1 = nTemp;

                                nTemp = Fxi[i].Z2;
                                Fxi[i].Z2 = Fxi[j].Z2;
                                Fxi[j].Z2 = nTemp;

                                //temp = i
                                for (k1 = 0; k1 <= ClassFungsiBaru.ArrSolusiBaruM.GetUpperBound(1); k1++)
                                    temp1[k1] = ClassFungsiBaru.ArrSolusiBaruM[i, k1];

                                //i = j
                                for (k1 = 0; k1 <= ClassFungsiBaru.ArrSolusiBaruM.GetUpperBound(1); k1++)
                                    ClassFungsiBaru.ArrSolusiBaruM[i, k1] = ClassFungsiBaru.ArrSolusiBaruM[j, k1];

                                //j = temp
                                for (k1 = 0; k1 <= ClassFungsiBaru.ArrSolusiBaruM.GetUpperBound(1); k1++)
                                    ClassFungsiBaru.ArrSolusiBaruM[j, k1] = temp1[k1];
                            }

                    //Check condition
                    if (Fxi[0].Z1 <= Fx[0].Z1)
                    {
                        Fx[0].Z1 = Fxi[0].Z1;
                        Fx[0].Z2 = Fxi[0].Z2;

                        if (ClassVariabel.bLaporan)
                            ClassVariabel.strLap += "Z1 (total biaya) = " + Fx[0].Z1 + Environment.NewLine +
                                                    "Z2 (total waktu) = " + Fx[0].Z2 + Environment.NewLine + Environment.NewLine;

                        //Passing semua nilai xi ke x (x = xi);
                        for (i = 0; i <= ClassFungsiBaru.ArrSolusiM.GetUpperBound(1); i++)
                        {
                            ClassFungsiBaru.ArrSolusiM[0, i] = ClassFungsiBaru.ArrSolusiBaruM[0, i];

                            if (ClassVariabel.bLaporan)
                                ClassVariabel.strLap += "Solusi[" + i.ToString() + "] = " + ClassFungsiBaru.ArrSolusiBaruM[0, i].ToString() + Environment.NewLine;
                        }
                    }
                    else
                    {
                        Delta = Math.Abs(Fxi[0].Z1 - Fx[0].Z1);
                        p = Math.Exp(-Delta / pnT);

                        if (ClassVariabel.bLaporan)
                            ClassVariabel.strLap += "Hitung nilai p" + Environment.NewLine +
                                                    "Delta = " + Fxi[0].Z1.ToString() + " - " + Fx[0].Z1.ToString() + Environment.NewLine +
                                                    "Delta = " + Delta.ToString() + Environment.NewLine + Environment.NewLine +
                                                    "p = e^(-" + Delta.ToString() + " / " + pnT.ToString() + ")" + Environment.NewLine +
                                                    "p = " + p.ToString() + Environment.NewLine + Environment.NewLine;

                        Random r = new Random();
                        Z = r.Next(1, 100000);
                        if (ClassVariabel.bLaporan)
                            ClassVariabel.strLap += "Ambil sebuah nilai acak Z = " + Z.ToString() + Environment.NewLine;

                        if (p < Z)
                        {
                            if (ClassVariabel.bLaporan)
                                ClassVariabel.strLap += "p (" + p.ToString() + ") = Z (" + Fx[0].Z2.ToString() + ") --> benar" +
                                                        Environment.NewLine + "Set nilai f(x) = f(x')" + Environment.NewLine;

                            Fx[0].Z1 = Fxi[0].Z1;
                            Fx[0].Z2 = Fxi[0].Z2;

                            if (ClassVariabel.bLaporan)
                                ClassVariabel.strLap += "Z1 (total biaya) = " + Fx[0].Z1 + Environment.NewLine +
                                                        "Z2 (total waktu) = " + Fx[0].Z2 + Environment.NewLine + Environment.NewLine;

                            if (ClassVariabel.bLaporan)
                                ClassVariabel.strLap += "Set nilai x = x'" + Environment.NewLine;

                            //Passing semua nilai xi ke x (x = xi);
                            for (i = 0; i <= ClassFungsiBaru.ArrSolusiM.GetUpperBound(1); i++)
                            {
                                ClassFungsiBaru.ArrSolusiM[0, i] = ClassFungsiBaru.ArrSolusiBaruM[0, i];

                                if (ClassVariabel.bLaporan)
                                    ClassVariabel.strLap += "Solusi[" + i.ToString() + "] = " + ClassFungsiBaru.ArrSolusiBaruM[0, i].ToString() + Environment.NewLine;
                            }

                            if (ClassVariabel.bLaporan)
                                ClassVariabel.strLap += Environment.NewLine;
                        }
                    }
                }

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += "T = 0.95 * " + Tk + Environment.NewLine;

                //Kurangi temperatur
                Tk = 0.95 * Tk;

                double Nilai_Tk = Math.Round(Tk, 2);

                if (ClassVariabel.bLaporan)
                    ClassVariabel.strLap += "T = " + Tk.ToString() + Environment.NewLine + Environment.NewLine;
            }

            WaktuBersih = Fx[0].Z2;

            pb1.Visible = false;
            lblKet.Visible = false;

        }
    }
}
