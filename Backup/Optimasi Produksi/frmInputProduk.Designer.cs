namespace Optimasi_Produksi
{
    partial class frmInputProduk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputProduk));
            this.lblNamaProduk = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.lblWaktuProduksi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldoAwal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtPermintaan = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtKodeProduk = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblBiayaProduksi = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBiayaSimpan = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNamaProduk
            // 
            this.lblNamaProduk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblNamaProduk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNamaProduk.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaProduk.Location = new System.Drawing.Point(182, 54);
            this.lblNamaProduk.Name = "lblNamaProduk";
            this.lblNamaProduk.Size = new System.Drawing.Size(346, 23);
            this.lblNamaProduk.TabIndex = 247;
            this.lblNamaProduk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.White;
            this.btnSimpan.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.Location = new System.Drawing.Point(420, 142);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(51, 41);
            this.btnSimpan.TabIndex = 246;
            this.btnSimpan.Text = "&Simpan";
            this.btnSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.BackColor = System.Drawing.Color.White;
            this.btnKeluar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Image = ((System.Drawing.Image)(resources.GetObject("btnKeluar.Image")));
            this.btnKeluar.Location = new System.Drawing.Point(477, 142);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(51, 41);
            this.btnKeluar.TabIndex = 245;
            this.btnKeluar.Text = "&Keluar";
            this.btnKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // lblWaktuProduksi
            // 
            this.lblWaktuProduksi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblWaktuProduksi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWaktuProduksi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaktuProduksi.Location = new System.Drawing.Point(183, 322);
            this.lblWaktuProduksi.Name = "lblWaktuProduksi";
            this.lblWaktuProduksi.Size = new System.Drawing.Size(118, 23);
            this.lblWaktuProduksi.TabIndex = 244;
            this.lblWaktuProduksi.Text = "0";
            this.lblWaktuProduksi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(167, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 15);
            this.label5.TabIndex = 243;
            this.label5.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 15);
            this.label8.TabIndex = 242;
            this.label8.Text = "Waktu Produksi/Satuan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(167, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 15);
            this.label3.TabIndex = 241;
            this.label3.Text = ":";
            // 
            // txtSaldoAwal
            // 
            this.txtSaldoAwal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSaldoAwal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoAwal.Location = new System.Drawing.Point(182, 111);
            this.txtSaldoAwal.Name = "txtSaldoAwal";
            this.txtSaldoAwal.Size = new System.Drawing.Size(119, 22);
            this.txtSaldoAwal.TabIndex = 239;
            this.txtSaldoAwal.Text = "0";
            this.txtSaldoAwal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSaldoAwal.Leave += new System.EventHandler(this.txtSaldoAwal_Leave);
            this.txtSaldoAwal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaldoAwal_KeyPress);
            this.txtSaldoAwal.Enter += new System.EventHandler(this.txtSaldoAwal_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 240;
            this.label4.Text = "Saldo Awal";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.Location = new System.Drawing.Point(305, 25);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 27);
            this.btnBrowse.TabIndex = 238;
            this.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.BackColor = System.Drawing.Color.Transparent;
            this.Label13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(167, 86);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(10, 15);
            this.Label13.TabIndex = 237;
            this.Label13.Text = ":";
            // 
            // txtPermintaan
            // 
            this.txtPermintaan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPermintaan.Location = new System.Drawing.Point(182, 83);
            this.txtPermintaan.Name = "txtPermintaan";
            this.txtPermintaan.Size = new System.Drawing.Size(119, 22);
            this.txtPermintaan.TabIndex = 235;
            this.txtPermintaan.Text = "0";
            this.txtPermintaan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPermintaan.Leave += new System.EventHandler(this.txtPermintaan_Leave);
            this.txtPermintaan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPermintaan_KeyPress);
            this.txtPermintaan.Enter += new System.EventHandler(this.txtPermintaan_Enter);
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(12, 86);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(111, 15);
            this.Label14.TabIndex = 236;
            this.Label14.Text = "Prediksi Permintaan";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(167, 58);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(10, 15);
            this.Label7.TabIndex = 234;
            this.Label7.Text = ":";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(167, 30);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(10, 15);
            this.Label6.TabIndex = 233;
            this.Label6.Text = ":";
            // 
            // txtKodeProduk
            // 
            this.txtKodeProduk.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKodeProduk.Location = new System.Drawing.Point(182, 27);
            this.txtKodeProduk.Name = "txtKodeProduk";
            this.txtKodeProduk.Size = new System.Drawing.Size(119, 22);
            this.txtKodeProduk.TabIndex = 232;
            this.txtKodeProduk.TextChanged += new System.EventHandler(this.txtKodeProduk_TextChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(12, 58);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(78, 15);
            this.Label2.TabIndex = 231;
            this.Label2.Text = "Nama Produk";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 30);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 15);
            this.Label1.TabIndex = 230;
            this.Label1.Text = "Kode Produk";
            // 
            // lblBiayaProduksi
            // 
            this.lblBiayaProduksi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblBiayaProduksi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBiayaProduksi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiayaProduksi.Location = new System.Drawing.Point(183, 353);
            this.lblBiayaProduksi.Name = "lblBiayaProduksi";
            this.lblBiayaProduksi.Size = new System.Drawing.Size(118, 23);
            this.lblBiayaProduksi.TabIndex = 250;
            this.lblBiayaProduksi.Text = "0";
            this.lblBiayaProduksi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(167, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 15);
            this.label10.TabIndex = 249;
            this.label10.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 357);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 15);
            this.label11.TabIndex = 248;
            this.label11.Text = "Biaya Produksi/Satuan";
            // 
            // lblBiayaSimpan
            // 
            this.lblBiayaSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblBiayaSimpan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBiayaSimpan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiayaSimpan.Location = new System.Drawing.Point(183, 385);
            this.lblBiayaSimpan.Name = "lblBiayaSimpan";
            this.lblBiayaSimpan.Size = new System.Drawing.Size(118, 23);
            this.lblBiayaSimpan.TabIndex = 253;
            this.lblBiayaSimpan.Text = "0";
            this.lblBiayaSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(167, 389);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 15);
            this.label15.TabIndex = 252;
            this.label15.Text = ":";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 389);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(153, 15);
            this.label16.TabIndex = 251;
            this.label16.Text = "Biaya Penyimpanan/Satuan";
            // 
            // frmInputProduk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 202);
            this.Controls.Add(this.lblBiayaSimpan);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblBiayaProduksi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblNamaProduk);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.lblWaktuProduksi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSaldoAwal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.txtPermintaan);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtKodeProduk);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInputProduk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Produk ...";
            this.Load += new System.EventHandler(this.frmInputProduk_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblNamaProduk;
        internal System.Windows.Forms.Button btnSimpan;
        internal System.Windows.Forms.Button btnKeluar;
        internal System.Windows.Forms.Label lblWaktuProduksi;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtSaldoAwal;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txtPermintaan;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtKodeProduk;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblBiayaProduksi;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label lblBiayaSimpan;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label16;
    }
}