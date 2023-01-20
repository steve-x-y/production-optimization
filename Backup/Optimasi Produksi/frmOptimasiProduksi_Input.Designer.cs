namespace Optimasi_Produksi
{
    partial class frmOptimasiProduksi_Input
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptimasiProduksi_Input));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lstProduk = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtWaktuKerja = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWaktuLembur = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.btnProses = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHapusMesin = new System.Windows.Forms.Button();
            this.btnTambahMesin = new System.Windows.Forms.Button();
            this.lblNamaMesin = new System.Windows.Forms.Label();
            this.cboKodeMesin = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBiayaPekerja = new System.Windows.Forms.Label();
            this.lstMesin = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWaktu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(631, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 27);
            this.btnDelete.TabIndex = 223;
            this.btnDelete.Text = "Hapus";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(437, 19);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(95, 27);
            this.btnInsert.TabIndex = 222;
            this.btnInsert.Text = "Tambah";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lstProduk
            // 
            this.lstProduk.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.columnHeader7,
            this.columnHeader6});
            this.lstProduk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProduk.FullRowSelect = true;
            this.lstProduk.GridLines = true;
            this.lstProduk.Location = new System.Drawing.Point(12, 52);
            this.lstProduk.Name = "lstProduk";
            this.lstProduk.Size = new System.Drawing.Size(714, 168);
            this.lstProduk.TabIndex = 221;
            this.lstProduk.UseCompatibleStateImageBehavior = false;
            this.lstProduk.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Kode Produk";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Nama Produk";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader2.Width = 260;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Prediksi Permintaan Produk";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader3.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Saldo Awal";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 75;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Biaya Produksi";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 100;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.BackColor = System.Drawing.Color.Transparent;
            this.Label13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(259, 244);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(10, 15);
            this.Label13.TabIndex = 226;
            this.Label13.Text = ":";
            // 
            // txtWaktuKerja
            // 
            this.txtWaktuKerja.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaktuKerja.Location = new System.Drawing.Point(274, 241);
            this.txtWaktuKerja.Name = "txtWaktuKerja";
            this.txtWaktuKerja.Size = new System.Drawing.Size(119, 22);
            this.txtWaktuKerja.TabIndex = 224;
            this.txtWaktuKerja.Text = "0";
            this.txtWaktuKerja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWaktuKerja.Leave += new System.EventHandler(this.txtWaktuKerja_Leave);
            this.txtWaktuKerja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaktuKerja_KeyPress);
            this.txtWaktuKerja.Enter += new System.EventHandler(this.txtWaktuKerja_Enter);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(9, 244);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(161, 15);
            this.Label14.TabIndex = 225;
            this.Label14.Text = "Jlh Waktu Kerja Standar (Ar)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 15);
            this.label1.TabIndex = 229;
            this.label1.Text = ":";
            // 
            // txtWaktuLembur
            // 
            this.txtWaktuLembur.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaktuLembur.Location = new System.Drawing.Point(274, 269);
            this.txtWaktuLembur.Name = "txtWaktuLembur";
            this.txtWaktuLembur.Size = new System.Drawing.Size(119, 22);
            this.txtWaktuLembur.TabIndex = 227;
            this.txtWaktuLembur.Text = "0";
            this.txtWaktuLembur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWaktuLembur.Leave += new System.EventHandler(this.txtWaktuLembur_Leave);
            this.txtWaktuLembur.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaktuLembur_KeyPress);
            this.txtWaktuLembur.Enter += new System.EventHandler(this.txtWaktuLembur_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 15);
            this.label4.TabIndex = 228;
            this.label4.Text = "Jlh Waktu Lembur yang Diperbolehkan (Ao)";
            // 
            // btnKeluar
            // 
            this.btnKeluar.BackColor = System.Drawing.Color.White;
            this.btnKeluar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Image = ((System.Drawing.Image)(resources.GetObject("btnKeluar.Image")));
            this.btnKeluar.Location = new System.Drawing.Point(570, 551);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(51, 41);
            this.btnKeluar.TabIndex = 236;
            this.btnKeluar.Text = "&Keluar";
            this.btnKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // btnProses
            // 
            this.btnProses.BackColor = System.Drawing.Color.White;
            this.btnProses.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProses.Image = ((System.Drawing.Image)(resources.GetObject("btnProses.Image")));
            this.btnProses.Location = new System.Drawing.Point(513, 551);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(51, 41);
            this.btnProses.TabIndex = 237;
            this.btnProses.Text = "&Proses";
            this.btnProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProses.UseVisualStyleBackColor = false;
            this.btnProses.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(399, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 15);
            this.label11.TabIndex = 241;
            this.label11.Text = "(jam per hari)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(399, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 15);
            this.label12.TabIndex = 242;
            this.label12.Text = "(jam per hari)";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(534, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 27);
            this.btnEdit.TabIndex = 245;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHapusMesin);
            this.groupBox1.Controls.Add(this.btnTambahMesin);
            this.groupBox1.Controls.Add(this.lblNamaMesin);
            this.groupBox1.Controls.Add(this.cboKodeMesin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblBiayaPekerja);
            this.groupBox1.Controls.Add(this.lstMesin);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 200);
            this.groupBox1.TabIndex = 248;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mesin yang Tersedia untuk Digunakan";
            // 
            // btnHapusMesin
            // 
            this.btnHapusMesin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusMesin.Location = new System.Drawing.Point(506, 78);
            this.btnHapusMesin.Name = "btnHapusMesin";
            this.btnHapusMesin.Size = new System.Drawing.Size(95, 27);
            this.btnHapusMesin.TabIndex = 250;
            this.btnHapusMesin.Text = "Hapus";
            this.btnHapusMesin.UseVisualStyleBackColor = true;
            this.btnHapusMesin.Click += new System.EventHandler(this.btnHapusMesin_Click);
            // 
            // btnTambahMesin
            // 
            this.btnTambahMesin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahMesin.Location = new System.Drawing.Point(409, 78);
            this.btnTambahMesin.Name = "btnTambahMesin";
            this.btnTambahMesin.Size = new System.Drawing.Size(95, 27);
            this.btnTambahMesin.TabIndex = 249;
            this.btnTambahMesin.Text = "Tambah";
            this.btnTambahMesin.UseVisualStyleBackColor = true;
            this.btnTambahMesin.Click += new System.EventHandler(this.btnTambahMesin_Click);
            // 
            // lblNamaMesin
            // 
            this.lblNamaMesin.BackColor = System.Drawing.Color.White;
            this.lblNamaMesin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNamaMesin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaMesin.Location = new System.Drawing.Point(133, 52);
            this.lblNamaMesin.Name = "lblNamaMesin";
            this.lblNamaMesin.Size = new System.Drawing.Size(468, 23);
            this.lblNamaMesin.TabIndex = 249;
            this.lblNamaMesin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboKodeMesin
            // 
            this.cboKodeMesin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKodeMesin.FormattingEnabled = true;
            this.cboKodeMesin.Location = new System.Drawing.Point(9, 52);
            this.cboKodeMesin.Name = "cboKodeMesin";
            this.cboKodeMesin.Size = new System.Drawing.Size(121, 22);
            this.cboKodeMesin.TabIndex = 249;
            this.cboKodeMesin.SelectedIndexChanged += new System.EventHandler(this.cboKodeMesin_SelectedIndexChanged);
            this.cboKodeMesin.TextChanged += new System.EventHandler(this.cboKodeMesin_TextChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(468, 23);
            this.label2.TabIndex = 251;
            this.label2.Text = "Nama Mesin";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBiayaPekerja
            // 
            this.lblBiayaPekerja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblBiayaPekerja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBiayaPekerja.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiayaPekerja.Location = new System.Drawing.Point(9, 26);
            this.lblBiayaPekerja.Name = "lblBiayaPekerja";
            this.lblBiayaPekerja.Size = new System.Drawing.Size(121, 23);
            this.lblBiayaPekerja.TabIndex = 250;
            this.lblBiayaPekerja.Text = "Kode Mesin";
            this.lblBiayaPekerja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstMesin
            // 
            this.lstMesin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lstMesin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMesin.FullRowSelect = true;
            this.lstMesin.GridLines = true;
            this.lstMesin.Location = new System.Drawing.Point(9, 111);
            this.lstMesin.Name = "lstMesin";
            this.lstMesin.Size = new System.Drawing.Size(592, 81);
            this.lstMesin.TabIndex = 249;
            this.lstMesin.UseCompatibleStateImageBehavior = false;
            this.lstMesin.View = System.Windows.Forms.View.Details;
            this.lstMesin.SelectedIndexChanged += new System.EventHandler(this.lstMesin_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Kode Mesin";
            this.columnHeader4.Width = 121;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nama Mesin";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 445;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(259, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 15);
            this.label3.TabIndex = 251;
            this.label3.Text = ":";
            // 
            // txtWaktu
            // 
            this.txtWaktu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaktu.Location = new System.Drawing.Point(274, 297);
            this.txtWaktu.Name = "txtWaktu";
            this.txtWaktu.Size = new System.Drawing.Size(119, 22);
            this.txtWaktu.TabIndex = 249;
            this.txtWaktu.Text = "0";
            this.txtWaktu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 15);
            this.label5.TabIndex = 250;
            this.label5.Text = "Lama Waktu Pembersihan Mesin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(399, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 252;
            this.label6.Text = "menit";
            // 
            // frmOptimasiProduksi_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 603);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWaktu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnProses);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWaktuLembur);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.txtWaktuKerja);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.lstProduk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptimasiProduksi_Input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Optimasi Produksi";
            this.Load += new System.EventHandler(this.frmOptimasiProduksi_Input_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        internal System.Windows.Forms.ListView lstProduk;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txtWaktuKerja;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtWaktuLembur;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btnKeluar;
        internal System.Windows.Forms.Button btnProses;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblBiayaPekerja;
        internal System.Windows.Forms.ListView lstMesin;
        internal System.Windows.Forms.ColumnHeader columnHeader4;
        internal System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ComboBox cboKodeMesin;
        private System.Windows.Forms.Button btnHapusMesin;
        private System.Windows.Forms.Button btnTambahMesin;
        internal System.Windows.Forms.Label lblNamaMesin;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtWaktu;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}