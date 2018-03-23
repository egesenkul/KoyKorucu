using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
using System.Xml;

namespace YasarKoyKoruyucu
{
    public partial class KoruyucuListesi : DevExpress.XtraEditors.XtraForm
    {
        List<Koruyucu> koruyucuListesi = new List<Koruyucu>();

        string KoruyucuAdi = "";
        string KoruyucuSoyadi = "";
        string KoruyucuTC = "";
        string KoruyucuGorev = "";
        string KoruyucuTuru = "";
        DateTime KoruyucuGorevTarih = DateTime.Now;
        string KoruyucuGorevYer = "";

        public KoruyucuListesi()
        {
            InitializeComponent();
        }

        public void RefreshGridview()
        {
            try { 
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular";
            foreach (string file in Directory.EnumerateFiles(executableLocation, "*.xml"))
            {
                XmlTextReader oku = new XmlTextReader(file);
                try
                {
                    while (oku.Read()) //Dosyadaki veriler tükenene kadar okuma işlemi devam eder.
                    {
                        if (oku.NodeType == XmlNodeType.Element)//Düğümlerdeki veri element türünde ise okuma gerçekleşir.
                        {
                            switch (oku.Name)//Elementlerin isimlerine göre okuma işlemi gerçekleşir.
                            {
                                case "KoruyucuAdı":
                                    KoruyucuAdi = Convert.ToString(oku.ReadString());
                                    break;
                                case "KoruyucuSoyadı":
                                    KoruyucuSoyadi = Convert.ToString(oku.ReadString());
                                    break;
                                case "KoruyucuTCNo":
                                    KoruyucuTC = Convert.ToString(oku.ReadString());
                                    break;
                                case "Görevi":
                                    KoruyucuGorev = Convert.ToString(oku.ReadString());
                                    break;
                                    case "GörevYeri":
                                    KoruyucuGorevYer = Convert.ToString(oku.ReadString());
                                    break;
                                case "GörevTarihi":
                                    KoruyucuGorevTarih = Convert.ToDateTime(oku.ReadString());
                                    break;
                                    case "GörevTürü":
                                        KoruyucuTuru = Convert.ToString(oku.ReadString());
                                        break;
                                }
                        }
                    }
                    koruyucuListesi.Add(new Koruyucu(KoruyucuAdi, KoruyucuSoyadi, KoruyucuTC, KoruyucuGorev, KoruyucuGorevYer, KoruyucuGorevTarih, KoruyucuTuru));

                    oku.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Xml Bağlantı Hatası : " + ex.Message);
                }
            }

                //gridview.DataSource = koruyucuListesi;
                gridControl1.DataSource = koruyucuListesi;
                //gridview.Columns[0].HeaderText = "Koruyucu Adı";
                //gridview.Columns[1].HeaderText = "Koruyucu Soyadı";
                //gridview.Columns[2].HeaderText = "Koruyucu TC Kimlik No";
                //gridview.Columns[3].HeaderText = "Koruyucu Görevi";
                //gridview.Columns[4].HeaderText = "Koruyucu Görev Veriliş Yeri";
                //gridview.Columns[5].HeaderText = "Koruyucu Görev Başlangıç Tarihi";
                //gridview.Columns[6].HeaderText = "Koruyucu Türü";


                //    gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void KoruyucuListesi_Load(object sender, EventArgs e)
        {
            RefreshGridview();
        }

  

        private void koruyucuyuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
             try
            {
                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular";
                string xslLocation = Path.Combine(executableLocation, gridView1.GetFocusedRowCellValue("KoruyucuAdı").ToString() + " " + gridView1.GetFocusedRowCellValue("KoruyucuSoyadı").ToString() + " " + gridView1.GetFocusedRowCellValue("KoruyucuTCNO").ToString() + ".xml");
                string adres2 = Path.Combine(executableLocation, gridView1.GetFocusedRowCellValue("KoruyucuAdı").ToString() + " " + gridView1.GetFocusedRowCellValue("KoruyucuSoyadı").ToString() + " " + gridView1.GetFocusedRowCellValue("KoruyucuTCNO").ToString() + ".jpg");
                string adres3 = Path.Combine(executableLocation, gridView1.GetFocusedRowCellValue("KoruyucuAdı").ToString() + " " + gridView1.GetFocusedRowCellValue("KoruyucuSoyadı").ToString() + " " + gridView1.GetFocusedRowCellValue("KoruyucuTCNO").ToString() + " gorev.txt");

                if (File.Exists(xslLocation))
                {
                    File.Delete(xslLocation);
                }
                if (File.Exists(adres2))
                {
                    File.Delete(adres2);
                }
                if (File.Exists(adres3))
                {
                    File.Delete(adres3);
                }
                MessageBox.Show("Güvenlik Koruyucusu Başarı ile Silinmiştir.");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {


            try
            {
                string silKod = gridView1.GetFocusedRowCellValue("KoruyucuTur").ToString();

                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular";
                string xslLocation = Path.Combine(executableLocation, gridView1.GetFocusedRowCellValue("KoruyucuAdı").ToString() + " " + gridView1.GetFocusedRowCellValue("KoruyucuSoyadı").ToString() + " " + gridView1.GetFocusedRowCellValue("KoruyucuTCNO").ToString() + ".xml");
                KoruyucuOlustur duzenle = new KoruyucuOlustur(xslLocation);
                this.Close();
                duzenle.Show();

            }
            catch (Exception ex) {
                MessageBox.Show("Lütfen bir görev koruyucu üzerine çift basın.");
            }
        }
        

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void görevEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GorevEkle gorevEkle = new GorevEkle(gridView1.GetFocusedRowCellValue("KoruyucuAdı").ToString(), gridView1.GetFocusedRowCellValue("KoruyucuSoyadı").ToString(), gridView1.GetFocusedRowCellValue("KoruyucuTCNO").ToString());
            gorevEkle.Show();
        }

        public void Excel2007(string RaporAdi, DevExpress.XtraGrid.GridControl Liste)
        {
            SaveFileDialog Save = new SaveFileDialog();
            Save.Filter = "Excel 2007 | *.xlsx";
            Save.FileName = RaporAdi;
            if (Save.ShowDialog() == DialogResult.OK)
            {
                Liste.ExportToXlsx(Save.FileName);
                Process.Start(Save.FileName);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Excel2007("Korucu Listesi", gridControl1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
