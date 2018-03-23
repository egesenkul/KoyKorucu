using DevExpress.Utils;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using YasarKoyKoruyucu.Properties;

namespace YasarKoyKoruyucu
{
    public partial class KoruyucuOlustur : MetroFramework.Forms.MetroForm
    {
        string imgLoc = "";
        string XmlAdresi = "";
        int CocukDuzenle = 0;
        string eskiAd = "";
        string eskiSoyad = "";
        string eskiTC = "";
        Image bmp;

        public KoruyucuOlustur()
        {
            InitializeComponent();
        }

        public KoruyucuOlustur(string xmlAdresi)
        {
            InitializeComponent();
            XmlAdresi = xmlAdresi;
        }

        private void KoruyucuOlustur_Load(object sender, EventArgs e)
        {
            dtDogumTarihi.EditValue = DateTime.Now;
            dtDogumTarihi.Properties.VistaDisplayMode = DefaultBoolean.True;
            dtDogumTarihi.Properties.VistaEditTime = DefaultBoolean.True;
            dtGorevVerilisTarihi.EditValue = DateTime.Now;
            dtGorevVerilisTarihi.Properties.VistaDisplayMode = DefaultBoolean.True;
            dtGorevVerilisTarihi.Properties.VistaEditTime = DefaultBoolean.True;
            cmbCinsiyet.Items.Add("Bay");
            cmbCinsiyet.Items.Add("Bayan");
            cmbKoruyucuKanGrubu.Items.Add("A RH(+)");
            cmbKoruyucuKanGrubu.Items.Add("A RH(-)");
            cmbKoruyucuKanGrubu.Items.Add("B RH(+)");
            cmbKoruyucuKanGrubu.Items.Add("B RH(-)");
            cmbKoruyucuKanGrubu.Items.Add("AB RH(+)");
            cmbKoruyucuKanGrubu.Items.Add("AB RH(-)");
            cmbKoruyucuKanGrubu.Items.Add("0 RH(+)");
            cmbKoruyucuKanGrubu.Items.Add("0 RH(-)");
            cmbCinsiyet.SelectedIndex = 0;
            cmbKoruyucuKanGrubu.SelectedIndex = 0;
            btnKoruyucuOlustur.ForeColor = Color.Green;
            cmbGorevAktif.Items.Add("Aktif");
            cmbGorevAktif.Items.Add("Pasif");
            cmbGorevAktif.SelectedIndex = 0;
            cmbKoruyucuTürü.Items.Add("Daimi");
            cmbKoruyucuTürü.Items.Add("Gönüllü");
            cmbKoruyucuTürü.SelectedIndex = 0;

            if (!string.Equals(XmlAdresi, "")) {
                metroButton3.Text = "Koruyucu Güncelle";
                BilgiDoldur();
            }
            
            
        }

        private void btnGozat_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog imageSelect = new OpenFileDialog();
                imageSelect.Title = "Otel Logosu Seçiniz";
                imageSelect.Filter = "Image Files (*.png *.jpg *.bmp) |*.png; *.jpg; *.bmp|All Files(*.*) |*.*";
                if (imageSelect.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = imageSelect.FileName.ToString();
                }

                pictureBox1.Image = Image.FromFile(imgLoc);
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                //pictureBox1.Image.Save(Application.StartupPath + "\\" + txtAd.Text + " " + txtSoyad.Text + ".jpg");
            }
            catch(Exception ex)
            {

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CocukKontrol()
        {
            if (string.IsNullOrEmpty(txtCocukAdi.Text) || string.IsNullOrEmpty(txtCocukKimlikNo.Text) || string.IsNullOrEmpty(txtCocukSoyadi.Text))
            {
                return false;
            }
            return true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (CocukKontrol())
            {
                if (CocukDuzenle == 0)
                {
                    CocukListesi.Items.Add(txtCocukAdi.Text + " " + txtCocukSoyadi.Text + " " + txtCocukKimlikNo.Text);
                }
                else
                {
                    CocukListesi.SelectedItems[0].Remove();
                    CocukListesi.Items.Add(txtCocukAdi.Text + " " + txtCocukSoyadi.Text + " " + txtCocukKimlikNo.Text);
                    CocukDuzenle = 0;
                }
            }
            txtTemizle(txtCocukAdi, txtCocukSoyadi, txtCocukKimlikNo);
        }

        private void CocukListesi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string[] parcalar;
            parcalar = CocukListesi.SelectedItems[0].Text.Split(' ');
            txtCocukAdi.Text = parcalar[0];
            txtCocukSoyadi.Text = parcalar[1];
            txtCocukKimlikNo.Text = parcalar[2];
            CocukDuzenle = 1;
        }

