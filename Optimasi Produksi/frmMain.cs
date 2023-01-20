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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void dataBahanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new frmMBahan();
            x.MdiParent = this;
            x.BringToFront();
            x.Show();
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new frmMProduk();
            x.MdiParent = this;
            x.BringToFront();
            x.Show();
        }

        private void dataFormulasiProduksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new frmMFormula();
            x.MdiParent = this;
            x.BringToFront();
            x.Show();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingKeadaanAwalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new frmOptimasiProduksi_Input();
            x.MdiParent = this;
            x.BringToFront();
            x.Show();
        }

        private void simulatedAnnealingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new frmProses_SA();
            x.MdiParent = this;
            x.BringToFront();
            x.Show();
        }

        private void modifiedSimulatedAnnealingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new frmProses_MSA();
            x.MdiParent = this;
            x.BringToFront();
            x.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form x = new frmLogin();
            x.Show();
        }

        private void penerimaanBahanBakuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new frmTrTerima();
            x.MdiParent = this;
            x.BringToFront();
            x.Show();
        }

        private void dataMesinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new frmMMesin();
            x.MdiParent = this;
            x.BringToFront();
            x.Show();
        }

        private void perbandinganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new frmPerbandingan();
            x.MdiParent = this;
            x.BringToFront();
            x.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {


        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            dataUtamaToolStripMenuItem.Visible = false;
            dataBahanToolStripMenuItem.Visible = false;
            dataToolStripMenuItem.Visible = false;
            dataFormulasiProduksiToolStripMenuItem.Visible = false;
            dataMesinToolStripMenuItem.Visible = false;
            prosesToolStripMenuItem.Visible = false;
            laporanToolStripMenuItem.Visible = false;

            //Cek tipe user
            if (ClassVariabel.TipeUser == 0)
            {
                //Admin
                dataUtamaToolStripMenuItem.Visible = true;
                dataBahanToolStripMenuItem.Visible = true;
                dataToolStripMenuItem.Visible = true;
                dataFormulasiProduksiToolStripMenuItem.Visible = true;
                dataMesinToolStripMenuItem.Visible = true;
                prosesToolStripMenuItem.Visible = true;
                laporanToolStripMenuItem.Visible = true;
            }
            else if (ClassVariabel.TipeUser == 1)
            {
                //Persediaan
                dataUtamaToolStripMenuItem.Visible = true;
                dataBahanToolStripMenuItem.Visible = true;
                dataToolStripMenuItem.Visible = true;
            }
            else if (ClassVariabel.TipeUser == 2)
            {
                //Produksi
                dataUtamaToolStripMenuItem.Visible = true;
                dataFormulasiProduksiToolStripMenuItem.Visible = true;
                dataMesinToolStripMenuItem.Visible = true;
            }
            else
            {
                //Kepala produksi
                prosesToolStripMenuItem.Visible = true;
                laporanToolStripMenuItem.Visible = true;
            }

        }

        private void kartuStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new frmLaporan();
            x.MdiParent = this;
            x.Show();
            x.BringToFront();
        }

        private void mengenaiPenulisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
