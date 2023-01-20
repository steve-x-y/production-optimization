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
    public partial class frmMProduk : Form
    {
        public frmMProduk()
        {
            InitializeComponent();
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

        private void txtKodeProduk_TextChanged(object sender, EventArgs e)
        {
            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            Clear(false);

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select NamaProduk, Satuan, Jenis, Harga, BiayaSimpan, SaldoAwal " +
                       "From Produk Where KodeProduk = '" + txtKodeProduk.Text + "'";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtNamaProduk.Text = Convert.ToString(reader[0]);
                    cboSatuan.Text = Convert.ToString(reader[1]);
                    cboJenis.Text = Convert.ToString(reader[2]);
                    txtHarga.Text = Convert.ToDouble(reader[3]).ToString("#,##0");
                    txtBiayaSimpan.Text = Convert.ToDouble(reader[4]).ToString("#,##0");
                    txtSaldoAwal.Text = Convert.ToDouble(reader[5]).ToString("#,##0");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        void Clear(Boolean pbAll)
        {
            if (pbAll)
            {
                txtKodeProduk.Text = "";
                txtKodeProduk.Focus();
            }
            txtNamaProduk.Text = "";
            cboSatuan.SelectedIndex = 0;
            cboJenis.Text = "";
            txtHarga.Text = "0";
            txtBiayaSimpan.Text = "0";
            txtSaldoAwal.Text = "0";
        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            Clear(true);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string SQLQuery;
            string connectionString = ClassVariabel.connectionString;
            MySqlConnection connection = new MySqlConnection();

            if (ClassFungsi.IsExistKode(txtKodeProduk.Text, "KodeProduk", "Produk"))
            {
                //Sudah ada data --> Update
                connection.ConnectionString = connectionString;
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    try
                    {
                        SQLQuery = "Update Produk SET NamaProduk = '" + txtNamaProduk.Text + "', " +
                                   "Satuan = '" + cboSatuan.Text + "', " +
                                   "Jenis = '" + cboJenis.Text + "', " +
                                   "Harga = " + Convert.ToDouble("0" + txtHarga.Text) + "," +
                                   "BiayaSimpan = " + Convert.ToDouble("0" + txtBiayaSimpan.Text) + "," +
                                   "SaldoAwal = " + Convert.ToDouble("0" + txtSaldoAwal.Text) + " " +
                                   "Where KodeProduk = '" + txtKodeProduk.Text + "'";
                        MySqlCommand command = new MySqlCommand(SQLQuery, connection);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data Ter-Update", "Simpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Data tidak tersimpan !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Belum ada data --> Insert
                connection.ConnectionString = connectionString;
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    try
                    {
                        SQLQuery = "Insert Into Produk(KodeProduk, NamaProduk, Satuan, Jenis, Harga, BiayaSimpan, SaldoAwal) Values ('" +
                                    txtKodeProduk.Text + "','" + txtNamaProduk.Text + "','" +
                                    cboSatuan.Text + "','" + cboJenis.Text + "'," +
                                    Convert.ToDouble("0" + txtHarga.Text) + "," + Convert.ToDouble("0" + txtBiayaSimpan.Text) +
                                    "," + Convert.ToDouble("0" + txtSaldoAwal.Text) + ")";
                        MySqlCommand command = new MySqlCommand(SQLQuery, connection);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data Tersimpan", "Simpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Data tidak tersimpan !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    SQLQuery = "Delete From Produk Where KodeProduk = '" + txtKodeProduk.Text + "'";
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

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMProduk_Load(object sender, EventArgs e)
        {

        }

        private void txtHarga_Leave(object sender, EventArgs e)
        {
            txtHarga.Text = Convert.ToDouble(txtHarga.Text).ToString("#,##0");
        }

        private void txtHarga_Enter(object sender, EventArgs e)
        {
            txtHarga.Text = Convert.ToString(Convert.ToDouble(txtHarga.Text));
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ASCII = (int)e.KeyChar;
            if (ASCII == 8)
                e.KeyChar = e.KeyChar;
            else if ((ASCII < 48) || (ASCII > 57))
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtBiayaSimpan_Leave(object sender, EventArgs e)
        {
            txtBiayaSimpan.Text = Convert.ToDouble(txtBiayaSimpan.Text).ToString("#,##0");
        }

        private void txtBiayaSimpan_Enter(object sender, EventArgs e)
        {
            txtBiayaSimpan.Text = Convert.ToString(Convert.ToDouble(txtBiayaSimpan.Text));
        }

        private void txtBiayaSimpan_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ASCII = (int)e.KeyChar;
            if (ASCII == 8)
                e.KeyChar = e.KeyChar;
            else if ((ASCII < 48) || (ASCII > 57))
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtSaldoAwal_Leave(object sender, EventArgs e)
        {
            txtSaldoAwal.Text = Convert.ToDouble(txtSaldoAwal.Text).ToString("#,##0");
        }

        private void txtSaldoAwal_Enter(object sender, EventArgs e)
        {
            txtSaldoAwal.Text = Convert.ToString(Convert.ToDouble(txtSaldoAwal.Text));
        }

        private void txtSaldoAwal_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ASCII = (int)e.KeyChar;
            if (ASCII == 8)
                e.KeyChar = e.KeyChar;
            else if ((ASCII < 48) || (ASCII > 57))
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }
    }
}
