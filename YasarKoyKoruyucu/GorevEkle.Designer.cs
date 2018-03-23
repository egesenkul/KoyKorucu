namespace YasarKoyKoruyucu
{
    partial class GorevEkle
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtGorevBitTarihi = new DevExpress.XtraEditors.DateEdit();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ListeGorevler = new System.Windows.Forms.ListView();
            this.lblKoruyucuAdı = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBagliYer = new MetroFramework.Controls.MetroLabel();
            this.lblAd = new MetroFramework.Controls.MetroLabel();
            this.lblSoyad = new MetroFramework.Controls.MetroLabel();
            this.txtAd = new MetroFramework.Controls.MetroTextBox();
            this.dtGorevTarihi = new DevExpress.XtraEditors.DateEdit();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.göreviSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.göreviDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGorevBitTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGorevBitTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGorevTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGorevTarihi.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.metroLabel2);
            this.panel1.Controls.Add(this.dtGorevBitTarihi);
            this.panel1.Controls.Add(this.metroLabel3);
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Controls.Add(this.metroButton3);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.ListeGorevler);
            this.panel1.Controls.Add(this.lblKoruyucuAdı);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblBagliYer);
            this.panel1.Controls.Add(this.lblAd);
            this.panel1.Controls.Add(this.lblSoyad);
            this.panel1.Controls.Add(this.txtAd);
            this.panel1.Controls.Add(this.dtGorevTarihi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 418);
            this.panel1.TabIndex = 0;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(376, 165);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(145, 25);
            this.metroLabel2.TabIndex = 110;
            this.metroLabel2.Text = "Görev Bitiş Tarihi:";
            // 
            // dtGorevBitTarihi
            // 
            this.dtGorevBitTarihi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGorevBitTarihi.EditValue = null;
            this.dtGorevBitTarihi.Location = new System.Drawing.Point(613, 164);
            this.dtGorevBitTarihi.Margin = new System.Windows.Forms.Padding(2);
            this.dtGorevBitTarihi.Name = "dtGorevBitTarihi";
            this.dtGorevBitTarihi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtGorevBitTarihi.Properties.Appearance.Options.UseFont = true;
            this.dtGorevBitTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtGorevBitTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtGorevBitTarihi.Properties.CalendarTimeProperties.EditFormat.FormatString = "G";
            this.dtGorevBitTarihi.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtGorevBitTarihi.Properties.CalendarTimeProperties.Mask.EditMask = "G";
            this.dtGorevBitTarihi.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dtGorevBitTarihi.Properties.DisplayFormat.FormatString = "g";
            this.dtGorevBitTarihi.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtGorevBitTarihi.Properties.EditFormat.FormatString = "g";
            this.dtGorevBitTarihi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtGorevBitTarihi.Properties.Mask.EditMask = "f";
            this.dtGorevBitTarihi.Properties.NullDate = new System.DateTime(2017, 11, 30, 13, 12, 44, 361);
            this.dtGorevBitTarihi.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dtGorevBitTarihi.Size = new System.Drawing.Size(269, 26);
            this.dtGorevBitTarihi.TabIndex = 109;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(61, 283);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(160, 25);
            this.metroLabel3.TabIndex = 108;
            this.metroLabel3.Text = "Bağlı Olduğu Yer:";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(376, 359);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(138, 30);
            this.metroButton1.TabIndex = 107;
            this.metroButton1.Text = "Yazdır";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(679, 212);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(138, 30);
            this.metroButton3.TabIndex = 106;
            this.metroButton3.Text = "Görev Ekle";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(376, 266);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(115, 25);
            this.metroLabel1.TabIndex = 105;
            this.metroLabel1.Text = "Görev Listesi:";
            // 
            // ListeGorevler
            // 
            this.ListeGorevler.Location = new System.Drawing.Point(613, 266);
            this.ListeGorevler.MultiSelect = false;
            this.ListeGorevler.Name = "ListeGorevler";
            this.ListeGorevler.Size = new System.Drawing.Size(269, 123);
            this.ListeGorevler.TabIndex = 104;
            this.ListeGorevler.TileSize = new System.Drawing.Size(200, 30);
            this.ListeGorevler.UseCompatibleStateImageBehavior = false;
            this.ListeGorevler.View = System.Windows.Forms.View.List;
            this.ListeGorevler.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListeGorevler_MouseClick);
            // 
            // lblKoruyucuAdı
            // 
            this.lblKoruyucuAdı.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKoruyucuAdı.AutoSize = true;
            this.lblKoruyucuAdı.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblKoruyucuAdı.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblKoruyucuAdı.Location = new System.Drawing.Point(65, 245);
            this.lblKoruyucuAdı.Name = "lblKoruyucuAdı";
            this.lblKoruyucuAdı.Size = new System.Drawing.Size(128, 25);
            this.lblKoruyucuAdı.TabIndex = 103;
            this.lblKoruyucuAdı.Text = "Koruyucu Adı";
            this.lblKoruyucuAdı.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(51, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 200);
            this.pictureBox1.TabIndex = 100;
            this.pictureBox1.TabStop = false;
            // 
            // lblBagliYer
            // 
            this.lblBagliYer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBagliYer.AutoSize = true;
            this.lblBagliYer.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblBagliYer.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblBagliYer.Location = new System.Drawing.Point(61, 321);
            this.lblBagliYer.Name = "lblBagliYer";
            this.lblBagliYer.Size = new System.Drawing.Size(147, 25);
            this.lblBagliYer.TabIndex = 102;
            this.lblBagliYer.Text = "Bağlı Olduğu Yer:";
            this.lblBagliYer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAd
            // 
            this.lblAd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAd.AutoSize = true;
            this.lblAd.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAd.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAd.Location = new System.Drawing.Point(376, 42);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(151, 25);
            this.lblAd.TabIndex = 28;
            this.lblAd.Text = "Görev Açıklaması:";
            // 
            // lblSoyad
            // 
            this.lblSoyad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSoyad.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblSoyad.Location = new System.Drawing.Point(376, 110);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(186, 25);
            this.lblSoyad.TabIndex = 29;
            this.lblSoyad.Text = "Görev Başlangıç Tarihi:";
            // 
            // txtAd
            // 
            this.txtAd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAd.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtAd.Location = new System.Drawing.Point(613, 37);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(269, 30);
            this.txtAd.TabIndex = 5;
            // 
            // dtGorevTarihi
            // 
            this.dtGorevTarihi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGorevTarihi.EditValue = null;
            this.dtGorevTarihi.Location = new System.Drawing.Point(613, 107);
            this.dtGorevTarihi.Margin = new System.Windows.Forms.Padding(2);
            this.dtGorevTarihi.Name = "dtGorevTarihi";
            this.dtGorevTarihi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtGorevTarihi.Properties.Appearance.Options.UseFont = true;
            this.dtGorevTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtGorevTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtGorevTarihi.Properties.CalendarTimeProperties.EditFormat.FormatString = "G";
            this.dtGorevTarihi.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtGorevTarihi.Properties.CalendarTimeProperties.Mask.EditMask = "G";
            this.dtGorevTarihi.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dtGorevTarihi.Properties.DisplayFormat.FormatString = "g";
            this.dtGorevTarihi.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtGorevTarihi.Properties.EditFormat.FormatString = "g";
            this.dtGorevTarihi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtGorevTarihi.Properties.Mask.EditMask = "f";
            this.dtGorevTarihi.Properties.NullDate = new System.DateTime(2017, 11, 30, 13, 12, 44, 361);
            this.dtGorevTarihi.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dtGorevTarihi.Size = new System.Drawing.Size(269, 26);
            this.dtGorevTarihi.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.göreviSilToolStripMenuItem,
            this.göreviDüzenleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 48);
            // 
            // göreviSilToolStripMenuItem
            // 
            this.göreviSilToolStripMenuItem.Name = "göreviSilToolStripMenuItem";
            this.göreviSilToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.göreviSilToolStripMenuItem.Text = "Görevi Sil";
            this.göreviSilToolStripMenuItem.Click += new System.EventHandler(this.göreviSilToolStripMenuItem_Click);
            // 
            // göreviDüzenleToolStripMenuItem
            // 
            this.göreviDüzenleToolStripMenuItem.Name = "göreviDüzenleToolStripMenuItem";
            this.göreviDüzenleToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.göreviDüzenleToolStripMenuItem.Text = "Görevi Düzenle";
            this.göreviDüzenleToolStripMenuItem.Click += new System.EventHandler(this.göreviDüzenleToolStripMenuItem_Click);
            // 
            // GorevEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 498);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "GorevEkle";
            this.Resizable = false;
            this.Text = "Görev Ekle";
            this.Load += new System.EventHandler(this.GorevEkle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGorevBitTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGorevBitTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGorevTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGorevTarihi.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTextBox txtAd;
        private DevExpress.XtraEditors.DateEdit dtGorevTarihi;
        private MetroFramework.Controls.MetroLabel lblAd;
        private MetroFramework.Controls.MetroLabel lblSoyad;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ListView ListeGorevler;
        private MetroFramework.Controls.MetroLabel lblKoruyucuAdı;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel lblBagliYer;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem göreviSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem göreviDüzenleToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private DevExpress.XtraEditors.DateEdit dtGorevBitTarihi;
    }
}