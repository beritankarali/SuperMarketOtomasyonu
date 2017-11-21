using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SüperMarket
{
    public class Urun
    {
        public string katalog { get; set; }
        public decimal BirimAlisFiyati { get; set; }
        public decimal BirimSatisFiyati { get; set; }
        public int Adet { get; set; }
        public DateTime SonKullanmaTarihi { get; set; }
        public string UrunAciklamasi { get; set; }
        public string UrunAdi { get; set; }
        public int serino { get; set; }
        public Terminal Terminal { get; set; }
        public Satis Satis { get; set; }
        public bool Durum { get; set; }
        public UrunTanımı UrunTanımı { get; set; }

        public Urun(Satis s, UrunTanımı u, Terminal t)
        {
            Satis = s;
            UrunTanımı = u;
            Terminal = t;
            Durum = false;
        }
        public Urun(Terminal t)
        {
            t.seriNo = serino;
        }
        public Urun()
        { }
    }
}
