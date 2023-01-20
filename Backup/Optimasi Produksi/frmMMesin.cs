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
    public partial class frmMMesin : Form
    {
        public frmMMesin()
        {
            InitializeComponent();
        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            Clear(true);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            int i;
            string SQLQuery;
            string connectionString = ClassVariabel.connectionString;
            SqlConnection connection = new SqlConnection();
            SqlCommand command;

            if (ClassFungsi.IsExistKode(txtKodeMesin.Text, "KodeMesin", "Mesin"))
            {
                //Delete data sebelumnya
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    try
                    {
                        SQLQuery = "Delete From Mesin Where KodeMesin = '" + txtKodeMesin.Text + "'";
                        command = new SqlCommand(SQLQuery, connection);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
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
                    return;
                }
            }

            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    for (i = 0; i < lstBiaya.Items.Count; i++)
                    {

                        SQLQuery = "Insert Into Mesin(KodeMesin, NamaMesin, KodeProduk, Biaya, Waktu) values('" +
                                   txtKodeMesin.Text + "','" + txtNamaMesin.Text + "','" + lstBiaya.Items[i].Text + "'," +
                                   Convert.ToDouble(lstBiaya.Items[i].SubItems[2].Text) + "," +
                                   Convert.ToDouble(lstBiaya.Items[i].SubItems[3].Text) + ")";
                        command = new SqlCommand(SQLQuery, connection);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Tersimpan !", "Simpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    Clear(true);
                }
                catch (SqlException expe)
                {
                    connection.Close();
                    MessageBox.Show(expe.Message);
                }
            }
            else
            {
                MessageBox.Show("Data tidak tersimpan !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string SQLQuery;

            if (txtKodeMesin.Text == "")
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
                    SQLQuery = "Delete From Mesin Where KodeMesin = '" + txtKodeMesin.Text + "'";
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

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Clear(Boolean pbAll)
        {
            if (pbAll)
            {
                txtKodeMesin.Text = "";
                txtKodeMesin.Focus();
            }
            txtNamaMesin.Text = "";
            lstBiaya.Items.Clear();

            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;
            ListViewItem ListItem;

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select KodeProduk, NamaProduk From Produk Order By KodeProduk";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListItem = lstBiaya.Items.Add(Convert.ToString(reader[0]));
                    ListItem.SubItems.Add(Convert.ToString(reader[1]));
                    ListItem.SubItems.Add("0");
                    ListItem.SubItems.Add("0");
                }

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

            ClassVariabel.PassData = txtKodeMesin.Text;
            ClassVariabel.TagForm = "Mesin";
            List.ShowDialog();
            if (ClassVariabel.PassData != "")
                txtKodeMesin.Text = ClassVariabel.PassData;
        }

        private void txtKodeMesin_TextChanged(object sender, EventArgs e)
        {
            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;
            ListViewItem ListItem;

            Clear(false);

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select KodeMesin, NamaMesin, M.KodeProduk, P.NamaProduk, Biaya, Waktu From Mesin M " +
                       "INNER JOIN Produk P ON M.KodeProduk = P.KodeProduk Where KodeMesin = '" + txtKodeMesin.Text + "'";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    lstBiaya.Items.Clear();
                    txtNamaMesin.Text = Convert.ToString(reader[1]);
                    ListItem = lstBiaya.Items.Add(Convert.ToString(reader[2]));
                    ListItem.SubItems.Add(Convert.ToString(reader[3]));
                    ListItem.SubItems.Add(Convert.ToDouble(reader[4]).ToString("#,##0"));
                    ListItem.SubItems.Add(Convert.ToDouble(reader[5]).ToString("#,##0"));

                    while (reader.Read())
                    {
                        ListItem = lstBiaya.Items.Add(Convert.ToString(reader[2]));
                        ListItem.SubItems.Add(Convert.ToString(reader[3]));
                        ListItem.SubItems.Add(Convert.ToDouble(reader[4]).ToString("#,##0"));
                        ListItem.SubItems.Add(Convert.ToDouble(reader[5]).ToString("#,##0"));
                    }
                }
                else
                    Clear(false);

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void lstBiaya_DoubleClick(object sender, EventArgs e)
        {
            int Indeks;
            InputBoxResult cInput;

            Indeks = lstBiaya.SelectedIndices[0];

            cInput = InputBox.Show("Biaya untuk Produk " + lstBiaya.Items[Indeks].Text, "Input Data Biaya",
                                   lstBiaya.Items[Indeks].SubItems[2].Text, new InputBoxValidatingHandler(inputBox_Validating));

            if (cInput.OK)
            {
                lstBiaya.Items[Indeks].SubItems[2].Text = cInput.Text;
            }

            cInput = InputBox.Show("Lama Pembuatan untuk Produk " + lstBiaya.Items[Indeks].Text, "Input Data Waktu",
                                   lstBiaya.Items[Indeks].SubItems[3].Text, new InputBoxValidatingHandler(inputBox_Validating));

            if (cInput.OK)
            {
                lstBiaya.Items[Indeks].SubItems[3].Text = cInput.Text;
            }
        }

        private void inputBox_Validating(object sender, InputBoxValidatingArgs e)
        {
            if (e.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                e.Message = "Required";
            }
        }

        private void lstBiaya_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmMMesin_Load(object sender, EventArgs e)
        {
            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;
            ListViewItem ListItem;

            Clear(false);

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select KodeProduk, NamaProduk From Produk Order By KodeProduk";
            lstBiaya.Items.Clear();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListItem = lstBiaya.Items.Add(Convert.ToString(reader[0]));
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
