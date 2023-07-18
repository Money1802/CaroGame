
namespace CaroGame
{
    partial class CaroGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaroGame));
            this.pnl_BanCo = new System.Windows.Forms.Panel();
            this.pnl_BangDieuKhien = new System.Windows.Forms.Panel();
            this.lblLuotDi = new System.Windows.Forms.Label();
            this.btn_ChoiLai = new System.Windows.Forms.Button();
            this.btn_HuyVan = new System.Windows.Forms.Button();
            this.btn_PvM = new System.Windows.Forms.Button();
            this.btn_PvP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioO = new System.Windows.Forms.RadioButton();
            this.radioX = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menu_CaiDat = new System.Windows.Forms.MenuStrip();
            this.càiĐặtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luậtChơiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giớiThiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bậtTắtNhạcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_BangDieuKhien.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menu_CaiDat.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_BanCo
            // 
            this.pnl_BanCo.Location = new System.Drawing.Point(334, 31);
            this.pnl_BanCo.Name = "pnl_BanCo";
            this.pnl_BanCo.Size = new System.Drawing.Size(628, 479);
            this.pnl_BanCo.TabIndex = 0;
            // 
            // pnl_BangDieuKhien
            // 
            this.pnl_BangDieuKhien.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnl_BangDieuKhien.Controls.Add(this.lblLuotDi);
            this.pnl_BangDieuKhien.Controls.Add(this.btn_ChoiLai);
            this.pnl_BangDieuKhien.Controls.Add(this.btn_HuyVan);
            this.pnl_BangDieuKhien.Controls.Add(this.btn_PvM);
            this.pnl_BangDieuKhien.Controls.Add(this.btn_PvP);
            this.pnl_BangDieuKhien.Controls.Add(this.label1);
            this.pnl_BangDieuKhien.Controls.Add(this.groupBox1);
            this.pnl_BangDieuKhien.Controls.Add(this.pictureBox1);
            this.pnl_BangDieuKhien.Location = new System.Drawing.Point(13, 31);
            this.pnl_BangDieuKhien.Name = "pnl_BangDieuKhien";
            this.pnl_BangDieuKhien.Size = new System.Drawing.Size(315, 479);
            this.pnl_BangDieuKhien.TabIndex = 1;
            // 
            // lblLuotDi
            // 
            this.lblLuotDi.AutoSize = true;
            this.lblLuotDi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuotDi.Location = new System.Drawing.Point(169, 291);
            this.lblLuotDi.Name = "lblLuotDi";
            this.lblLuotDi.Size = new System.Drawing.Size(18, 26);
            this.lblLuotDi.TabIndex = 4;
            this.lblLuotDi.Text = " ";
            // 
            // btn_ChoiLai
            // 
            this.btn_ChoiLai.Location = new System.Drawing.Point(148, 412);
            this.btn_ChoiLai.Name = "btn_ChoiLai";
            this.btn_ChoiLai.Size = new System.Drawing.Size(119, 40);
            this.btn_ChoiLai.TabIndex = 3;
            this.btn_ChoiLai.Text = "Chơi lại";
            this.btn_ChoiLai.UseVisualStyleBackColor = true;
            this.btn_ChoiLai.Click += new System.EventHandler(this.btn_ChoiLai_Click);
            // 
            // btn_HuyVan
            // 
            this.btn_HuyVan.Location = new System.Drawing.Point(17, 412);
            this.btn_HuyVan.Name = "btn_HuyVan";
            this.btn_HuyVan.Size = new System.Drawing.Size(119, 40);
            this.btn_HuyVan.TabIndex = 3;
            this.btn_HuyVan.Text = "Hủy Ván";
            this.btn_HuyVan.UseVisualStyleBackColor = true;
            this.btn_HuyVan.Click += new System.EventHandler(this.btn_HuyVan_Click);
            // 
            // btn_PvM
            // 
            this.btn_PvM.Location = new System.Drawing.Point(77, 368);
            this.btn_PvM.Name = "btn_PvM";
            this.btn_PvM.Size = new System.Drawing.Size(119, 38);
            this.btn_PvM.TabIndex = 3;
            this.btn_PvM.Text = "Người - Máy";
            this.btn_PvM.UseVisualStyleBackColor = true;
            this.btn_PvM.Click += new System.EventHandler(this.btn_PvM_Click);
            // 
            // btn_PvP
            // 
            this.btn_PvP.Location = new System.Drawing.Point(77, 320);
            this.btn_PvP.Name = "btn_PvP";
            this.btn_PvP.Size = new System.Drawing.Size(119, 38);
            this.btn_PvP.TabIndex = 3;
            this.btn_PvP.Text = "Người - Người";
            this.btn_PvP.UseVisualStyleBackColor = true;
            this.btn_PvP.Click += new System.EventHandler(this.btn_PvP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nước đi của quân:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioO);
            this.groupBox1.Controls.Add(this.radioX);
            this.groupBox1.Location = new System.Drawing.Point(10, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bạn chọn:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioO
            // 
            this.radioO.AutoSize = true;
            this.radioO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioO.ForeColor = System.Drawing.Color.Red;
            this.radioO.Location = new System.Drawing.Point(160, 32);
            this.radioO.Name = "radioO";
            this.radioO.Size = new System.Drawing.Size(50, 29);
            this.radioO.TabIndex = 0;
            this.radioO.Text = "O";
            this.radioO.UseVisualStyleBackColor = true;
            // 
            // radioX
            // 
            this.radioX.AutoSize = true;
            this.radioX.Checked = true;
            this.radioX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.radioX.Location = new System.Drawing.Point(50, 32);
            this.radioX.Name = "radioX";
            this.radioX.Size = new System.Drawing.Size(48, 29);
            this.radioX.TabIndex = 0;
            this.radioX.TabStop = true;
            this.radioX.Text = "X";
            this.radioX.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(309, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menu_CaiDat
            // 
            this.menu_CaiDat.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu_CaiDat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.càiĐặtToolStripMenuItem});
            this.menu_CaiDat.Location = new System.Drawing.Point(0, 0);
            this.menu_CaiDat.Name = "menu_CaiDat";
            this.menu_CaiDat.Size = new System.Drawing.Size(965, 28);
            this.menu_CaiDat.TabIndex = 2;
            this.menu_CaiDat.Text = "menuStrip1";
            this.menu_CaiDat.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_CaiDat_ItemClicked);
            // 
            // càiĐặtToolStripMenuItem
            // 
            this.càiĐặtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.luậtChơiToolStripMenuItem,
            this.giớiThiệuToolStripMenuItem,
            this.bậtTắtNhạcToolStripMenuItem});
            this.càiĐặtToolStripMenuItem.Name = "càiĐặtToolStripMenuItem";
            this.càiĐặtToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.càiĐặtToolStripMenuItem.Text = "&Cài đặt";
            this.càiĐặtToolStripMenuItem.Click += new System.EventHandler(this.càiĐặtToolStripMenuItem_Click);
            // 
            // luậtChơiToolStripMenuItem
            // 
            this.luậtChơiToolStripMenuItem.Name = "luậtChơiToolStripMenuItem";
            this.luậtChơiToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.luậtChơiToolStripMenuItem.Text = "&Luật chơi";
            this.luậtChơiToolStripMenuItem.Click += new System.EventHandler(this.luậtChơiToolStripMenuItem_Click);
            // 
            // giớiThiệuToolStripMenuItem
            // 
            this.giớiThiệuToolStripMenuItem.Name = "giớiThiệuToolStripMenuItem";
            this.giớiThiệuToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.giớiThiệuToolStripMenuItem.Text = "&Giới thiệu";
            this.giớiThiệuToolStripMenuItem.Click += new System.EventHandler(this.giớiThiệuToolStripMenuItem_Click);
            // 
            // bậtTắtNhạcToolStripMenuItem
            // 
            this.bậtTắtNhạcToolStripMenuItem.Name = "bậtTắtNhạcToolStripMenuItem";
            this.bậtTắtNhạcToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.bậtTắtNhạcToolStripMenuItem.Text = "&Bật/Tắt nhạc";
            this.bậtTắtNhạcToolStripMenuItem.Click += new System.EventHandler(this.bậtTắtNhạcToolStripMenuItem_Click);
            // 
            // CaroGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 522);
            this.Controls.Add(this.pnl_BangDieuKhien);
            this.Controls.Add(this.pnl_BanCo);
            this.Controls.Add(this.menu_CaiDat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_CaiDat;
            this.Name = "CaroGame";
            this.Text = "CaroGame";
            this.Load += new System.EventHandler(this.CaroGame_Load);
            this.pnl_BangDieuKhien.ResumeLayout(false);
            this.pnl_BangDieuKhien.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menu_CaiDat.ResumeLayout(false);
            this.menu_CaiDat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnl_BangDieuKhien;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menu_CaiDat;
        private System.Windows.Forms.ToolStripMenuItem càiĐặtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem luậtChơiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giớiThiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bậtTắtNhạcToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton radioO;
        public System.Windows.Forms.RadioButton radioX;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Panel pnl_BanCo;
        public System.Windows.Forms.Button btn_ChoiLai;
        public System.Windows.Forms.Button btn_HuyVan;
        public System.Windows.Forms.Button btn_PvP;
        public System.Windows.Forms.Button btn_PvM;
        public System.Windows.Forms.Label lblLuotDi;
    }
}