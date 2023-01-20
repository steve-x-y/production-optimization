namespace Optimasi_Produksi
{
    partial class frmMMesin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMMesin));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtKodeMesin = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtNamaMesin = new System.Windows.Forms.TextBox();
            this.lstBiaya = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.btnBaru = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.Location = new System.Drawing.Point(269, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 27);
            this.btnBrowse.TabIndex = 211;
            this.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(131, 28);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(10, 15);
            this.Label6.TabIndex = 210;
            this.Label6.Text = ":";
            // 
            // txtKodeMesin
            // 
            this.txtKodeMesin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKodeMesin.Location = new System.Drawing.Point(146, 25);
            this.txtKodeMesin.Name = "txtKodeMesin";
            this.txtKodeMesin.Size = new System.Drawing.Size(119, 22);
            this.txtKodeMesin.TabIndex = 209;
            this.txtKodeMesin.TextChanged += new System.EventHandler(this.txtKodeMesin_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 15);
            this.Label1.TabIndex = 208;
            this.Label1.Text = "Kode Mesin";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(131, 59);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(10, 15);
            this.Label7.TabIndex = 214;
            this.Label7.Text = ":";
            // 
            // txtNamaMesin
            // 
            this.txtNamaMesin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaMesin.Location = new System.Drawing.Point(146, 56);
            this.txtNamaMesin.Name = "txtNamaMesin";
            this.txtNamaMesin.Size = new System.Drawing.Size(319, 22);
            this.txtNamaMesin.TabIndex = 213;
            // 
            // lstBiaya
            // 
            this.lstBiaya.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader5});
            this.lstBiaya.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBiaya.FullRowSelect = true;
            this.lstBiaya.GridLines = true;
            this.lstBiaya.Location = new System.Drawing.Point(15, 84);
            this.lstBiaya.Name = "lstBiaya";
            this.lstBiaya.Size = new System.Drawing.Size(450, 292);
            this.lstBiaya.TabIndex = 223;
            this.lstBiaya.UseCompatibleStateImageBehavior = false;
            this.lstBiaya.View = System.Windows.Forms.View.Details;
            this.lstBiaya.SelectedIndexChanged += new System.EventHandler(this.lstBiaya_SelectedIndexChanged);
            this.lstBiaya.DoubleClick += new System.EventHandler(this.lstBiaya_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Kode Produk";
            this.columnHeader1.Width = 86;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nama Produk";
            this.columnHeader3.Width = 146;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Biaya (Rp)";
            this.columnHeader2.Width = 112;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Lama (menit)";
            this.columnHeader5.Width = 81;
            // 
            // btnBaru
            // 
            this.btnBaru.BackColor = System.Drawing.Color.White;
            this.btnBaru.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaru.Image = ((System.Drawing.Image)(resources.GetObject("btnBaru.Image")));
            this.btnBaru.Location = new System.Drawing.Point(244, 410);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(51, 41);
            this.btnBaru.TabIndex = 227;
            this.btnBaru.Text = "&Baru";
            this.btnBaru.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaru.UseVisualStyleBackColor = false;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.White;
            this.btnSimpan.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.Location = new System.Drawing.Point(300, 410);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(51, 41);
            this.btnSimpan.TabIndex = 226;
            this.btnSimpan.Text = "&Simpan";
            this.btnSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.White;
            this.btnHapus.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.Image = ((System.Drawing.Image)(resources.GetObject("btnHapus.Image")));
            this.btnHapus.Location = new System.Drawing.Point(357, 410);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(51, 41);
            this.btnHapus.TabIndex = 225;
            this.btnHapus.Text = "&Hapus";
            this.btnHapus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.BackColor = System.Drawing.Color.White;
            this.btnKeluar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Image = ((System.Drawing.Image)(resources.GetObject("btnKeluar.Image")));
            this.btnKeluar.Location = new System.Drawing.Point(414, 410);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(51, 41);
            this.btnKeluar.TabIndex = 224;
            this.btnKeluar.Text = "&Keluar";
            this.btnKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(12, 59);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(74, 15);
            this.Label2.TabIndex = 212;
            this.Label2.Text = "Nama Mesin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 15);
            this.label3.TabIndex = 228;
            this.label3.Text = "NB. Data biaya dan lama untuk produksi per produk";
            // 
            // frmMMesin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 463);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBaru);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.lstBiaya);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.txtNamaMesin);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtKodeMesin);
            this.Controls.Add(this.Label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMMesin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Mesin";
            this.Load += new System.EventHandler(this.frmMMesin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtKodeMesin;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtNamaMesin;
        internal System.Windows.Forms.ListView lstBiaya;
        internal System.Windows.Forms.Button btnBaru;
        internal System.Windows.Forms.Button btnSimpan;
        internal System.Windows.Forms.Button btnHapus;
        internal System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label label3;
    }
}