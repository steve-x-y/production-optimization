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
using MySql;
using MySql.Data.MySqlClient;

namespace Optimasi_Produksi
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = ClassVariabel.connectionString;
            string strQuery;

            MySqlConnection connection = new MySqlConnection();
           // MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            strQuery = "Select NamaUser, TipeUser From DataUser Where NamaUser = '" + txtUser.Text + "' AND Password = '" + txtPwd.Text + "'";

            try
            {
                connection.Open();
//                MySqlCommand command = new MySqlCommand(strQuery, connection);
                MySqlCommand command = new MySqlCommand(strQuery, connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                //                MySqlDataReader reader = command.ExecuteReader();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ClassVariabel.TipeUser = Convert.ToInt16(reader[1]);

                    this.Hide();
                    Form x = new frmMain();
                    x.ShowDialog();
                }
                else
                {
                    MessageBox.Show("User ID atau password anda salah !", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
