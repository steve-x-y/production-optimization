using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace Optimasi_Produksi
{
    public partial class frmOptimasiProduksi_Input : Form
    {
        public frmOptimasiProduksi_Input()
        {
            InitializeComponent();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvItem in lstProduk.SelectedItems)
                lvItem.Remove();
        }

        private void txtWaktuKerja_Leave(object sender, EventArgs e)
        {
            txtWaktuKerja.Text = Convert.ToDouble(txtWaktuKerja.Text).ToString("#,##0");
        }

        private void txtWaktuKerja_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ASCII = (int)e.KeyChar;
            if (ASCII == 8)
                e.KeyChar = e.KeyChar;
            else if ((ASCII < 48) || (ASCII > 57))
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtWaktuKerja_Enter(object sender, EventArgs e)
        {
            txtWaktuKerja.Text = Convert.ToString(Convert.ToDouble(txtWaktuKerja.Text));
        }

        private void txtWaktuLembur_Leave(object sender, EventArgs e)
        {
            txtWaktuLembur.Text = Convert.ToDouble(txtWaktuLembur.Text).ToString("#,##0");
        }

        private void txtWaktuLembur_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ASCII = (int)e.KeyChar;
            if (ASCII == 8)
                e.KeyChar = e.KeyChar;
            else if ((ASCII < 48) || (ASCII > 57))
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtWaktuLembur_Enter(object sender, EventArgs e)
        {
            txtWaktuLembur.Text = Convert.ToString(Convert.ToDouble(txtWaktuLembur.Text));
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            int i, j;
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            //Simpan semua data input ke memori sementara
            if ((lstProduk.Items.Count > 0) && (lstMesin.Items.Count > 0))
            {
                ClassVariabel.Ar = Convert.ToDouble(txtWaktuKerja.Text);
                ClassVariabel.Ao = Convert.ToDouble(txtWaktuLembur.Text);
                ClassVariabel.LamaMesin = Convert.ToDouble(txtWaktu.Text);

                //Data produk
                ClassVariabel.ArrProduk = new ClassVariabel.TProduk[lstProduk.Items.Count];

                for (i = 0; i <= ClassVariabel.ArrProduk.GetUpperBound(0); i++)
                {
                    ClassVariabel.ArrProduk[i].Kode = lstProduk.Items[i].Text;
                    ClassVariabel.ArrProduk[i].Nama = lstProduk.Items[i].SubItems[1].Text;
                    ClassVariabel.ArrProduk[i].Permintaan = Convert.ToInt32("0" + lstProduk.Items[i].SubItems[2].Text);
                    ClassVariabel.ArrProduk[i].SaldoAwal = Convert.ToInt32("0" + lstProduk.Items[i].SubItems[3].Text);
                    ClassVariabel.ArrProduk[i].BiayaProduksi = Convert.ToDouble("0" + lstProduk.Items[i].SubItems[4].Text);
                }

                //Data Mesin
                ClassVariabel.ArrMesin = new ClassVariabel.TMesin[lstMesin.Items.Count];

                for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
                {
                    ClassVariabel.ArrMesin[i].Kode = lstMesin.Items[i].Text;
                    ClassVariabel.ArrMesin[i].Nama = lstMesin.Items[i].SubItems[1].Text;
                }

                //Load data waktu
                ClassVariabel.ArrWaktu = new int[lstMesin.Items.Count, lstProduk.Items.Count];
                ClassVariabel.ArrBiaya = new double[lstMesin.Items.Count, lstProduk.Items.Count];

                for (i = 0; i <= ClassVariabel.ArrMesin.GetUpperBound(0); i++)
                    for (j = 0; j <= ClassVariabel.ArrProduk.GetUpperBound(0); j++)
                    {
                        //Baca data dari database
                        MySqlConnection connection = new MySqlConnection();
                        connection.ConnectionString = connectionString;

                        strQuery = "Select Biaya, Waktu From Mesin Where KodeMesin = '" + ClassVariabel.ArrMesin[i].Kode + "' AND " +
                                   "KodeProduk = '" + ClassVariabel.ArrProduk[j].Kode + "'";

                        try
                        {
                            connection.Open();
                            MySqlCommand command = new MySqlCommand(strQuery, connection);
                            command.CommandType = CommandType.Text;
                            command.ExecuteNonQuery();
                            MySqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                ClassVariabel.ArrBiaya[i, j] = Convert.ToDouble(reader[0]);
                                ClassVariabel.ArrWaktu[i, j] = Convert.ToInt16(reader[1]);
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        connection.Close();
                    }

                MessageBox.Show("Semua data telah diset ke dalam memori !", "Set Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Data Input Belum Lengkap !");
            }


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int Idx = lstProduk.SelectedIndices[0];
                Form x = new frmInputProduk();
                ClassVariabel.DataProduk.Kode = lstProduk.Items[Idx].Text;
                ClassVariabel.DataProduk.Nama = lstProduk.Items[Idx].SubItems[1].Text;
                ClassVariabel.DataProduk.Permintaan = Convert.ToInt32(lstProduk.Items[Idx].SubItems[2].Text);
                ClassVariabel.DataProduk.SaldoAwal = Convert.ToInt32(lstProduk.Items[Idx].SubItems[3].Text);
                ClassVariabel.DataProduk.BiayaProduksi = Convert.ToDouble(lstProduk.Items[Idx].SubItems[4].Text);
                x.ShowDialog();

                if (ClassVariabel.DataProduk.Kode != "")
                {
                    //Ubah data pada tabel
                    lstProduk.Items[Idx].Text = ClassVariabel.DataProduk.Kode;
                    lstProduk.Items[Idx].SubItems[1].Text = ClassVariabel.DataProduk.Nama;
                    lstProduk.Items[Idx].SubItems[2].Text = ClassVariabel.DataProduk.Permintaan.ToString("#,##0");
                    lstProduk.Items[Idx].SubItems[3].Text = ClassVariabel.DataProduk.SaldoAwal.ToString("#,##0");
                    lstProduk.Items[Idx].SubItems[4].Text = ClassVariabel.DataProduk.BiayaProduksi.ToString("#,##0");
                }
            }
            catch
            {
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Form x = new frmInputProduk();
            ClassVariabel.DataProduk.Kode = "";
            ClassVariabel.DataProduk.Nama = "";
            ClassVariabel.DataProduk.Permintaan = 0;
            ClassVariabel.DataProduk.SaldoAwal = 0;
            ClassVariabel.DataProduk.Waktu = 0;
            ClassVariabel.DataProduk.BiayaProduksi = 0;
            ClassVariabel.DataProduk.BiayaSimpan = 0;
            x.ShowDialog();

            if (ClassVariabel.DataProduk.Kode != "")
            {
                //Tambahkan ke tabel
                ListViewItem ListItem;
                ListItem = lstProduk.Items.Add(ClassVariabel.DataProduk.Kode);
                ListItem.SubItems.Add(ClassVariabel.DataProduk.Nama);
                ListItem.SubItems.Add(ClassVariabel.DataProduk.Permintaan.ToString("#,##0"));
                ListItem.SubItems.Add(ClassVariabel.DataProduk.SaldoAwal.ToString("#,##0"));
                ListItem.SubItems.Add(ClassVariabel.DataProduk.BiayaProduksi.ToString("#,##0"));
            }
        }

        private void frmOptimasiProduksi_Input_Load(object sender, EventArgs e)
        {
            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select DISTINCT KodeMesin, NamaMesin From Mesin Order By KodeMesin";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                cboKodeMesin.Items.Clear();
                while (reader.Read())
                    cboKodeMesin.Items.Add(Convert.ToString(reader[0]));

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void btnTambahMesin_Click(object sender, EventArgs e)
        {           
            if (cboKodeMesin.Text != "")
            {
                //Cek apakah mesin telah dimasukkan atau belum
                for (int i = 0; i < lstMesin.Items.Count; i++)
                {
                    if (cboKodeMesin.Text == lstMesin.Items[i].Text)
                    {
                        MessageBox.Show("Mesin telah dipilih sebelumnya !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //Tambahkan ke tabel
                ListViewItem ListItem;
                ListItem = lstMesin.Items.Add(cboKodeMesin.Text);
                ListItem.SubItems.Add(lblNamaMesin.Text);

                cboKodeMesin.Text = "";
                lblNamaMesin.Text = "";
            }
        }

        private void btnHapusMesin_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvItem in lstMesin.SelectedItems)
                lvItem.Remove();
        }

        private void cboKodeMesin_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboKodeMesin_TextChanged(sender, e);
        }

        private void cboKodeMesin_TextChanged(object sender, EventArgs e)
        {
            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select NamaMesin From Mesin Where KodeMesin = '" + cboKodeMesin.Text + "'";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    lblNamaMesin.Text = Convert.ToString(reader[0]);
                }
                else
                    lblNamaMesin.Text = "";

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void lstMesin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
