namespace Optimasi_Produksi
{
    partial class frmProses_SA
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
            this.lblTotalLamaProduksi = new System.Windows.Forms.Label();
            this.lblTotalKeseluruhan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstProduk = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.btnProses = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.rtbHitung = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtM = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTemperatur = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.lblKet = new System.Windows.Forms.Label();
            this.lblWaktu = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbTotalBiayaProduksi = new System.Windows.Forms.Label();
            this.lblTotalBiayaMesin = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLaporan = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDeal = new System.Windows.Forms.Button();
            this.lblWaktuBersih = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalWaktu = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalLamaProduksi
            // 
            this.lblTotalLamaProduksi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalLamaProduksi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalLamaProduksi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLamaProduksi.Location = new System.Drawing.Point(782, 280);
            this.lblTotalLamaProduksi.Name = "lblTotalLamaProduksi";
            this.lblTotalLamaProduksi.Size = new System.Drawing.Size(131, 23);
            this.lblTotalLamaProduksi.TabIndex = 238;
            this.lblTotalLamaProduksi.Text = "0";
            this.lblTotalLamaProduksi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalKeseluruhan
            // 
            this.lblTotalKeseluruhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalKeseluruhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalKeseluruhan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalKeseluruhan.Location = new System.Drawing.Point(442, 305);
            this.lblTotalKeseluruhan.Name = "lblTotalKeseluruhan";
            this.lblTotalKeseluruhan.Size = new System.Drawing.Size(209, 23);
            this.lblTotalKeseluruhan.TabIndex = 237;
            this.lblTotalKeseluruhan.Text = "0";
            this.lblTotalKeseluruhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(372, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 236;
            this.label3.Text = "Total (Rp.)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 15);
            this.label2.TabIndex = 235;
            this.label2.Text = "Total Biaya Produksi secara Keseluruhan (Rp.)";
            // 
            // lstProduk
            // 
            this.lstProduk.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lstProduk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProduk.FullRowSelect = true;
            this.lstProduk.GridLines = true;
            this.lstProduk.Location = new System.Drawing.Point(12, 108);
            this.lstProduk.Name = "lstProduk";
            this.lstProduk.Size = new System.Drawing.Size(901, 168);
            this.lstProduk.TabIndex = 234;
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
            this.ColumnHeader2.Width = 329;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Biaya Produksi (Rp)";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader3.Width = 114;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Biaya Mesin (Rp)";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 96;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Lama Produksi (mnt)";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 118;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Mesin yang Digunakan";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 132;
            // 
            // btnProses
            // 
            this.btnProses.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProses.Location = new System.Drawing.Point(277, 21);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(87, 34);
            this.btnProses.TabIndex = 233;
            this.btnProses.Text = "&Proses";
            this.btnProses.UseVisualStyleBackColor = true;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Location = new System.Drawing.Point(277, 61);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(87, 34);
            this.btnKeluar.TabIndex = 232;
            this.btnKeluar.Text = "&Keluar";
            this.btnKeluar.UseVisualStyleBackColor = true;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // rtbHitung
            // 
            this.rtbHitung.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbHitung.Location = new System.Drawing.Point(12, 390);
            this.rtbHitung.Name = "rtbHitung";
            this.rtbHitung.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbHitung.Size = new System.Drawing.Size(901, 209);
            this.rtbHitung.TabIndex = 231;
            this.rtbHitung.Text = "";
            this.rtbHitung.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbHitung_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 230;
            this.label1.Text = "Hasil Perhitungan";
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
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(12, 605);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(901, 10);
            this.pb1.TabIndex = 247;
            this.pb1.Visible = false;
            // 
            // lblKet
            // 
            this.lblKet.AutoSize = true;
            this.lblKet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKet.Location = new System.Drawing.Point(12, 618);
            this.lblKet.Name = "lblKet";
            this.lblKet.Size = new System.Drawing.Size(159, 13);
            this.lblKet.TabIndex = 248;
            this.lblKet.Text = "Menghitung Perulangan ke-3 ...";
            this.lblKet.Visible = false;
            // 
            // lblWaktu
            // 
            this.lblWaktu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblWaktu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWaktu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaktu.Location = new System.Drawing.Point(728, 82);
            this.lblWaktu.Name = "lblWaktu";
            this.lblWaktu.Size = new System.Drawing.Size(118, 23);
            this.lblWaktu.TabIndex = 250;
            this.lblWaktu.Text = "0";
            this.lblWaktu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(486, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 15);
            this.label7.TabIndex = 249;
            this.label7.Text = "Lama Waktu Eksekusi dari Algoritma SA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(852, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 251;
            this.label6.Text = "milisekon";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(712, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 15);
            this.label13.TabIndex = 255;
            this.label13.Text = ":";
            // 
            // lbTotalBiayaProduksi
            // 
            this.lbTotalBiayaProduksi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbTotalBiayaProduksi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTotalBiayaProduksi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalBiayaProduksi.Location = new System.Drawing.Point(442, 280);
            this.lbTotalBiayaProduksi.Name = "lbTotalBiayaProduksi";
            this.lbTotalBiayaProduksi.Size = new System.Drawing.Size(112, 23);
            this.lbTotalBiayaProduksi.TabIndex = 256;
            this.lbTotalBiayaProduksi.Text = "0";
            this.lbTotalBiayaProduksi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalBiayaMesin
            // 
            this.lblTotalBiayaMesin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalBiayaMesin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalBiayaMesin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBiayaMesin.Location = new System.Drawing.Point(557, 280);
            this.lblTotalBiayaMesin.Name = "lblTotalBiayaMesin";
            this.lblTotalBiayaMesin.Size = new System.Drawing.Size(94, 23);
            this.lblTotalBiayaMesin.TabIndex = 257;
            this.lblTotalBiayaMesin.Text = "0";
            this.lblTotalBiayaMesin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.groupBox1.TabIndex = 258;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Parameter";
            // 
            // chkLaporan
            // 
            this.chkLaporan.AutoSize = true;
            this.chkLaporan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLaporan.Location = new System.Drawing.Point(717, 368);
            this.chkLaporan.Name = "chkLaporan";
            this.chkLaporan.Size = new System.Drawing.Size(196, 19);
            this.chkLaporan.TabIndex = 259;
            this.chkLaporan.Text = "Tampilkan Laporan Perhitungan";
            this.chkLaporan.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(918, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 260;
            this.label8.Text = "(menit)";
            // 
            // btnDeal
            // 
            this.btnDeal.Enabled = false;
            this.btnDeal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeal.Location = new System.Drawing.Point(12, 280);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(103, 34);
            this.btnDeal.TabIndex = 261;
            this.btnDeal.Text = "&Deal Produksi";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // lblWaktuBersih
            // 
            this.lblWaktuBersih.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblWaktuBersih.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWaktuBersih.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaktuBersih.Location = new System.Drawing.Point(782, 305);
            this.lblWaktuBersih.Name = "lblWaktuBersih";
            this.lblWaktuBersih.Size = new System.Drawing.Size(131, 23);
            this.lblWaktuBersih.TabIndex = 263;
            this.lblWaktuBersih.Text = "0";
            this.lblWaktuBersih.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(669, 305);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 23);
            this.label12.TabIndex = 262;
            this.label12.Text = "Lama pembersihan";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(918, 309);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 15);
            this.label14.TabIndex = 264;
            this.label14.Text = "(menit)";
            // 
            // lblTotalWaktu
            // 
            this.lblTotalWaktu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalWaktu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalWaktu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalWaktu.Location = new System.Drawing.Point(782, 331);
            this.lblTotalWaktu.Name = "lblTotalWaktu";
            this.lblTotalWaktu.Size = new System.Drawing.Size(131, 23);
            this.lblTotalWaktu.TabIndex = 266;
            this.lblTotalWaktu.Text = "0";
            this.lblTotalWaktu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(669, 331);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 23);
            this.label16.TabIndex = 265;
            this.label16.Text = "Total Waktu";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(918, 335);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 15);
            this.label17.TabIndex = 267;
            this.label17.Text = "(menit)";
            // 
            // frmProses_SA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 638);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblTotalWaktu);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblWaktuBersih);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkLaporan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalBiayaMesin);
            this.Controls.Add(this.lbTotalBiayaProduksi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblWaktu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblKet);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.lblTotalLamaProduksi);
            this.Controls.Add(this.lblTotalKeseluruhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstProduk);
            this.Controls.Add(this.btnProses);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.rtbHitung);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProses_SA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proses Optimalisasi Produksi dengan Metode Simulated Annealing";
            this.Load += new System.EventHandler(this.frmProses_SA_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTotalLamaProduksi;
        internal System.Windows.Forms.Label lblTotalKeseluruhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ListView lstProduk;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.Button btnProses;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.RichTextBox rtbHitung;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtM;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtTemperatur;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pb1;
        private System.Windows.Forms.Label lblKet;
        internal System.Windows.Forms.Label lblWaktu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        internal System.Windows.Forms.Label lbTotalBiayaProduksi;
        internal System.Windows.Forms.Label lblTotalBiayaMesin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkLaporan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDeal;
        internal System.Windows.Forms.Label lblWaktuBersih;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label lblTotalWaktu;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}