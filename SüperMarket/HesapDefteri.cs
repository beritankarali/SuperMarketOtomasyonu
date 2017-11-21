using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SüperMarket
{
    public abstract class HesapDefteri
    {
        public double Ucret { get; set; }
        public KasaGorevlisi KasaGorevlisi { get; set; }
        public Satis Satis { get; set; }
        public Odeme Odeme { get; set; }
        public SatisKalemi SatisKalemi { get; set; }
        public Urun Urun { get; set; }
        public HesapDefteri(Satis s, SatisKalemi sk, Odeme o, Urun u)
        {
            Satis = s;
            SatisKalemi = sk;
            Odeme = o;
            Urun = u;           
        }
        public HesapDefteri() { }
        public virtual void UcretHesapla(Odeme o)
        {
            double ucret = 0;
            ucret = (SatisKalemi.UrunMiktari)*(Satis.Tutar);
            Ucret = ucret;
        }
    }
}
