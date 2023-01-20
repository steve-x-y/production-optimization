namespace Optimasi_Produksi
{
    partial class frmCari
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
            this.btnTampil = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.lstDaftar = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnCari = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCari = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSemua = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTampil
            // 
            this.btnTampil.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampil.Location = new System.Drawing.Point(293, 359);
            this.btnTampil.Name = "btnTampil";
            this.btnTampil.Size = new System.Drawing.Size(81, 29);
            this.btnTampil.TabIndex = 120;
            this.btnTampil.Text = "Tampil";
            this.btnTampil.UseVisualStyleBackColor = true;
            this.btnTampil.Click += new System.EventHandler(this.btnTampil_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Location = new System.Drawing.Point(380, 359);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(81, 29);
            this.btnKeluar.TabIndex = 119;
            this.btnKeluar.Text = "Keluar";
            this.btnKeluar.UseVisualStyleBackColor = true;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // lstDaftar
            // 
            this.lstDaftar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lstDaftar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDaftar.FullRowSelect = true;
            this.lstDaftar.GridLines = true;
            this.lstDaftar.Location = new System.Drawing.Point(15, 75);
            this.lstDaftar.Name = "lstDaftar";
            this.lstDaftar.Size = new System.Drawing.Size(446, 278);
            this.lstDaftar.TabIndex = 118;
            this.lstDaftar.UseCompatibleStateImageBehavior = false;
            this.lstDaftar.View = System.Windows.Forms.View.Details;
            this.lstDaftar.DoubleClick += new System.EventHandler(this.lstDaftar_DoubleClick);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Kode";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Nama";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader2.Width = 340;
            // 
            // btnCari
            // 
            this.btnCari.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.Location = new System.Drawing.Point(320, 42);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(65, 27);
            this.btnCari.TabIndex = 127;
            this.btnCari.Text = "&Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // txtCari
            // 
            this.txtCari.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCari.Location = new System.Drawing.Point(117, 44);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(197, 20);
            this.txtCari.TabIndex = 126;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 14);
            this.label2.TabIndex = 125;
            this.label2.Text = "Kata Pencarian";
            // 
            // cboCari
            // 
            this.cboCari.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCari.FormattingEnabled = true;
            this.cboCari.Location = new System.Drawing.Point(117, 16);
            this.cboCari.Name = "cboCari";
            this.cboCari.Size = new System.Drawing.Size(197, 22);
            this.cboCari.TabIndex = 124;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 123;
            this.label1.Text = "Cari Berdasarkan";
            // 
            // btnSemua
            // 
            this.btnSemua.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSemua.Location = new System.Drawing.Point(15, 359);
            this.btnSemua.Name = "btnSemua";
            this.btnSemua.Size = new System.Drawing.Size(109, 27);
            this.btnSemua.TabIndex = 128;
            this.btnSemua.Text = "&Tampilkan Semua";
            this.btnSemua.UseVisualStyleBackColor = true;
            this.btnSemua.Click += new System.EventHandler(this.btnSemua_Click);
            // 
            // frmCari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 403);
            this.Controls.Add(this.btnSemua);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCari);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTampil);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.lstDaftar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Data ...";
            this.Load += new System.EventHandler(this.frmCari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnTampil;
        internal System.Windows.Forms.Button btnKeluar;
        internal System.Windows.Forms.ListView lstDaftar;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSemua;
    }
}