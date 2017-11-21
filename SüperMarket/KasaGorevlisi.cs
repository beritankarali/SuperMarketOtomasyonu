using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SüperMarket
{
    public class KasaGorevlisi : Kisi
    {
       
        public KasaGorevlisi(string ad, string soyad, DateTime dogumtarihi, string telefon, string adres)
        {
            Ad = ad;
            Soyad = soyad;
            DogumTarihi = dogumtarihi;
            IletisimBilgileri.TelefonNo = telefon;
            IletisimBilgileri.Adres = adres;
        }
        private Terminal serino = new Terminal();
        public Terminal seriNo { get { return serino; } set { serino = value; } }

        
    }
}
