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
    public partial class frmInsert : Form
    {
        public frmInsert()
        {
            InitializeComponent();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            ClassVariabel.DataBahan.Kode = "";
            ClassVariabel.DataBahan.Nama = "";
            ClassVariabel.DataBahan.Qty = 0;
            ClassVariabel.DataBahan.Harga = 0;
            ClassVariabel.DataBahan.SubTotal = 0;

            this.Close();
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

        private void txtKodeBahan_TextChanged(object sender, EventArgs e)
        {
            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select NamaBahan, Harga " +
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
                    lblNamaBahan.Text = Convert.ToString(reader[0]);
                    txtHarga.Text = Convert.ToDouble(reader[1]).ToString("#,##0");
                    txtQty.Text = "0";                    
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();            
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            double Qty = Convert.ToDouble(txtQty.Text);

            if ((txtKodeBahan.Text != "") && (Convert.ToDouble(txtQty.Text) > 0))
            {
                //Passing data
                ClassVariabel.DataBahan.Kode = txtKodeBahan.Text;
                ClassVariabel.DataBahan.Nama = lblNamaBahan.Text;
                ClassVariabel.DataBahan.Qty = Convert.ToDouble(txtQty.Text);
                ClassVariabel.DataBahan.Harga = Convert.ToDouble(txtHarga.Text);
                ClassVariabel.DataBahan.SubTotal = Convert.ToDouble(lblSubTotal.Text);
                this.Close();
            }
        }

        private void frmInsert_Load(object sender, EventArgs e)
        {
            txtKodeBahan.Text = ClassVariabel.DataBahan.Kode;
            lblNamaBahan.Text = ClassVariabel.DataBahan.Nama;
            txtQty.Text = ClassVariabel.DataBahan.Qty.ToString("#,##0");
            txtHarga.Text = ClassVariabel.DataBahan.Harga.ToString("#,##0");
            lblSubTotal.Text = ClassVariabel.DataBahan.SubTotal.ToString("#,##0");

            if (txtKodeBahan.Text != "")
            {
                txtKodeBahan.ReadOnly = true;
                btnBrowse.Enabled = false;
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            double SubTotal;

            SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtHarga.Text);
            lblSubTotal.Text = SubTotal.ToString("#,##0");
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {
            double SubTotal;

            SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtHarga.Text);
            lblSubTotal.Text = SubTotal.ToString("#,##0");
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            txtQty.Text = Convert.ToDouble(txtQty.Text).ToString("#,##0");
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ASCII = (int)e.KeyChar;
            if (ASCII == 8)
                e.KeyChar = e.KeyChar;
            else if ((ASCII < 48) || (ASCII > 57))
            {
                e.KeyChar = Convert.ToChar(0);
            }
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            txtQty.Text = Convert.ToString(Convert.ToDouble(txtQty.Text));
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

        private void txtHarga_Leave(object sender, EventArgs e)
        {
            txtHarga.Text = Convert.ToDouble(txtHarga.Text).ToString("#,##0");
        }
    }
}
