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
    public partial class frmTrTerima : Form
    {
        public frmTrTerima()
        {
            InitializeComponent();
        }

        private void ProcClear(bool pbAll)
        {
            if (pbAll)
            {
                txtNoFaktur.Text = "";
                txtNoFaktur.Focus();
            }
            lstBahan.Items.Clear();

            dtTanggal.Value = DateTime.Today;
            lblTotalBiaya.Text = "0";
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string SQLQuery;
            string connectionString = ClassVariabel.connectionString;
            SqlConnection connection = new SqlConnection();
            SqlCommand command;

            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    SQLQuery = "Delete From Terima Where NoFaktur = '" + txtNoFaktur.Text + "'";
                    command = new SqlCommand(SQLQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Data Terhapus !", "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException expe)
                {
                    MessageBox.Show(expe.Message);
                }
            }
            else
            {
                MessageBox.Show("Data tidak terhapus !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            int i;
            string SQLQuery;
            string connectionString = ClassVariabel.connectionString;
            SqlConnection connection = new SqlConnection();
            SqlCommand command;

            if (ClassFungsi.IsExistKode(txtNoFaktur.Text, "NoFaktur", "TrTerima"))
            {
                //Delete data sebelumnya
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    try
                    {
                        SQLQuery = "Delete From Terima Where NoFaktur = '" + txtNoFaktur.Text + "'";
                        command = new SqlCommand(SQLQuery, connection);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (SqlException expe)
                    {
                        MessageBox.Show(expe.Source);
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
                    SQLQuery = "Insert Into Terima(NoFaktur, Tanggal, Total) values('" +
                               txtNoFaktur.Text + "','" + dtTanggal.Value.ToString("yyyy/MM/dd") +
                               "'," + Convert.ToDouble(lblTotalBiaya.Text) + ")";
                    command = new SqlCommand(SQLQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();

                    for (i = 0; i < lstBahan.Items.Count; i++)
                    {
                        SQLQuery = "Insert Into TerimaD(NoFaktur, KodeBahan, Qty, Harga, SubTotal) values('" +
                                   txtNoFaktur.Text + "','" + lstBahan.Items[i].Text +
                                   "'," + lstBahan.Items[i].SubItems[2].Text + "," +
                                   Convert.ToDouble(lstBahan.Items[i].SubItems[3].Text) + "," +
                                   Convert.ToDouble(lstBahan.Items[i].SubItems[4].Text) + ")";
                        command = new SqlCommand(SQLQuery, connection);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Tersimpan !", "Simpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    ProcClear(true);
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

        private void btnBaru_Click(object sender, EventArgs e)
        {
            ProcClear(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvItem in lstBahan.SelectedItems)
                lvItem.Remove();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int Idx = lstBahan.SelectedIndices[0];
                Form x = new frmInsert();
                ClassVariabel.DataBahan.Kode = lstBahan.Items[Idx].Text;
                ClassVariabel.DataBahan.Nama = lstBahan.Items[Idx].SubItems[1].Text;
                ClassVariabel.DataBahan.Qty = Convert.ToInt32(lstBahan.Items[Idx].SubItems[2].Text);
                ClassVariabel.DataBahan.Harga = Convert.ToInt32(lstBahan.Items[Idx].SubItems[3].Text);
                ClassVariabel.DataBahan.SubTotal = Convert.ToInt32(lstBahan.Items[Idx].SubItems[4].Text);
                x.ShowDialog();

                if (ClassVariabel.DataProduk.Kode != "")
                {
                    //Ubah data pada tabel
                    lstBahan.Items[Idx].Text = ClassVariabel.DataBahan.Kode;
                    lstBahan.Items[Idx].SubItems[1].Text = ClassVariabel.DataBahan.Nama;
                    lstBahan.Items[Idx].SubItems[2].Text = ClassVariabel.DataBahan.Qty.ToString("#,##0");
                    lstBahan.Items[Idx].SubItems[3].Text = ClassVariabel.DataBahan.Harga.ToString("#,##0");
                    lstBahan.Items[Idx].SubItems[4].Text = ClassVariabel.DataBahan.SubTotal.ToString("#,##0");
                }
            }
            catch
            {
            }

            AutoSum();
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
            }

            AutoSum();
        }

        private void AutoSum()
        {
            int i;
            double Total;

            Total = 0;
            for (i = 0; i < lstBahan.Items.Count; i++)
                Total += Convert.ToDouble(lstBahan.Items[i].SubItems[4].Text);

            lblTotalBiaya.Text = Total.ToString("#,##0");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Form List = new frmCari();

            ClassVariabel.PassData = txtNoFaktur.Text;
            ClassVariabel.TagForm = "Terima";
            List.ShowDialog();
            if (ClassVariabel.PassData != "")
                txtNoFaktur.Text = ClassVariabel.PassData;
        }

        private void txtNoFaktur_TextChanged(object sender, EventArgs e)
        {
            //Baca data dari database
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            ProcClear(false);

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select Tanggal, Total From Terima Where NoFaktur = '" + txtNoFaktur.Text + "'";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dtTanggal.Value = Convert.ToDateTime(reader[0]);
                    lblTotalBiaya.Text = Convert.ToDouble(reader[1]).ToString("#,##0");
                }
                else
                {
                    dtTanggal.Value = DateTime.Today;
                    lblTotalBiaya.Text = "";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

            //Load data penerimaan bahan baku yang tersimpan
            if (lblTotalBiaya.Text != "")
            {
                ListViewItem ListItem;
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;

                strQuery = "Select D.KodeBahan, NamaBahan, Qty, D.Harga, SubTotal " +
                           "From TerimaD D INNER JOIN Bahan B ON D.KodeBahan = B.KodeBahan Where NoFaktur = '" +
                           txtNoFaktur.Text + "'";

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(strQuery, connection);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListItem = lstBahan.Items.Add(Convert.ToString(reader[0]));
                        ListItem.SubItems.Add(Convert.ToString(reader[1]));
                        ListItem.SubItems.Add(Convert.ToInt32(reader[2]).ToString("#,##0"));
                        ListItem.SubItems.Add(Convert.ToDouble(reader[3]).ToString("#,##0"));
                        ListItem.SubItems.Add(Convert.ToDouble(reader[4]).ToString("#,##0"));
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
}
