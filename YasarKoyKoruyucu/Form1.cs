using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MetroFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YasarKoyKoruyucu
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnKapat_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Close();
        }

        private void btnKoruyucuEkle_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            KoruyucuOlustur olustur = new KoruyucuOlustur();
            olustur.Show();
        }

        private void btnKoruyuListesi_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            KoruyucuListesi liste = new KoruyucuListesi();
            liste.Show();
        }

        private void tileItem1_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            KoruyucuOlustur olustur = new KoruyucuOlustur();
            olustur.Show();
        }
    }
}
