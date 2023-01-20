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
    public partial class frmMBahan : Form
    {
        public frmMBahan()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Form List = new frmCari();

            ClassVariabel.PassData = txtKodeBahan.Text;
            ClassVariabel.TagForm = "Bahan";
            List.ShowDialog();
            if (ClassVariabel.PassData != "")
                txtKodeBahan.Text = ClassVariabel.PassData;
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string SQLQuery;

            if (txtKodeBahan.Text == "")
            {
                MessageBox.Show("Tidak ada data untuk dihapus !", "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string connectionString = ClassVariabel.connectionString;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    SQLQuery = "Delete From Bahan Where KodeBahan = '" + txtKodeBahan.Text + "'";
                    SqlCommand command = new SqlCommand(SQLQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data Terhapus", "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    Clear(true);
                }
                catch (SqlException expe)
                {
                    MessageBox.Show(expe.Message);
                }
            }
            else
            {
                MessageBox.Show("Data tidak terhapus !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string SQLQuery;
            string connectionString = ClassVariabel.connectionString;
            SqlConnection connection = new SqlConnection();

            if (ClassFungsi.IsExistKode(txtKodeBahan.Text, "KodeBahan", "Bahan"))
            {
                //Sudah ada data --> Update
                connection.ConnectionString = connectionString;
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    try
                    {
                        SQLQuery = "Update Bahan SET NamaBahan = '" + txtNamaBahan.Text + "', " +
                                   "Satuan = '" + cboSatuan.Text + "', " +
                                   "Jenis = '" + cboJenis.Text + "', " +
                                   "Harga = " + Convert.ToDouble("0" + txtHarga.Text) + "," +
                                   "BiayaSimpan = " + Convert.ToDouble("0" + txtBiayaSimpan.Text) + "," +
                                   "SaldoAwal = " + Convert.ToInt32("0" + txtSaldoAwal.Text) + " " +
                                   "Where KodeBahan = '" + txtKodeBahan.Text + "'";
                        SqlCommand command = new SqlCommand(SQLQuery, connection);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data Ter-Update", "Simpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        Clear(true);
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
            else
            {
                //Belum ada data --> Insert
                connection.ConnectionString = connectionString;
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    try
                    {
                        SQLQuery = "Insert Into Bahan(KodeBahan, NamaBahan, Satuan, Jenis, Harga, BiayaSimpan, SaldoAwal) Values ('" +
                                    txtKodeBahan.Text + "','" + txtNamaBahan.Text + "','" +
                                    cboSatuan.Text + "','" + cboJenis.Text + "'," +
                                    Convert.ToDouble("0" + txtHarga.Text) + "," + Convert.ToDouble("0" + txtBiayaSimpan.Text) + "," +
                                    Convert.ToInt32("0" + txtSaldoAwal.Text)  + ")";
                        SqlCommand command = new SqlCommand(SQLQuery, connection);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data Tersimpan", "Simpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        Clear(true);
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

        private void btnBaru_Click(object sender, EventArgs e)
        {
            Clear(true);
        }

        void Clear(Boolean pbAll)
        {
            if (pbAll)            
            {
                txtKodeBahan.Text = "";
                txtKodeBahan.Focus();
            }
            txtNamaBahan.Text = "";
            cboSatuan.SelectedIndex = 0;
            cboJenis.Text = "";
            txtHarga.Text = "0";
            txtBiayaSimpan.Text = "0";
            txtSaldoAwal.Text = "0";
        }

        private void txtKodeBahan_TextChanged(object sender, EventArgs e)
        {
            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            Clear(false);

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select NamaBahan, Satuan, Jenis, Harga, BiayaSimpan, SaldoAwal " +
                       "From Bahan Where KodeBahan = '" + txtKodeBahan.Text + "'";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtNamaBahan.Text = Convert.ToString(reader[0]);
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

        private void txtHarga_Leave(object sender, EventArgs e)
        {
            txtHarga.Text = Convert.ToDouble(txtHarga.Text).ToString("#,##0");
        }

        private void txtHarga_Enter(object sender, EventArgs e)
        {
            txtHarga.Text = Convert.ToString(Convert.ToDouble(txtHarga.Text));
        }

        private void txtBiayaSimpan_Leave(object sender, EventArgs e)
        {
            txtBiayaSimpan.Text = Convert.ToDouble(txtBiayaSimpan.Text).ToString("#,##0");
        }

        private void txtBiayaSimpan_Enter(object sender, EventArgs e)
        {
            txtBiayaSimpan.Text = Convert.ToString(Convert.ToDouble(txtBiayaSimpan.Text));
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

        private void txtSaldoAwal_Leave(object sender, EventArgs e)
        {
            txtSaldoAwal.Text = Convert.ToDouble(txtSaldoAwal.Text).ToString("#,##0");
        }

        private void txtSaldoAwal_Enter(object sender, EventArgs e)
        {
            txtSaldoAwal.Text = Convert.ToString(Convert.ToDouble(txtSaldoAwal.Text));
        }

        private void frmMBahan_Load(object sender, EventArgs e)
        {
            Clear(true);
        }

    }
}
