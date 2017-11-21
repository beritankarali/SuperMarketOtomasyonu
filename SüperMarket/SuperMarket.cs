using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SüperMarket
{
    public class SuperMarket
    {
        List<UrunTanımı> uruntanimi = new List<UrunTanımı>();
        public List<UrunTanımı> urunTanimi
        {
            get { return uruntanimi; }
        }

        public void UrunRaporaEkle(UrunTanımı ut)
        {
            uruntanimi.Add(ut);
        }
        List<Urun> urunler = new List<Urun>();
        public List<Urun> Urunler
        {
            get { return urunler; }
        }

        public Urun UrunAra(int no)
        {
            Urun urun = null;
            foreach (Urun u in urunler)
            {
                if (u.serino == no)
                    urun = u;
            }
            return urun;
        }
        public void UrunEkle(Urun urun)
        {
            Urunler.Add(urun);

        }

        List<Musteri> musteri = new List<Musteri>();
        public List<Musteri> Musteri
        {
            get { return musteri; }
        }
        public void MusteriEkle(Musteri m)
        {
            musteri.Add(m);
        }

        List<KasaGorevlisi> kasaGorevlisi = new List<KasaGorevlisi>();
        public List<KasaGorevlisi> kasagorevlisi
        {
            get { return kasaGorevlisi; }
        }
        public void KasaGorevlisiEkle(KasaGorevlisi k)
        {
            kasagorevlisi.Add(k);
        }

        List<UrunKatalogu> katalog = new List<UrunKatalogu>();
        public List<UrunKatalogu> urunKatalogu
        {
            get { return katalog; }
        }
        public SuperMarket()
        {

        }


    }
}
