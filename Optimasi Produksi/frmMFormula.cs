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
    public partial class frmMFormula : Form
    {
        public frmMFormula()
        {
            InitializeComponent();
        }

        void Clear(Boolean pbAll)
        {
            if (pbAll)
            {
                txtKodeProduk.Text = "";
                txtKodeProduk.Focus();
            }
            lblNamaProduk.Text = "";
            lstBahan.Items.Clear();
            lblTotalBiaya.Text = "0";
            txtQtyHasil.Text = "0";
            lblBiayaProduksi.Text = "0";
            txtWaktu.Text = "0";
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            Clear(true);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            //Hapus data sebelumnya
            string SQLQuery;
            string connectionString = ClassVariabel.connectionString;
            MySqlCommand command;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    SQLQuery = "Delete From Formulasi Where KodeProduk = '" + txtKodeProduk.Text + "'";
                    command = new MySqlCommand(SQLQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (MySqlException expe)
                {
                    MessageBox.Show(expe.Source);
                }
            }
            else
            {
                MessageBox.Show("Data tidak tersimpan !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            for (int nD = 0; nD < lstBahan.Items.Count; nD++)
            {
                if (lstBahan.Items[nD].Text != "")
                {
                    connection = new MySqlConnection();
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SQLQuery = "Insert Into Formulasi(KodeProduk, QtyProduk, TotalBiaya, BiayaProduksi, Waktu, " +
                             "KodeBahan, Qty, Harga) Values ('" +
                             txtKodeProduk.Text + "'," + Convert.ToInt32(txtQtyHasil.Text) + "," + 
                             Convert.ToDouble(lblTotalBiaya.Text) + "," +
                             Convert.ToDouble(lblBiayaProduksi.Text) + "," + Convert.ToDouble(txtWaktu.Text) + ",'" +
                             lstBahan.Items[nD].Text + "'," +
                             Convert.ToString(Convert.ToDouble(lstBahan.Items[nD].SubItems[2].Text)) + "," + 
                             Convert.ToString(Convert.ToDouble(lstBahan.Items[nD].SubItems[3].Text)) + ")";

                    command = new MySqlCommand(SQLQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            MessageBox.Show("Data Tersimpan", "Simpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear(true);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string SQLQuery;

            if (txtKodeProduk.Text == "")
            {
                MessageBox.Show("Tidak ada data untuk dihapus !", "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string connectionString = ClassVariabel.connectionString;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    SQLQuery = "Delete From Formulasi Where KodeProduk = '" + txtKodeProduk.Text + "'";
                    MySqlCommand command = new MySqlCommand(SQLQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data Terhapus", "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    Clear(true);
                }
                catch (MySqlException expe)
                {
                    MessageBox.Show(expe.Message);
                }
            }
            else
            {
                MessageBox.Show("Data tidak terhapus !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvItem in lstBahan.SelectedItems)
                lvItem.Remove();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Form x = new frmInsert();
            ClassVariabel.DataBahan.Kode = "";
            ClassVariabel.DataBahan.Nama = "";
            ClassVariabel.DataBahan.Qty = 0;
            ClassVariabel.DataBahan.Harga = 0;
            ClassVariabel.DataBahan.SubTotal = 0;
            x.ShowDialog();

            if (ClassVariabel.DataBahan.Kode != "")
            {
                //Tambahkan ke tabel
                ListViewItem ListItem;
                ListItem = lstBahan.Items.Add(ClassVariabel.DataBahan.Kode);
                ListItem.SubItems.Add(ClassVariabel.DataBahan.Nama);
                ListItem.SubItems.Add(ClassVariabel.DataBahan.Qty.ToString("#,##0"));
                ListItem.SubItems.Add(ClassVariabel.DataBahan.Harga.ToString("#,##0"));
                ListItem.SubItems.Add(ClassVariabel.DataBahan.SubTotal.ToString("#,##0"));
                AutoSum();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int Idx = lstBahan.SelectedIndices[0];
            Form x = new frmInsert();
            ClassVariabel.DataBahan.Kode = lstBahan.Items[lstBahan.SelectedIndices[0]].Text;
            ClassVariabel.DataBahan.Nama = lstBahan.Items[lstBahan.SelectedIndices[0]].SubItems[1].Text;
            ClassVariabel.DataBahan.Qty = Convert.ToInt32(lstBahan.Items[lstBahan.SelectedIndices[0]].SubItems[2].Text);
            ClassVariabel.DataBahan.Harga = Convert.ToDouble(lstBahan.Items[lstBahan.SelectedIndices[0]].SubItems[3].Text);
            ClassVariabel.DataBahan.SubTotal = Convert.ToDouble(lstBahan.Items[lstBahan.SelectedIndices[0]].SubItems[4].Text);
            x.ShowDialog();

            if (ClassVariabel.DataBahan.Kode != "")
            {
                //Ubah data pada tabel
                lstBahan.Items[Idx].Text = ClassVariabel.DataBahan.Kode;
                lstBahan.Items[Idx].SubItems[1].Text = ClassVariabel.DataBahan.Nama;
                lstBahan.Items[Idx].SubItems[2].Text = ClassVariabel.DataBahan.Qty.ToString("#,##0");
                lstBahan.Items[Idx].SubItems[3].Text = ClassVariabel.DataBahan.Harga.ToString("#,##0");
                lstBahan.Items[Idx].SubItems[4].Text = ClassVariabel.DataBahan.SubTotal.ToString("#,##0");
                AutoSum();
            }
        }

        private void AutoSum()
        {
            int i;
            double TotalBiaya;

            TotalBiaya = 0;
            for (i = 0; i <= lstBahan.Items.Count - 1; i++)
                TotalBiaya += Convert.ToDouble(lstBahan.Items[i].SubItems[4].Text);

            lblTotalBiaya.Text = TotalBiaya.ToString("#,##0");
            if (Convert.ToInt32(txtQtyHasil.Text) > 0)
                lblBiayaProduksi.Text = (TotalBiaya / Convert.ToDouble(txtQtyHasil.Text)).ToString("#,##0");
            else
                lblBiayaProduksi.Text = "0";
        }

        private void txtKodeProduk_TextChanged(object sender, EventArgs e)
        {
            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            Clear(false);

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select NamaProduk From Produk Where KodeProduk = '" + txtKodeProduk.Text + "'";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    lblNamaProduk.Text = Convert.ToString(reader[0]);
                else
                    lblNamaProduk.Text = "";

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

            //Load data formulasi yang tersimpan
            if (lblNamaProduk.Text != "")
            {
                ListViewItem ListItem;
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;

                strQuery = "Select QtyProduk, TotalBiaya, BiayaProduksi, Waktu, F.KodeBahan, NamaBahan, Qty, F.Harga, Qty * F.Harga " +
                           "From Formulasi F INNER JOIN Bahan B ON F.KodeBahan = B.KodeBahan Where KodeProduk = '" + 
                           txtKodeProduk.Text + "'";

                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(strQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtQtyHasil.Text = Convert.ToInt32(reader[0]).ToString("#,##0");
                        lblTotalBiaya.Text = Convert.ToInt32(reader[1]).ToString("#,##0");
                        lblBiayaProduksi.Text = Convert.ToInt32(reader[2]).ToString("#,##0");
                        txtWaktu.Text = Convert.ToInt32(reader[3]).ToString("#,##0");

                        ListItem = lstBahan.Items.Add(Convert.ToString(reader[4]));
                        ListItem.SubItems.Add(Convert.ToString(reader[5]));
                        ListItem.SubItems.Add(Convert.ToInt32(reader[6]).ToString("#,##0"));
                        ListItem.SubItems.Add(Convert.ToDouble(reader[7]).ToString("#,##0"));
                        ListItem.SubItems.Add(Convert.ToDouble(reader[8]).ToString("#,##0"));

                        while (reader.Read())
                        {
                            ListItem = lstBahan.Items.Add(Convert.ToString(reader[4]));
                            ListItem.SubItems.Add(Convert.ToString(reader[5]));
                            ListItem.SubItems.Add(Convert.ToInt32(reader[6]).ToString("#,##0"));
                            ListItem.SubItems.Add(Convert.ToDouble(reader[7]).ToString("#,##0"));
                            ListItem.SubItems.Add(Convert.ToDouble(reader[8]).ToString("#,##0"));
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Form List = new frmCari();

            ClassVariabel.PassData = txtKodeProduk.Text;
            ClassVariabel.TagForm = "Produk";
            List.ShowDialog();
            if (ClassVariabel.PassData != "")
                txtKodeProduk.Text = ClassVariabel.PassData;
        }

        private void txtQtyHasil_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ASCII = (int)e.KeyChar;
            if (ASCII == 8)
                e.KeyChar = e.KeyChar;
            else if ((ASCII < 48) || (ASCII > 57))
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtQtyHasil_Leave(object sender, EventArgs e)
        {
            txtQtyHasil.Text = Convert.ToDouble(txtQtyHasil.Text).ToString("#,##0");
        }

        private void txtQtyHasil_Enter(object sender, EventArgs e)
        {
            txtQtyHasil.Text = Convert.ToString(Convert.ToDouble(txtQtyHasil.Text));
        }

        private void txtWaktu_Enter(object sender, EventArgs e)
        {
            txtWaktu.Text = Convert.ToString(Convert.ToDouble(txtWaktu.Text));
        }

        private void txtWaktu_Leave(object sender, EventArgs e)
        {
            txtWaktu.Text = Convert.ToDouble(txtWaktu.Text).ToString("#,##0");
        }

        private void txtWaktu_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ASCII = (int)e.KeyChar;
            if (ASCII == 8)
                e.KeyChar = e.KeyChar;
            else if ((ASCII < 48) || (ASCII > 57))
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtQtyHasil_TextChanged(object sender, EventArgs e)
        {
            AutoSum();
        }
    }
}
