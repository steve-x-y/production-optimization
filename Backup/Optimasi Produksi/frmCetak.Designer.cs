namespace Optimasi_Produksi
{
    partial class frmCetak
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CR1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CR1
            // 
            this.CR1.ActiveViewIndex = -1;
            this.CR1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CR1.DisplayGroupTree = false;
            this.CR1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CR1.Location = new System.Drawing.Point(0, 0);
            this.CR1.Name = "CR1";
            this.CR1.SelectionFormula = "";
            this.CR1.Size = new System.Drawing.Size(704, 587);
            this.CR1.TabIndex = 0;
            this.CR1.ViewTimeSelectionFormula = "";
            // 
            // frmCetak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 587);
            this.Controls.Add(this.CR1);
            this.Name = "frmCetak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laporan Kartu Stock";
            this.Load += new System.EventHandler(this.frmCetak_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CR1;
    }
}