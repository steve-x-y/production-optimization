using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Optimasi_Produksi
{
    public partial class frmProses_MSA : Form
    {
        private static double WaktuBersih;

        public frmProses_MSA()
        {
            InitializeComponent();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            int JlhPerulangan, TemperaturAwal, i, j, N;
            ListViewItem ListItem;
            int StartTime, EndTime, Selisih;
            double BiayaProduksi, BiayaMesin, LamaProduksi, TotalWaktu;

            StartTime = Environment.TickCount & Int32.MaxValue;

            JlhPerulangan = Convert.ToInt32(txtM.Text);
            TemperaturAwal = Convert.ToInt32(txtTemperatur.Text);

            ClassVariabel.bLaporan = chkLaporan.Checked;
            BiayaProduksi = 0; BiayaMesin = 0; LamaProduksi = 0;
            if (JlhPerulangan > 0 && TemperaturAwal > 0)
            {
                //Passing data bahan baku
                ClassFungsi.LoadDataBahanBaku();

                N = Convert.ToInt32("0" + txtN.Text);

                //Proses simulated annealing
                ModifiedSimulatedAnnealing(JlhPerulangan, TemperaturAwal, 0.95, 2, pb1, lblKet);

                //Tampilkan solusi
                lstProduk.Items.Clear();
                for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
                {
                    ListItem = lstProduk.Items.Add(ClassVariabel.ArrProduk[i].Kode);
                    ListItem.SubItems.Add(ClassVariabel.ArrProduk[i].Nama);
                    ListItem.SubItems.Add(Convert.ToString(ClassVariabel.ArrProduk[i].BiayaProduksi));
                    ListItem.SubItems.Add(Convert.ToString(ClassVariabel.ArrBiaya[ClassFungsiBaru.ArrSolusiM[0, i], i]));
                    ListItem.SubItems.Add(Convert.ToString(ClassVariabel.ArrWaktu[ClassFungsiBaru.ArrSolusiM[0, i], i]));
                    ListItem.SubItems.Add(Convert.ToString(ClassFungsiBaru.ArrSolusiM[0, i] + 1));

                    BiayaProduksi += ClassVariabel.ArrProduk[i].BiayaProduksi;
                    BiayaMesin += ClassVariabel.ArrBiaya[ClassFungsiBaru.ArrSolusiM[0, i], i];
                    LamaProduksi += ClassVariabel.ArrWaktu[ClassFungsiBaru.ArrSolusiM[0, i], i];
                }
                if (ClassVariabel.bLaporan)
                    rtbHitung.Text = ClassVariabel.strLap;
                else
                    rtbHitung.Text = "";

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
            Selisih = EndTime - StartTime;
            lblWaktu.Text = Selisih.ToString("#,##0");

            lblTotalBiayaMesin.Text = BiayaMesin.ToString("#,##0");
            lbTotalBiayaProduksi.Text = BiayaProduksi.ToString("#,##0");
            lblTotalKeseluruhan.Text = (BiayaProduksi + BiayaMesin).ToString("#,##0");

            WaktuBersih -= LamaProduksi;
            TotalWaktu = LamaProduksi + WaktuBersih;
            lblTotalLamaProduksi.Text = LamaProduksi.ToString("#,##0");
            lblWaktuBersih.Text = WaktuBersih.ToString("#,##0");
            lblTotalWaktu.Text = TotalWaktu.ToString("#,##0");
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

        private void btnDeal_Click(object sender, EventArgs e)
        {
            int i, j;
            string SQLQuery, IDProduksi, strQuery;
            string connectionString = ClassVariabel.connectionString;
            ClassVariabel.TBahan[] ArrBahan;
            SqlConnection connection = new SqlConnection();

            ArrBahan = null;

            //Cek apakah bahan baku mencukupi atau tidak
            //Baca data formula
            for (i = 0; i < lstProduk.Items.Count; i++)
            {
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;

                strQuery = "Select COUNT(KodeBahan) From Formulasi Where KodeProduk = '" +
                           ClassVariabel.ArrProduk[i].Kode + "'";

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(strQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                        ArrBahan = new ClassVariabel.TBahan[Convert.ToInt32(reader[0])];

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();

                connection = new SqlConnection();
                connection.ConnectionString = connectionString;

                strQuery = "Select QtyProduk, F.KodeBahan, Qty " +
                           "From Formulasi F INNER JOIN Bahan B ON F.KodeBahan = B.KodeBahan Where KodeProduk = '" +
                           ClassVariabel.ArrProduk[i].Kode + "'";

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(strQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();

                    j = 0;
                    while (reader.Read())
                    {
                        ArrBahan[j].Kode = Convert.ToString(reader[1]);
                        ArrBahan[j].Qty = Convert.ToInt32(reader[2]) / Convert.ToInt32(reader[0]) * ClassVariabel.ArrProduk[i].QtyProduksi;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }

            //Save ke tabel produksi
            connection.ConnectionString = connectionString;
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    for (i = 0; i < lstProduk.Items.Count; i++)
                    {
                        IDProduksi = ClassFungsiBaru.GenerateAutoNumber("FP", "IDProduksi", "Produksi");
                        SQLQuery = "Insert Into Produksi(IDProduksi, Tanggal, KodeProduk, Qty) Values ('" +
                                   IDProduksi + "','" +
                                   DateTime.Today.ToString("yyyy/MM/dd") + "','" + lstProduk.Items[i].Text + "'," +
                                   ClassVariabel.ArrProduk[i].QtyProduksi + ")";
                        SqlCommand command = new SqlCommand(SQLQuery, connection);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        for (j = 0; j <= ArrBahan.GetUpperBound(0); j++)
                        {
                            if (ArrBahan[j].Kode != "")
                            {
                                SQLQuery = "Insert Into Produksi_Detail(IDProduksi, KodeBahan, Qty) Values ('" +
                                           IDProduksi + "','" + ArrBahan[j].Kode + "'," + ArrBahan[j].Qty + ")";
                                command = new SqlCommand(SQLQuery, connection);
                                command.CommandType = CommandType.Text;
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    btnDeal.Enabled = false;
                    MessageBox.Show("Data Produksi Tersimpan", "Simpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();

                }
                catch (SqlException expe)
                {
                    MessageBox.Show(expe.Message);
                }
            }
            else
            {
                MessageBox.Show("Data tidak tersimpan !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
