using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Optimasi_Produksi
{
    public partial class frmLaporan : Form
    {
        public frmLaporan()
        {
            InitializeComponent();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            //Form c = new frmCetak();

            //ClassVariabel.cF = "Select Tipe, NoFaktur, Tanggal as TglFaktur, '' as KodeCust, '' as NamaCust, " +
            //                   " V.KodeBahan as KodeBarang, NamaBahan as NamaBarang, Qty, 0 as Harga, " +
            //                   " 0 as SubTotal, '" + dtPeriode.Value.ToString("MMM-yyyy") + "' AS Periode From " +
            //                   " VBahan V INNER JOIN Bahan B ON V.KodeBahan = B.KodeBahan Where Tanggal <= '" +
            //                   dtPeriode.Value.Year + "/" + (dtPeriode.Value.Month + 1) + "/01'";

            //c.Text = "Laporan Kartu Stock";
            //c.ShowDialog();
        }
    }
}
