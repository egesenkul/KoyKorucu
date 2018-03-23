using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasarKoyKoruyucu
{
    public class Koruyucu
    {
        public string KoruyucuAdı { get; set; }
        public string KoruyucuSoyadı { get; set; }
        public string KoruyucuTCNO { get; set; }

        public string Gorevi { get; set; }
        public string GorevYeri { get; set; }
        public DateTime GorevTarihi { get; set; }

        public string KoruyucuTur { get; set; }

        public Koruyucu(string ad,string soy,string tc,string gorev,string yer,DateTime tar, string tur)
        {
            KoruyucuAdı = ad;
            KoruyucuSoyadı = soy;
            KoruyucuTCNO = tc;

            Gorevi = gorev;
            GorevYeri = yer;
            GorevTarihi = tar;

            KoruyucuTur = tur;
        }
    }
}
