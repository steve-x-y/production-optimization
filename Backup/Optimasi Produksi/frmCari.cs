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
    public partial class frmCari : Form
    {
        public frmCari()
        {
            InitializeComponent();
        }

        private void frmCari_Load(object sender, EventArgs e)
        {
            if (string.Equals(ClassVariabel.TagForm, "Produk"))
            {
                cboCari.Items.Clear();
                cboCari.Items.Add("KodeProduk");
                cboCari.Items.Add("NamaProduk");
            }
            else if (string.Equals(ClassVariabel.TagForm, "Bahan"))
            {
                cboCari.Items.Clear();
                cboCari.Items.Add("KodeBahan");
                cboCari.Items.Add("NamaBahan");
            }
            else if (string.Equals(ClassVariabel.TagForm, "Mesin"))
            {
                cboCari.Items.Clear();
                cboCari.Items.Add("KodeMesin");
                cboCari.Items.Add("NamaMesin");
            }
            else if (string.Equals(ClassVariabel.TagForm, "Terima"))
            {
                cboCari.Items.Clear();
                cboCari.Items.Add("NoFaktur");
                cboCari.Items.Add("Tanggal");
            }
            else
            {
                cboCari.Items.Clear();
            }

            ShowAll();
        }

        void Tampil()
        {
            try
            {
                ClassVariabel.PassData = lstDaftar.Items[lstDaftar.SelectedIndices[0]].Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTampil_Click(object sender, EventArgs e)
        {
            Tampil();
        }

        private void btnSemua_Click(object sender, EventArgs e)
        {
            ShowAll();
        }

        void ShowAll()
        {
            string connectionString = ClassVariabel.connectionString;
            string strQuery;
            ListViewItem ListItem;

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            if (string.Equals(ClassVariabel.TagForm, "Produk"))
                strQuery = "Select KodeProduk, NamaProduk From Produk Order By KodeProduk";
            else if (string.Equals(ClassVariabel.TagForm, "Bahan"))
                strQuery = "Select KodeBahan, NamaBahan From Bahan Order By KodeBahan";
            else if (string.Equals(ClassVariabel.TagForm, "Mesin"))
                strQuery = "Select DISTINCT KodeMesin, NamaMesin From Mesin Order By KodeMesin";
            else if (string.Equals(ClassVariabel.TagForm, "Terima"))
                strQuery = "Select NoFaktur, Tanggal From Terima Order By NoFaktur";
            else
                strQuery = "";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                lstDaftar.Items.Clear();
                while (reader.Read())
                {
                    ListItem = lstDaftar.Items.Add(Convert.ToString(reader[0]));
                    ListItem.SubItems.Add(Convert.ToString(reader[1]));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void lstDaftar_DoubleClick(object sender, EventArgs e)
        {
            Tampil();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string connectionString = ClassVariabel.connectionString;
            string strQuery;
            ListViewItem ListItem;

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            if (string.Equals(ClassVariabel.TagForm, "Produk"))
                strQuery = "Select KodeProduk, NamaProduk From Produk Where " +
                           cboCari.Text + " LIKE '%" + txtCari.Text + "%' Order By KodeProduk";
            else if (string.Equals(ClassVariabel.TagForm, "Customer"))
                strQuery = "Select KodeBahan, NamaBahan From Bahan Where " +
                           cboCari.Text + " LIKE '%" + txtCari.Text + "%' Order By KodeBahan";
            else if (string.Equals(ClassVariabel.TagForm, "Mesin"))
                strQuery = "Select DISTINCT KodeMesin, NamaMesin From Mesin Where " +
                           cboCari.Text + " LIKE '%" + txtCari.Text + "%' Order By KodeMesin";
            else if (string.Equals(ClassVariabel.TagForm, "Terima"))
                strQuery = "Select NoFaktur, Tanggal From Terima Where " +
                           cboCari.Text + " LIKE '%" + txtCari.Text + "%' Order By NoFaktur";
            else
                strQuery = "";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                lstDaftar.Items.Clear();
                while (reader.Read())
                {
                    ListItem = lstDaftar.Items.Add(Convert.ToString(reader[0]));
                    ListItem.SubItems.Add(Convert.ToString(reader[1]));
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
}
