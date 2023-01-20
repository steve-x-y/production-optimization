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
    public partial class frmProses_SA : Form
    {
        private static double WaktuBersih;

        public frmProses_SA()
        {
            InitializeComponent();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtbHitung_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            int JlhPerulangan, TemperaturAwal, i, j;
            ListViewItem ListItem;
            int StartTime, EndTime, Selisih;
            double BiayaProduksi, BiayaMesin, LamaProduksi, TotalWaktu;

            btnDeal.Enabled = true;
            StartTime = Environment.TickCount & Int32.MaxValue;

            JlhPerulangan = Convert.ToInt32(txtM.Text);
            TemperaturAwal = Convert.ToInt32(txtTemperatur.Text);

            ClassVariabel.bLaporan = chkLaporan.Checked;
            BiayaProduksi = 0; BiayaMesin = 0; LamaProduksi = 0;
            if (JlhPerulangan > 0 && TemperaturAwal > 0)
            {
                //Passing data bahan baku
                ClassFungsi.LoadDataBahanBaku();

                //Proses simulated annealing
                SimulatedAnnealing(JlhPerulangan, TemperaturAwal, 0.95, pb1, lblKet);

                //Tampilkan solusi
                lstProduk.Items.Clear();
                for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
                {
                    ListItem = lstProduk.Items.Add(ClassVariabel.ArrProduk[i].Kode);
                    ListItem.SubItems.Add(ClassVariabel.ArrProduk[i].Nama);
                    ListItem.SubItems.Add(Convert.ToString(ClassVariabel.ArrProduk[i].BiayaProduksi));
                    ListItem.SubItems.Add(Convert.ToString(ClassVariabel.ArrBiaya[ClassFungsiBaru.ArrSolusi[i], i]));
                    ListItem.SubItems.Add(Convert.ToString(ClassVariabel.ArrWaktu[ClassFungsiBaru.ArrSolusi[i], i]));
                    ListItem.SubItems.Add(Convert.ToString(ClassFungsiBaru.ArrSolusi[i] + 1));

                    BiayaProduksi += ClassVariabel.ArrProduk[i].BiayaProduksi;
                    BiayaMesin += ClassVariabel.ArrBiaya[ClassFungsiBaru.ArrSolusi[i], i];
                    LamaProduksi += ClassVariabel.ArrWaktu[ClassFungsiBaru.ArrSolusi[i], i];
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
        
        private void frmProses_SA_Load(object sender, EventArgs e)
        {

        }
        
        public static void SimulatedAnnealing(int pnM, int pnT, double pnAlpha, ProgressBar pb1, Label lblKet)
        {
            int k, i, j;
            ClassVariabel.TEnergi Fx, Fxi;
            double p, Tk = pnT, Delta, Z;
            ClassFungsiBaru.TSolusiBaru temp;

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

                        if (ClassVariabel.bLaporan)
                            ClassVariabel.strLap += "Z1 (total biaya) = " + Fx.Z1 + Environment.NewLine +
                                                    "Z2 (total waktu) = " + Fx.Z2 + Environment.NewLine + Environment.NewLine;

                        //Passing semua nilai xi ke x (x = xi);
                        for (i = 0; i <= ClassFungsiBaru.ArrSolusi.GetUpperBound(0); i++)
                        {
                            ClassFungsiBaru.ArrSolusi[i] = ClassFungsiBaru.ArrSolusiBaru[i];

                            if (ClassVariabel.bLaporan)
                                ClassVariabel.strLap += "Solusi[" + i.ToString() + "] = " + ClassFungsiBaru.ArrSolusiBaru[i].ToString() + Environment.NewLine;
                        }
                    }
                    else
                    {
                        Delta = Math.Abs(Fxi.Z1 - Fx.Z1);
                        p = Math.Exp(-Delta / pnT);

                        if (ClassVariabel.bLaporan)
                            ClassVariabel.strLap += "Hitung nilai p" + Environment.NewLine +
                                                    "Delta = " + Fxi.Z1.ToString() + " - " + Fx.Z1.ToString() + Environment.NewLine +
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
                                ClassVariabel.strLap += "p (" + p.ToString() + ") = Z (" + Fx.Z2.ToString() + ") --> benar" +
                                                        Environment.NewLine + "Set nilai f(x) = f(x')" + Environment.NewLine;

                            Fx.Z1 = Fxi.Z1;
                            Fx.Z2 = Fxi.Z2;

                            if (ClassVariabel.bLaporan)
                                ClassVariabel.strLap += "Z1 (total biaya) = " + Fx.Z1 + Environment.NewLine +
                                                        "Z2 (total waktu) = " + Fx.Z2 + Environment.NewLine + Environment.NewLine;

                            if (ClassVariabel.bLaporan)
                                ClassVariabel.strLap += "Set nilai x = x'" + Environment.NewLine;

                            //Passing semua nilai xi ke x (x = xi);
                            for (i = 0; i <= ClassFungsiBaru.ArrSolusi.GetUpperBound(0); i++)
                            {
                                ClassFungsiBaru.ArrSolusi[i] = ClassFungsiBaru.ArrSolusiBaru[i];

                                if (ClassVariabel.bLaporan)
                                    ClassVariabel.strLap += "Solusi[" + i.ToString() + "] = " + ClassFungsiBaru.ArrSolusiBaru[i].ToString() + Environment.NewLine;
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

            WaktuBersih = Fx.Z2;

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
