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
    public partial class frmInputProduk : Form
    {
        public frmInputProduk()
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

            SqlCommand command;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select NamaProduk, BiayaSimpan, SaldoAwal " +
                       "From Produk Where KodeProduk = '" + txtKodeProduk.Text + "'";

            try
            {
                connection.Open();
                command = new SqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    lblNamaProduk.Text = Convert.ToString(reader[0]);
                    lblBiayaSimpan.Text = Convert.ToDouble(reader[1]).ToString("#,##0");
                    txtSaldoAwal.Text = Convert.ToDouble(reader[2]).ToString("#,##0");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

            if (lblNamaProduk.Text != "")
            {
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;

                strQuery = "Select Waktu, BiayaProduksi " +
                           "From Formulasi Where KodeProduk = '" + txtKodeProduk.Text + "'";

                try
                {
                    connection.Open();
                    command = new SqlCommand(strQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    SqlDataReader reader1 = command.ExecuteReader();

                    if (reader1.Read())
                    {
                        lblWaktuProduksi.Text = Convert.ToDouble(reader1[0]).ToString("#,##0");
                        lblBiayaProduksi.Text = Convert.ToDouble(reader1[1]).ToString("#,##0");
                    }

                    reader1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }

        }

        private void frmInputProduk_Load(object sender, EventArgs e)
        {
            //Data awal (edit)
            txtKodeProduk.Text = ClassVariabel.DataProduk.Kode;
            lblNamaProduk.Text = ClassVariabel.DataProduk.Nama;
            txtPermintaan.Text = ClassVariabel.DataProduk.Permintaan.ToString("#,##0");
            txtSaldoAwal.Text = ClassVariabel.DataProduk.SaldoAwal.ToString("#,##0");
            lblWaktuProduksi.Text = ClassVariabel.DataProduk.Waktu.ToString("#,##0");
            lblBiayaProduksi.Text = ClassVariabel.DataProduk.BiayaProduksi.ToString("#,##0");
            lblBiayaSimpan.Text = ClassVariabel.DataProduk.BiayaSimpan.ToString("#,##0");

            if (txtKodeProduk.Text != "")
            {
                txtKodeProduk.ReadOnly = true;
                btnBrowse.Enabled = false;
            }
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            //Passing data
            if (txtKodeProduk.Text != "")
            {
                ClassVariabel.DataProduk.Kode = txtKodeProduk.Text;
                ClassVariabel.DataProduk.Nama = lblNamaProduk.Text;
                ClassVariabel.DataProduk.Permintaan = Convert.ToInt32(txtPermintaan.Text);
                ClassVariabel.DataProduk.SaldoAwal = Convert.ToInt32(txtSaldoAwal.Text);
                ClassVariabel.DataProduk.Waktu = Convert.ToInt32(lblWaktuProduksi.Text);
                ClassVariabel.DataProduk.BiayaProduksi = Convert.ToDouble(lblBiayaProduksi.Text);
                ClassVariabel.DataProduk.BiayaSimpan = Convert.ToDouble(lblBiayaSimpan.Text);
                this.Close();
            }
        }

        private void txtPermintaan_Leave(object sender, EventArgs e)
        {
            txtPermintaan.Text = Convert.ToDouble(txtPermintaan.Text).ToString("#,##0");
        }

        private void txtPermintaan_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ASCII = (int)e.KeyChar;
            if (ASCII == 8)
                e.KeyChar = e.KeyChar;
            else if ((ASCII < 48) || (ASCII > 57))
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtPermintaan_Enter(object sender, EventArgs e)
        {
            txtPermintaan.Text = Convert.ToString(Convert.ToDouble(txtPermintaan.Text));
        }

        private void txtSaldoAwal_Leave(object sender, EventArgs e)
        {
            txtSaldoAwal.Text = Convert.ToDouble(txtSaldoAwal.Text).ToString("#,##0");
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

        private void txtSaldoAwal_Enter(object sender, EventArgs e)
        {
            txtSaldoAwal.Text = Convert.ToString(Convert.ToDouble(txtSaldoAwal.Text));
        }

    }
}
