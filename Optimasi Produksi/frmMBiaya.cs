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
    public partial class frmMBiaya : Form
    {
        public frmMBiaya()
        {
            InitializeComponent();
        }

        private void txtKodeProduk_TextChanged(object sender, EventArgs e)
        {
            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            Clear(false);

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select NamaProduk From Produk Where KodeProduk = '" + txtKodeProduk.Text + "'";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

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
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Form List = new frmCari();

            ClassVariabel.PassData = txtKodeProduk.Text;
            ClassVariabel.TagForm = "Bahan";
            List.ShowDialog();
            if (ClassVariabel.PassData != "")
                txtKodeProduk.Text = ClassVariabel.PassData;
        }

        void Clear(Boolean pbAll)
        {
            if (pbAll)
            {
                txtKodeProduk.Text = "";
                txtKodeProduk.Focus();
            }
            lblNamaProduk.Text = "";
            lstBiaya.Items.Clear();
            lblTotalBiaya.Text = "";
        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            Clear(true);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {

        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }
    }
}
