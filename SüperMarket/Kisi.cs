using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SüperMarket
{
    public abstract class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public bool Cinsiyet { get; set; }
        private Iletisim iletisimBilgileri = new Iletisim();

        public Iletisim IletisimBilgileri
        {
            get { return iletisimBilgileri; }
            set { iletisimBilgileri = value; }
        }
        
    }
}
