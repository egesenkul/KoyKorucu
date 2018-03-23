using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YasarKoyKoruyucu
{
    public partial class GorevEkle : MetroFramework.Forms.MetroForm
    {
        string KorucuAdı = "";
        string KorucuSoyadı = "";
        string KorucuTC = "";
        Image bmp;

        public GorevEkle()
        {
            InitializeComponent();
        }
        public GorevEkle(string ad, string soyad, string tc)
        {
            KorucuAdı = ad;
            KorucuSoyadı = soyad;
            KorucuTC = tc;
            InitializeComponent();
        }

        private void GorevEkle_Load(object sender, EventArgs e)
        {
            dtGorevTarihi.EditValue = DateTime.Now;
            dtGorevTarihi.Properties.VistaDisplayMode = DefaultBoolean.True;
            dtGorevTarihi.Properties.VistaEditTime = DefaultBoolean.True;
            dtGorevBitTarihi.EditValue = DateTime.Now;
            dtGorevBitTarihi.Properties.VistaDisplayMode = DefaultBoolean.True;
            dtGorevBitTarihi.Properties.VistaEditTime = DefaultBoolean.True;
            string yol = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular" + "\\" + KorucuAdı + " " + KorucuSoyadı + " " + KorucuTC  + ".jpg";
            if (File.Exists(yol))
            {
                bmp = Bitmap.FromFile(yol);
                Bitmap resim_kopya = new Bitmap(bmp);
                pictureBox1.Image = resim_kopya;
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            lblKoruyucuAdı.Text = KorucuAdı + " " + KorucuSoyadı;
            ListeGuncelle();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListeGuncelle()
        {
            ListeGorevler.Items.Clear();
            int i = 0;
            string xslLocation2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular", KorucuAdı + " " + KorucuSoyadı + " " + KorucuTC);
            var lines = File.ReadLines(xslLocation2 + " gorev.txt");
            foreach (var line in lines)
            {
                if (i != 0)
                {
                    ListeGorevler.Items.Add(line);
                }
                else
                {
                    string[] parcalar = line.Split(' ');
                    lblBagliYer.Text = parcalar[3];
                    if (string.IsNullOrEmpty(lblBagliYer.Text))
                    {
                        lblBagliYer.Text = "Belirtilmemiş";
                    }
                }
                i++;
                }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAd.Text))
            {
                MessageBox.Show("Görev açıklaması boş olamaz.");
            }
            else
            {
                if (!string.Equals(metroButton3.Text, "Görev Güncelle")){
                    string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular";
                    string xslLocation = Path.Combine(executableLocation, KorucuAdı + " " + KorucuSoyadı + " " + KorucuTC);
                    using (StreamWriter writetext = new StreamWriter(xslLocation + " gorev.txt", true))
                    {
                        writetext.WriteLine(dtGorevTarihi.EditValue.ToString() + " "+dtGorevBitTarihi.EditValue+" " + txtAd.Text);
                    }
                    ListeGuncelle();
                }
                else
                {
                    string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular";
                    string xslLocation = Path.Combine(executableLocation, KorucuAdı + " " + KorucuSoyadı + " " + KorucuTC);
                    var tempFile = Path.GetTempFileName();
                    var linesToKeep = File.ReadLines(xslLocation + " gorev.txt").Where(l => l != ListeGorevler.SelectedItems[0].Text);

                    File.WriteAllLines(tempFile, linesToKeep);

                    File.Delete(xslLocation + " gorev.txt");
                    File.Move(tempFile, xslLocation + " gorev.txt");
                    metroButton3.Text = "Görev Ekle";
                    metroButton3.PerformClick();
                }
            }
            txtAd.Text = "";
            dtGorevTarihi.EditValue = DateTime.Now;
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular";
            string xslLocation = Path.Combine(executableLocation, KorucuAdı + " " + KorucuSoyadı + " " + KorucuTC);
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(xslLocation + " gorev.txt");
            psi.Verb = "PRINT";

            Process.Start(psi);
        }

        private void göreviSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular";
            string xslLocation = Path.Combine(executableLocation, KorucuAdı + " " + KorucuSoyadı + " " + KorucuTC);
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(xslLocation + " gorev.txt").Where(l => l != ListeGorevler.SelectedItems[0].Text);

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(xslLocation + " gorev.txt");
            File.Move(tempFile, xslLocation + " gorev.txt");
            ListeGuncelle();
        }

        private void ListeGorevler_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void göreviDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] parcalar = ListeGorevler.SelectedItems[0].Text.Split(' ');
            txtAd.Text = parcalar[4];
            dtGorevTarihi.EditValue = Convert.ToDateTime(parcalar[0] + " "+ parcalar[1]);
            dtGorevBitTarihi.EditValue = Convert.ToDateTime(parcalar[2] + " " + parcalar[3]);
            metroButton3.Text = "Görev Güncelle";
        }
    }
}
