namespace YasarKoyKoruyucu
{
    partial class Form1
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileItem1 = new DevExpress.XtraEditors.TileItem();
            this.btnKoruyuListesi = new DevExpress.XtraEditors.TileItem();
            this.btnKapat = new DevExpress.XtraEditors.TileItem();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tileControl1
            // 
            this.tileControl1.BackgroundImage = global::YasarKoyKoruyucu.Properties.Resources.Anaform_Arkaplan;
            this.tileControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl1.DragSize = new System.Drawing.Size(0, 0);
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.ItemSize = 180;
            this.tileControl1.Location = new System.Drawing.Point(20, 60);
            this.tileControl1.MaxId = 6;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Size = new System.Drawing.Size(1326, 688);
            this.tileControl1.TabIndex = 0;
            this.tileControl1.Text = "tileControl1";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileItem1);
            this.tileGroup2.Items.Add(this.btnKoruyuListesi);
            this.tileGroup2.Items.Add(this.btnKapat);
            this.tileGroup2.Name = "tileGroup2";
            // 
            // tileItem1
            // 
            this.tileItem1.AppearanceItem.Normal.BackColor = System.Drawing.Color.Linen;
            this.tileItem1.AppearanceItem.Normal.BackColor2 = System.Drawing.SystemColors.ControlDark;
            this.tileItem1.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.tileItem1.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
            this.tileItem1.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItem1.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItem1.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement1.Text = "Güvenlik Korucusu Oluştur";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem1.Elements.Add(tileItemElement1);
            this.tileItem1.Id = 5;
            this.tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem1.Name = "tileItem1";
            this.tileItem1.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem1_ItemClick_1);
            // 
            // btnKoruyuListesi
            // 
            this.btnKoruyuListesi.AppearanceItem.Normal.BackColor = System.Drawing.Color.Linen;
            this.btnKoruyuListesi.AppearanceItem.Normal.BackColor2 = System.Drawing.SystemColors.ControlDark;
            this.btnKoruyuListesi.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnKoruyuListesi.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
            this.btnKoruyuListesi.AppearanceItem.Normal.Options.UseBackColor = true;
            this.btnKoruyuListesi.AppearanceItem.Normal.Options.UseFont = true;
            this.btnKoruyuListesi.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement2.Text = "Güvenlik Korucusu Listesi";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.btnKoruyuListesi.Elements.Add(tileItemElement2);
            this.btnKoruyuListesi.Id = 1;
            this.btnKoruyuListesi.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.btnKoruyuListesi.Name = "btnKoruyuListesi";
            this.btnKoruyuListesi.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.btnKoruyuListesi_ItemClick);
            // 
            // btnKapat
            // 
            this.btnKapat.AppearanceItem.Normal.BackColor = System.Drawing.Color.Linen;
            this.btnKapat.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.Red;
            this.btnKapat.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Red;
            this.btnKapat.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnKapat.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
            this.btnKapat.AppearanceItem.Normal.Options.UseBackColor = true;
            this.btnKapat.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.btnKapat.AppearanceItem.Normal.Options.UseFont = true;
            this.btnKapat.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement3.Text = "Kapat";
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.btnKapat.Elements.Add(tileItemElement3);
            this.btnKapat.Id = 2;
            this.btnKapat.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.btnKapat_ItemClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(778, 735);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bu program Kamışlı Karakol Komutanı Ahmet Sarmısak isteği üzerine Yaşar Köstekli " +
    "ve Ege Şenkul tarafından yapılmıştır.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YasarKoyKoruyucu.Properties.Resources.Arkaplan;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tileControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Text = "Güvelik Korucusu Takip";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem btnKoruyuListesi;
        private DevExpress.XtraEditors.TileItem btnKapat;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TileItem tileItem1;
    }
}

