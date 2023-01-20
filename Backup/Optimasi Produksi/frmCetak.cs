using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Optimasi_Produksi
{
    public partial class frmCetak : Form
    {
        OleDbConnection conect = new OleDbConnection(ClassVariabel.connectionStringReport);
        OleDbConnection objConnection = new OleDbConnection();
        OleDbCommand objCommand = new OleDbCommand();
        OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();

        //OleDbDataReader objdatareader ;
        string strSQL;
        DataSet objDataSet = new DataSet();
        DataTable objDataTable = new DataTable();
        
        public frmCetak()
        {
            InitializeComponent();
        }

        void ViewReport(string StringSQL)
        {
            string strTableName = "Tabel";

            conect.Open();
            objDataTable.Clear();
            strSQL = StringSQL;
            OleDbCommand objCommand = new OleDbCommand();
            objCommand.Connection = conect;
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = strSQL;
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter(objCommand);
            objDataAdapter.Fill(objDataSet, strTableName);
            conect.Close();
            objDataTable = objDataSet.Tables[strTableName];
        }

        private void frmCetak_Load(object sender, EventArgs e)
        {
            ViewReport(ClassVariabel.cF);

            RepKartuStok rdReport = new RepKartuStok();
            rdReport.SetDataSource(objDataTable);
            this.CR1.ReportSource = rdReport;
            rdReport.Refresh();
        }
    

    }
}
