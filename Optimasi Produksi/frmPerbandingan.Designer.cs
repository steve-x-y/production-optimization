namespace Optimasi_Produksi
{
    partial class frmPerbandingan
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
            this.lstUji = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.btnProses = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTemperatur = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKet = new System.Windows.Forms.Label();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUji
            // 
            this.lstUji.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.columnHeader4,
            this.columnHeader6,
            this.ColumnHeader3,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lstUji.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUji.FullRowSelect = true;
            this.lstUji.GridLines = true;
            this.lstUji.Location = new System.Drawing.Point(12, 103);
            this.lstUji.Name = "lstUji";
            this.lstUji.Size = new System.Drawing.Size(1023, 360);
            this.lstUji.TabIndex = 235;
            this.lstUji.UseCompatibleStateImageBehavior = false;
            this.lstUji.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Pengujian ke-";
            this.columnHeader5.Width = 86;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "m";
            this.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader1.Width = 74;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "T";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader2.Width = 99;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 4;
            this.columnHeader4.Text = "Biaya Produksi (MSA)";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 155;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 3;
            this.columnHeader6.Text = "Biaya Produksi (SA)";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 142;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Waktu Produksi (SA)";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader3.Width = 114;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Waktu Produksi (MSA)";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 123;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Lama Waktu (SA)";
            this.columnHeader8.Width = 101;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Lama Waktu (MSA)";
            this.columnHeader9.Width = 106;
            // 
            // btnProses
            // 
            this.btnProses.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProses.Location = new System.Drawing.Point(277, 18);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(87, 34);
            this.btnProses.TabIndex = 237;
            this.btnProses.Text = "&Proses";
            this.btnProses.UseVisualStyleBackColor = true;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Location = new System.Drawing.Point(277, 53);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(87, 34);
            this.btnKeluar.TabIndex = 236;
            this.btnKeluar.Text = "&Keluar";
            this.btnKeluar.UseVisualStyleBackColor = true;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtM);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTemperatur);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 85);
            this.groupBox1.TabIndex = 262;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Parameter";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 15);
            this.label10.TabIndex = 242;
            this.label10.Text = "Jumlah Perulangan (m)";
            // 
            // txtM
            // 
            this.txtM.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtM.Location = new System.Drawing.Point(170, 25);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(72, 22);
            this.txtM.TabIndex = 241;
            this.txtM.Text = "0";
            this.txtM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(155, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 15);
            this.label9.TabIndex = 243;
            this.label9.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 15);
            this.label5.TabIndex = 245;
            this.label5.Text = "Temperatur Awal (T)";
            // 
            // txtTemperatur
            // 
            this.txtTemperatur.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemperatur.Location = new System.Drawing.Point(170, 51);
            this.txtTemperatur.Name = "txtTemperatur";
            this.txtTemperatur.Size = new System.Drawing.Size(72, 22);
            this.txtTemperatur.TabIndex = 244;
            this.txtTemperatur.Text = "0";
            this.txtTemperatur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(155, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 15);
            this.label4.TabIndex = 246;
            this.label4.Text = ":";
            // 
            // lblKet
            // 
            this.lblKet.AutoSize = true;
            this.lblKet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKet.Location = new System.Drawing.Point(12, 531);
            this.lblKet.Name = "lblKet";
            this.lblKet.Size = new System.Drawing.Size(159, 13);
            this.lblKet.TabIndex = 264;
            this.lblKet.Text = "Menghitung Perulangan ke-3 ...";
            this.lblKet.Visible = false;
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(12, 469);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(1023, 10);
            this.pb1.TabIndex = 263;
            this.pb1.Visible = false;
            // 
            // frmPerbandingan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 494);
            this.Controls.Add(this.lblKet);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnProses);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.lstUji);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPerbandingan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perbandingan Metode SA dan MSA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView lstUji;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.Button btnProses;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtM;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtTemperatur;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label lblKet;
        private System.Windows.Forms.ProgressBar pb1;
    }
}