        private void txtTemizle(params MetroTextBox[] i)
        {
            foreach (MetroTextBox item in i)
            {
                item.Text = "";
            }
        }

        private bool KoruyucuKontrol()
        {
            if(string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtKoruyucuTCNo.Text) || string.IsNullOrEmpty(txtSoyad.Text))
            {
                MessageBox.Show("Korucu adı, soyadı ve TC kimlik numarası boş geçilemez.");
                return false;
            }
            if(File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular"+ txtAd.Text + " " + txtSoyad.Text + " " + txtKoruyucuTCNo.Text + ".xml")))
            {
                MessageBox.Show("Bu korucu daha önceden oluşturulmuştur.");
                return false;
            }
            if (txtKoruyucuTCNo.Text.Length != 11)
            {
                MessageBox.Show("Güvenlik korucu TC kimlik numarası 11 haneli olmalıdır.");
                return false;
            }
            return true;
        }

        private void BilgiDoldur()
        {
            XmlTextReader oku = new XmlTextReader(XmlAdresi);
            try
            {
                while (oku.Read()) //Dosyadaki veriler tükenene kadar okuma işlemi devam eder.
                {
                    if (oku.NodeType == XmlNodeType.Element)//Düğümlerdeki veri element türünde ise okuma gerçekleşir.
                    {
                        switch (oku.Name)//Elementlerin isimlerine göre okuma işlemi gerçekleşir.
                        {
                            case "KoruyucuAdı":
                                txtAd.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "KoruyucuSoyadı":
                                txtSoyad.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "KoruyucuCinsiyeti":
                                cmbCinsiyet.SelectedText = Convert.ToString(oku.ReadString());
                                break;
                            case "KoruyucuDogumYeri":
                                 txtKoruyucuDogumYeri.Text= Convert.ToString(oku.ReadString());
                                break;
                            case "KoruyucuDogumTarihi":
                                dtDogumTarihi.EditValue = Convert.ToDateTime(oku.ReadString());
                                break;
                            case "KoruyucuAnneAdı":
                                txtKoruyucuAnneAdi.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "KoruyucuBabaAdı":
                                txtKoruyucuBabaAdi.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "KoruyucuTCNo":
                                txtKoruyucuTCNo.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "MedeniHali":
                                txtKoruyucuMedeniHali.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "Dini":
                                txtKoruyucuDini.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "KanGrubu":
                                cmbKoruyucuKanGrubu.SelectedItem = Convert.ToString(oku.ReadString());
                                break;
                            case "Kayıtlıil":
                                txtKoruyucukKayitliIl.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "Kayıtlıilce":
                                txtKoruyucuKayitliIlce.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "KayıtlıKoy":
                                txtKoruyucuKayitliKoy.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "EsAdi":
                                txtEsAdi.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "EsSoyadi":
                                txtEsSoyadi.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "EsTCNo":
                                txtEsKimlikNo.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "Görevi":
                                cmbKoruyucuKanGrubu.SelectedItem = Convert.ToString(oku.ReadString());
                                break;
                            case "GörevYeri":
                                txtGorevVerilisYeri.Text = Convert.ToString(oku.ReadString());
                                break;
                            case "GörevTürü":
                                cmbKoruyucuTürü.SelectedItem = Convert.ToString(oku.ReadString());
                                break;
                            case "GörevTarihi":
                                dtGorevVerilisTarihi.EditValue = Convert.ToDateTime(oku.ReadString());
                                break;
                            case "Cocuklar":
                                string[] parcalar = Convert.ToString(oku.ReadString()).Split('+');
                                for(int i = 0; i < parcalar.Length; i++)
                                {
                                    //cocuk += parcalar[i] + " " + parcalar[i + 1] + " " + parcalar[i + 2];
                                    CocukListesi.Items.Add(parcalar[i]);
                                    //cocuk = "";
                                }
                                    break;
                        }
                    }
                }

                oku.Close();
                eskiAd = txtAd.Text;
                eskiSoyad = txtSoyad.Text;
                eskiTC = txtKoruyucuTCNo.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xml Bağlantı Hatası : " + ex.Message);
            }
            try
            {
             
                string yol = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular" + "\\" + txtAd.Text + " " + txtSoyad.Text + " " + txtKoruyucuTCNo.Text + ".jpg";
                if (File.Exists(yol))
                {
                    bmp = Bitmap.FromFile(yol);
                    Bitmap resim_kopya = new Bitmap(bmp);

                    pictureBox1.Image = resim_kopya;
                    //pictureBox1.Image = Image.FromFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular" + "\\" + txtAd.Text + " " + txtSoyad.Text +" "+txtKoruyucuTCNo.Text+ ".jpg");
                    pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            oku.Close();
        }

        private void btnKoruyucuOlustur_Click(object sender, EventArgs e)
        {
            
                if (string.Equals(XmlAdresi, ""))
                {
                    if (KoruyucuKontrol())
                    {
                        string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular";
                    bool exists = System.IO.Directory.Exists(executableLocation );

                    if (!exists)
                        System.IO.Directory.CreateDirectory(executableLocation);
                    string xslLocation = Path.Combine(executableLocation, txtAd.Text + " " + txtSoyad.Text + " " + txtKoruyucuTCNo.Text);
                        XmlTextWriter xmlolustur = new XmlTextWriter(xslLocation + ".xml", UTF8Encoding.UTF8);//Dosyanın oluşturulacağı dizin,Kodlaması
                        xmlolustur.WriteStartDocument();//Xml içine Element Oluşturma işlemine başlanıyor.
                        xmlolustur.WriteComment("Koruyucu Bilgileri");//Dosya içine açıklama satırı ekledik.
                        xmlolustur.WriteStartElement("koruyucu");//item Etiketi ekledik.
                        xmlolustur.WriteEndDocument();//Element Oluşturma işlemi bitti.
                        xmlolustur.Close();//Dosya oluşturuldu ve bağlantı kapatıldı.

                        XmlDocument doc = new XmlDocument();
                        doc.Load(xslLocation + ".xml");
                        XmlElement UserElement = doc.CreateElement("Kullanicilar");//Element Ekledik.
                        UserElement.SetAttribute("item", Guid.NewGuid().ToString());//elemente bir attribute atadık

                        XmlElement koruyucuadi = doc.CreateElement("KoruyucuAdı");//Kullanicilar elementi içine bir kayıt ekledik
                        koruyucuadi.InnerText = txtAd.Text;//kayıt için değer atadık
                        UserElement.AppendChild(koruyucuadi);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement koruyucusoyadi = doc.CreateElement("KoruyucuSoyadı");//Kullanicilar elementi içine bir kayıt ekledik
                        koruyucusoyadi.InnerText = txtSoyad.Text;//kayıt için değer atadık
                        UserElement.AppendChild(koruyucusoyadi);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement koruyucuCinsiyet = doc.CreateElement("KoruyucuCinsiyeti");//Kullanicilar elementi içine bir kayıt ekledik
                        koruyucuCinsiyet.InnerText = cmbCinsiyet.SelectedItem.ToString();//kayıt için değer atadık
                        UserElement.AppendChild(koruyucuCinsiyet);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement koruyucuDogumYeri = doc.CreateElement("KoruyucuDogumYeri");//Kullanicilar elementi içine bir kayıt ekledik
                        koruyucuDogumYeri.InnerText = txtKoruyucuDogumYeri.Text;//kayıt için değer atadık
                        UserElement.AppendChild(koruyucuDogumYeri);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement koruyucuDogumTarihi = doc.CreateElement("KoruyucuDogumTarihi");//Kullanicilar elementi içine bir kayıt ekledik
                        koruyucuDogumTarihi.InnerText = dtDogumTarihi.EditValue.ToString();//kayıt için değer atadık
                        UserElement.AppendChild(koruyucuDogumTarihi);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement koruyucuAnneAdi = doc.CreateElement("KoruyucuAnneAdı");//Kullanicilar elementi içine bir kayıt ekledik
                        koruyucuAnneAdi.InnerText = txtKoruyucuAnneAdi.Text;//kayıt için değer atadık
                        UserElement.AppendChild(koruyucuAnneAdi);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement koruyucuBabaAdi = doc.CreateElement("KoruyucuBabaAdı");//Kullanicilar elementi içine bir kayıt ekledik
                        koruyucuBabaAdi.InnerText = txtKoruyucuBabaAdi.Text;//kayıt için değer atadık
                        UserElement.AppendChild(koruyucuBabaAdi);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement koruyucuTCno = doc.CreateElement("KoruyucuTCNo");//Kullanicilar elementi içine bir kayıt ekledik
                        koruyucuTCno.InnerText = txtKoruyucuTCNo.Text;//kayıt için değer atadık
                        UserElement.AppendChild(koruyucuTCno);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement medeniHali = doc.CreateElement("MedeniHali");//Kullanicilar elementi içine bir kayıt ekledik
                        medeniHali.InnerText = txtKoruyucuMedeniHali.Text;//kayıt için değer atadık
                        UserElement.AppendChild(medeniHali);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement dini = doc.CreateElement("Dini");//Kullanicilar elementi içine bir kayıt ekledik
                        dini.InnerText = txtKoruyucuDini.Text;//kayıt için değer atadık
                        UserElement.AppendChild(dini);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement kanGrubu = doc.CreateElement("KanGrubu");//Kullanicilar elementi içine bir kayıt ekledik
                        kanGrubu.InnerText = cmbKoruyucuKanGrubu.SelectedItem.ToString();//kayıt için değer atadık
                        UserElement.AppendChild(kanGrubu);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement kayitliIl = doc.CreateElement("Kayıtlıil");//Kullanicilar elementi içine bir kayıt ekledik
                        kayitliIl.InnerText = txtKoruyucukKayitliIl.Text;//kayıt için değer atadık
                        UserElement.AppendChild(kayitliIl);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement kayitliIlce = doc.CreateElement("Kayıtlıilce");//Kullanicilar elementi içine bir kayıt ekledik
                        kayitliIlce.InnerText = txtKoruyucuKayitliIlce.Text;//kayıt için değer atadık
                        UserElement.AppendChild(kayitliIlce);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement kayitliKoy = doc.CreateElement("KayıtlıKoy");//Kullanicilar elementi içine bir kayıt ekledik
                        kayitliKoy.InnerText = txtKoruyucuKayitliKoy.Text;//kayıt için değer atadık
                        UserElement.AppendChild(kayitliKoy);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement esAdi = doc.CreateElement("EsAdi");//Kullanicilar elementi içine bir kayıt ekledik
                        esAdi.InnerText = txtEsAdi.Text;//kayıt için değer atadık
                        UserElement.AppendChild(esAdi);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement esSoyadi = doc.CreateElement("EsSoyadi");//Kullanicilar elementi içine bir kayıt ekledik
                        esSoyadi.InnerText = txtEsSoyadi.Text;//kayıt için değer atadık
                        UserElement.AppendChild(esSoyadi);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement esTCNo = doc.CreateElement("EsTCNo");//Kullanicilar elementi içine bir kayıt ekledik
                        esTCNo.InnerText = txtEsKimlikNo.Text;//kayıt için değer atadık
                        UserElement.AppendChild(esTCNo);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement gorevi = doc.CreateElement("Görevi");//Kullanicilar elementi içine bir kayıt ekledik
                        gorevi.InnerText = cmbGorevAktif.SelectedItem.ToString();//kayıt için değer atadık
                        UserElement.AppendChild(gorevi);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement gorevTuru = doc.CreateElement("GörevTürü");//Kullanicilar elementi içine bir kayıt ekledik
                        gorevTuru.InnerText = cmbKoruyucuTürü.SelectedItem.ToString();//kayıt için değer atadık
                        UserElement.AppendChild(gorevTuru);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement gorevVerilisYeri = doc.CreateElement("GörevYeri");//Kullanicilar elementi içine bir kayıt ekledik
                        gorevVerilisYeri.InnerText = txtGorevVerilisYeri.Text;//kayıt için değer atadık
                        UserElement.AppendChild(gorevVerilisYeri);//kayıt için parent atadık (UserElemet parenti)

                        XmlElement gorevVerilisTarihi = doc.CreateElement("GörevTarihi");//Kullanicilar elementi içine bir kayıt ekledik
                        gorevVerilisTarihi.InnerText = dtGorevVerilisTarihi.EditValue.ToString();//kayıt için değer atadık
                        UserElement.AppendChild(gorevVerilisTarihi);//kayıt için parent atadık (UserElemet parenti)


                        //Çocukları eklemeyi unutma
                        string cocukBilgileri = "";

                        XmlElement cocuklar = doc.CreateElement("Cocuklar");//Kullanicilar elementi içine bir kayıt ekledik
                        for (int i = 0; i < CocukListesi.Items.Count; i++)
                        {
                            cocukBilgileri += CocukListesi.Items[i].Text + "+";

                            cocuklar.InnerText = cocukBilgileri;//kayıt için değer atadık
                            UserElement.AppendChild(cocuklar);//kayıt için parent atadık (UserElemet parenti)
                        }

                        doc.DocumentElement.AppendChild(UserElement);//xml dosyamıza element ve kayıtları ekledik

                        XmlTextWriter xmleEkle = new XmlTextWriter(xslLocation + ".xml", null);//xml dosyamıza fiziksel olarak kayıtları yazıyoruz
                        xmleEkle.Formatting = Formatting.Indented;
                        doc.WriteContentTo(xmleEkle);//kayıtlar eklendi
                        xmleEkle.Close();//dosya kapatıldı

                    using(StreamWriter writetext = new StreamWriter(xslLocation+" gorev.txt"))
                    {
                        writetext.WriteLine(txtAd.Text+" "+txtSoyad.Text+" "+txtKoruyucuTCNo.Text+" "+txtGorevVerilisYeri.Text);
                    }


                    //bool exists2 = System.IO.Directory.Exists(executableLocation+"\\Gorevler");

                    //if (!exists2)
                    //    System.IO.Directory.CreateDirectory(executableLocation + "\\Gorevler");

                    //string xslLocation2 = Path.Combine(executableLocation+"\\Gorevler", txtAd.Text+ " " + txtSoyad.Text + " " + txtKoruyucuTCNo.Text+" gorevleri");
                    //XmlTextWriter xmlolustur2 = new XmlTextWriter(xslLocation2 + ".xml", UTF8Encoding.UTF8);//Dosyanın oluşturulacağı dizin,Kodlaması
                    //xmlolustur2.WriteStartDocument();//Xml içine Element Oluşturma işlemine başlanıyor.
                    //xmlolustur2.WriteComment("Korucu Görev Bilgileri");//Dosya içine açıklama satırı ekledik.
                    //xmlolustur2.WriteStartElement("gorev");//item Etiketi ekledik.
                    //xmlolustur2.WriteEndDocument();//Element Oluşturma işlemi bitti.
                    //xmlolustur2.Close();//Dosya oluşturuldu ve bağlantı kapatıldı.

                    //XmlDocument doc2 = new XmlDocument();
                    //doc2.Load(xslLocation2 + ".xml");
                    //XmlElement UserElement2 = doc2.CreateElement("gorevler");//Element Ekledik.
                    //UserElement2.SetAttribute("item", Guid.NewGuid().ToString());//elemente bir attribute atadık

                    //XmlTextWriter xmleEkle2 = new XmlTextWriter(xslLocation2 + ".xml", null);//xml dosyamıza fiziksel olarak kayıtları yazıyoruz
                    //xmleEkle2.Formatting = Formatting.Indented;
                    //doc2.WriteContentTo(xmleEkle2);//kayıtlar eklendi
                    //xmleEkle2.Close();//dosya kapatıldı


                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Save(executableLocation + "\\" + txtAd.Text + " " + txtSoyad.Text + " " + txtKoruyucuTCNo.Text + ".jpg");
                    }

                    MessageBox.Show("Koruyucu Oluşturulmuştur.");
                        txtTemizle(txtSoyad, txtKoruyucuTCNo, txtKoruyucuMedeniHali, txtKoruyucukKayitliIl, txtKoruyucuKayitliKoy, txtKoruyucuKayitliIlce, txtKoruyucuDogumYeri, txtKoruyucuDini, txtKoruyucuBabaAdi, txtKoruyucuAnneAdi,
                            txtGorevVerilisYeri, txtEsSoyadi, txtEsKimlikNo, txtEsAdi, txtCocukSoyadi, txtCocukKimlikNo, txtCocukAdi, txtAd);
                    cmbCinsiyet.SelectedIndex = 0;
                    cmbGorevAktif.SelectedIndex = 0;
                    cmbKoruyucuKanGrubu.SelectedIndex = 0;
                        CocukListesi.Items.Clear();
                        pictureBox1.Image = null;
                        xmleEkle.Close();
                    }

            }
            else
            { try {
                    if (File.Exists(XmlAdresi))
                    {
                        File.Delete(XmlAdresi);
                    }
                    
                    if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular" + "\\" + txtAd.Text + " " + txtSoyad.Text + " " + txtKoruyucuTCNo.Text + ".jpg")) {
                        bmp.Dispose();
                        File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular" + "\\" + txtAd.Text + " " + txtSoyad.Text + " " + txtKoruyucuTCNo.Text + ".jpg");
                    }

                    string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular";
                    string xslLocation = Path.Combine(executableLocation, txtAd.Text + " " + txtSoyad.Text + " " + txtKoruyucuTCNo.Text);
                    XmlTextWriter xmlolustur = new XmlTextWriter(xslLocation + ".xml", UTF8Encoding.UTF8);//Dosyanın oluşturulacağı dizin,Kodlaması
                    xmlolustur.WriteStartDocument();//Xml içine Element Oluşturma işlemine başlanıyor.
                    xmlolustur.WriteComment("Koruyucu Bilgileri");//Dosya içine açıklama satırı ekledik.
                    xmlolustur.WriteStartElement("koruyucu");//item Etiketi ekledik.
                    xmlolustur.WriteEndDocument();//Element Oluşturma işlemi bitti.
                    xmlolustur.Close();//Dosya oluşturuldu ve bağlantı kapatıldı.

                    XmlDocument doc = new XmlDocument();
                    doc.Load(xslLocation + ".xml");
                    XmlElement UserElement = doc.CreateElement("Kullanicilar");//Element Ekledik.
                    UserElement.SetAttribute("item", Guid.NewGuid().ToString());//elemente bir attribute atadık

                    XmlElement koruyucuadi = doc.CreateElement("KoruyucuAdı");//Kullanicilar elementi içine bir kayıt ekledik
                    koruyucuadi.InnerText = txtAd.Text;//kayıt için değer atadık
                    UserElement.AppendChild(koruyucuadi);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement koruyucusoyadi = doc.CreateElement("KoruyucuSoyadı");//Kullanicilar elementi içine bir kayıt ekledik
                    koruyucusoyadi.InnerText = txtSoyad.Text;//kayıt için değer atadık
                    UserElement.AppendChild(koruyucusoyadi);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement koruyucuCinsiyet = doc.CreateElement("KoruyucuCinsiyeti");//Kullanicilar elementi içine bir kayıt ekledik
                    koruyucuCinsiyet.InnerText = cmbCinsiyet.SelectedItem.ToString();//kayıt için değer atadık
                    UserElement.AppendChild(koruyucuCinsiyet);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement koruyucuDogumYeri = doc.CreateElement("KoruyucuDogumYeri");//Kullanicilar elementi içine bir kayıt ekledik
                    koruyucuDogumYeri.InnerText = txtKoruyucuDogumYeri.Text;//kayıt için değer atadık
                    UserElement.AppendChild(koruyucuDogumYeri);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement koruyucuDogumTarihi = doc.CreateElement("KoruyucuDogumTarihi");//Kullanicilar elementi içine bir kayıt ekledik
                    koruyucuDogumTarihi.InnerText = dtDogumTarihi.EditValue.ToString();//kayıt için değer atadık
                    UserElement.AppendChild(koruyucuDogumTarihi);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement koruyucuAnneAdi = doc.CreateElement("KoruyucuAnneAdı");//Kullanicilar elementi içine bir kayıt ekledik
                    koruyucuAnneAdi.InnerText = txtKoruyucuAnneAdi.Text;//kayıt için değer atadık
                    UserElement.AppendChild(koruyucuAnneAdi);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement koruyucuBabaAdi = doc.CreateElement("KoruyucuBabaAdı");//Kullanicilar elementi içine bir kayıt ekledik
                    koruyucuBabaAdi.InnerText = txtKoruyucuBabaAdi.Text;//kayıt için değer atadık
                    UserElement.AppendChild(koruyucuBabaAdi);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement koruyucuTCno = doc.CreateElement("KoruyucuTCNo");//Kullanicilar elementi içine bir kayıt ekledik
                    koruyucuTCno.InnerText = txtKoruyucuTCNo.Text;//kayıt için değer atadık
                    UserElement.AppendChild(koruyucuTCno);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement medeniHali = doc.CreateElement("MedeniHali");//Kullanicilar elementi içine bir kayıt ekledik
                    medeniHali.InnerText = txtKoruyucuMedeniHali.Text;//kayıt için değer atadık
                    UserElement.AppendChild(medeniHali);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement dini = doc.CreateElement("Dini");//Kullanicilar elementi içine bir kayıt ekledik
                    dini.InnerText = txtKoruyucuDini.Text;//kayıt için değer atadık
                    UserElement.AppendChild(dini);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement kanGrubu = doc.CreateElement("KanGrubu");//Kullanicilar elementi içine bir kayıt ekledik
                    kanGrubu.InnerText = cmbKoruyucuKanGrubu.SelectedItem.ToString();//kayıt için değer atadık
                    UserElement.AppendChild(kanGrubu);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement kayitliIl = doc.CreateElement("Kayıtlıil");//Kullanicilar elementi içine bir kayıt ekledik
                    kayitliIl.InnerText = txtKoruyucukKayitliIl.Text;//kayıt için değer atadık
                    UserElement.AppendChild(kayitliIl);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement kayitliIlce = doc.CreateElement("Kayıtlıilce");//Kullanicilar elementi içine bir kayıt ekledik
                    kayitliIlce.InnerText = txtKoruyucuKayitliIlce.Text;//kayıt için değer atadık
                    UserElement.AppendChild(kayitliIlce);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement kayitliKoy = doc.CreateElement("KayıtlıKoy");//Kullanicilar elementi içine bir kayıt ekledik
                    kayitliKoy.InnerText = txtKoruyucuKayitliKoy.Text;//kayıt için değer atadık
                    UserElement.AppendChild(kayitliKoy);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement esAdi = doc.CreateElement("EsAdi");//Kullanicilar elementi içine bir kayıt ekledik
                    esAdi.InnerText = txtEsAdi.Text;//kayıt için değer atadık
                    UserElement.AppendChild(esAdi);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement esSoyadi = doc.CreateElement("EsSoyadi");//Kullanicilar elementi içine bir kayıt ekledik
                    esSoyadi.InnerText = txtEsSoyadi.Text;//kayıt için değer atadık
                    UserElement.AppendChild(esSoyadi);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement esTCNo = doc.CreateElement("EsTCNo");//Kullanicilar elementi içine bir kayıt ekledik
                    esTCNo.InnerText = txtEsKimlikNo.Text;//kayıt için değer atadık
                    UserElement.AppendChild(esTCNo);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement gorevi = doc.CreateElement("Görevi");//Kullanicilar elementi içine bir kayıt ekledik
                    gorevi.InnerText = cmbGorevAktif.SelectedItem.ToString();//kayıt için değer atadık
                    UserElement.AppendChild(gorevi);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement gorevTuru = doc.CreateElement("GörevTürü");//Kullanicilar elementi içine bir kayıt ekledik
                    gorevTuru.InnerText = cmbKoruyucuTürü.SelectedItem.ToString();//kayıt için değer atadık
                    UserElement.AppendChild(gorevTuru);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement gorevVerilisYeri = doc.CreateElement("GörevYeri");//Kullanicilar elementi içine bir kayıt ekledik
                    gorevVerilisYeri.InnerText = txtGorevVerilisYeri.Text;//kayıt için değer atadık
                    UserElement.AppendChild(gorevVerilisYeri);//kayıt için parent atadık (UserElemet parenti)

                    XmlElement gorevVerilisTarihi = doc.CreateElement("GörevTarihi");//Kullanicilar elementi içine bir kayıt ekledik
                    gorevVerilisTarihi.InnerText = dtGorevVerilisTarihi.EditValue.ToString();//kayıt için değer atadık
                    UserElement.AppendChild(gorevVerilisTarihi);//kayıt için parent atadık (UserElemet parenti)


                    //Çocukları eklemeyi unutma
                    string cocukBilgileri = "";
                    XmlElement cocuklar = doc.CreateElement("Cocuklar");//Kullanicilar elementi içine bir kayıt ekledik
                    for (int i = 0; i < CocukListesi.Items.Count; i++)
                    {
                        cocukBilgileri += CocukListesi.Items[i] + "+";

                        cocuklar.InnerText = cocukBilgileri;//kayıt için değer atadık
                        UserElement.AppendChild(cocuklar);//kayıt için parent atadık (UserElemet parenti)
                    }

                    doc.DocumentElement.AppendChild(UserElement);//xml dosyamıza element ve kayıtları ekledik
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Save(executableLocation + "\\" + txtAd.Text + " " + txtSoyad.Text + " " + txtKoruyucuTCNo.Text + ".jpg");
                    }
                    XmlTextWriter xmleEkle = new XmlTextWriter(xslLocation + ".xml", null);//xml dosyamıza fiziksel olarak kayıtları yazıyoruz
                    xmleEkle.Formatting = Formatting.Indented;
                    doc.WriteContentTo(xmleEkle);//kayıtlar eklendi
                    xmleEkle.Close();//dosya kapatıldı
                    
                    if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular" + "\\" + eskiAd + " " + eskiSoyad + " " + eskiTC + ".jpg"))
                    {
                        bmp.Dispose();
                        File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Koruyucular" + "\\" + eskiAd + " " + eskiSoyad + " " + eskiTC + ".jpg");
                    }
                    if (!string.Equals(imgLoc, ""))
                    {
                        pictureBox1.Image.Save(executableLocation + "\\" + txtAd.Text + " " + txtSoyad.Text + " " + txtKoruyucuTCNo.Text + ".jpg");
                    }
                    MessageBox.Show("Koruyucu Güncellenmiştir.");
                    txtTemizle(txtSoyad, txtKoruyucuTCNo, txtKoruyucuMedeniHali, txtKoruyucukKayitliIl, txtKoruyucuKayitliKoy, txtKoruyucuKayitliIlce, txtKoruyucuDogumYeri, txtKoruyucuDini, txtKoruyucuBabaAdi, txtKoruyucuAnneAdi,
                        txtGorevVerilisYeri, txtEsSoyadi, txtEsKimlikNo, txtEsAdi, txtCocukSoyadi, txtCocukKimlikNo, txtCocukAdi, txtAd);
                    CocukListesi.Items.Clear();
                    cmbKoruyucuKanGrubu.SelectedIndex = 0;
                    cmbGorevAktif.SelectedIndex = 0;
                    cmbCinsiyet.SelectedIndex = 0;
                    pictureBox1.Image = null;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            btnKoruyucuOlustur.PerformClick();
        }
    }
}
