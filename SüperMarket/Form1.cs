using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SüperMarket
{
    public partial class frmSuperMarket : Form
    {
        public frmSuperMarket()
        {
            InitializeComponent();
        }
        SuperMarket s = new SuperMarket();

        private void frmSuperMarket_Load(object sender, EventArgs e)
        {
            listviewUrun.CheckBoxes = true;
           
            tbSuperMarket.TabPages.Remove(tbUrunIslemleri);
            tbSuperMarket.TabPages.Remove(tbMusteriIslemleri);
            tbSuperMarket.TabPages.Remove(tbKasiyerIslemleri);
            tbSuperMarket.TabPages.Remove(tbRapor);
        }

        private void btnMudurGiris_Click(object sender, EventArgs e)
        {
                if(txtMudurKulAd.Text == "mudur" && txtMudurSifre.Text == "123456")
                {
                   tbSuperMarket.TabPages.Add(tbUrunIslemleri);
                   tbSuperMarket.TabPages.Add(tbKasiyerIslemleri);
                   tbSuperMarket.TabPages.Add(tbRapor);
                   tbSuperMarket.SelectedIndex = 1;
                 }
                else
                {
                    if (txtMudurKulAd.Text == "")
                        MessageBox.Show("Kullanıcı adınızı giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (txtMudurSifre.Text == "")
                        MessageBox.Show("Şifrenizi giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (txtMudurKulAd.Text != "mudur" || txtMudurSifre.Text != "123456")
                        MessageBox.Show("Kullanıcı adınız veya şifreniz yanlış", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
            
           
        }
        private void btnKasiyerGiris_Click(object sender, EventArgs e)
        {
            if (txtKasiyerKulAd.Text == "kasiyer" && txtKasiyerSifre.Text == "123456")
                {
                    tbSuperMarket.TabPages.Add(tbUrunIslemleri);
                    tbSuperMarket.TabPages.Add(tbMusteriIslemleri);
                    tbSuperMarket.TabPages.Add(tbKasiyerIslemleri);
                    tbSuperMarket.SelectedIndex = 3;
                }
            else
            {
                if (txtKasiyerKulAd.Text == "")
                    MessageBox.Show("Kullanıcı adınızı giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtKasiyerSifre.Text == "")
                    MessageBox.Show("Şifrenizi giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtKasiyerKulAd.Text != "mudur" || txtKasiyerSifre.Text != "123456")
                    MessageBox.Show("Kullanıcı adınız veya şifreniz yanlış", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Musteri m = new Musteri();
                m.Ad = txtMusteriAdi.Text;
                m.Soyad = txtMusteriSoyad.Text;
                m.IletisimBilgileri.TelefonNo = txtMusteriTelefon.Text;
                m.IletisimBilgileri.Adres = txtMusteriAdresi.Text;
                s.MusteriEkle(m);
                txtMusteriAdi.Text = txtMusteriSoyad.Text = txtMusteriTelefon.Text = txtMusteriAdresi.Text = "";
                MusteriListesiGuncelle();
            }
            catch (Exception)
            {
                MessageBox.Show("Müşteri Eklenemedi. Tekrar Deneyiniz.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
           
        }
        private void MusteriListesiGuncelle()
        {
            listviewMusteri.Items.Clear();
            int i = 0;
            foreach (Musteri m in s.Musteri)
            {
                ListViewItem lstitem = new ListViewItem();
                lstitem.Text =m.Ad;
                lstitem.SubItems.Add(m.Soyad);
                lstitem.SubItems.Add(m.IletisimBilgileri.Adres);
                lstitem.SubItems.Add(m.IletisimBilgileri.TelefonNo);

                //lstitem.SubItems.Add(dateTimePicker.Value.ToShortDateString());

                listviewMusteri.Items.Add(lstitem);
                listviewMusteri.Items[i].BackColor = Color.AliceBlue;
                i++;
            }
        }
        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listviewMusteri.SelectedItems)
            {
                item.Remove();
            }
        }
           
        private void btnKasiyer_Click(object sender, EventArgs e)
        {


            KasaGorevlisi k = new KasaGorevlisi( txtKasiyerAd.Text, txtKasiyerSoyad.Text, dtMusteri.Value,txtKasiyerTelefon.Text,
                                                txtKasiyerAdres.Text );
          
            s.KasaGorevlisiEkle(k);
            txtKasiyerAd.Text = txtKasiyerSoyad.Text = txtKasiyerTelefon.Text = txtKasiyerAdres.Text = "";
            KasiyerListesiGuncelle();

        }

        private void KasiyerListesiGuncelle()
        {
            listviewKasiyer.Items.Clear();
            int i = 0;
            foreach (KasaGorevlisi k in s.kasagorevlisi)
            {
                ListViewItem lstitem1 = new ListViewItem();
                lstitem1.Text = k.Ad;
                lstitem1.SubItems.Add(k.Soyad);
                lstitem1.SubItems.Add(k.IletisimBilgileri.Adres);
                lstitem1.SubItems.Add(k.IletisimBilgileri.TelefonNo);
                //lstitem1.SubItems.Add(k.TCKimlikNo);
                lstitem1.SubItems.Add(dtMusteri.Value.ToShortDateString());
                lstitem1.SubItems.Add(dateTimeKasiyer.Value.ToShortDateString());


                listviewKasiyer.Items.Add(lstitem1);
                listviewKasiyer.Items[i].BackColor = Color.AliceBlue;
                i++;
            }


        }

        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            Urun u2 = new Urun();
            u2.UrunAdi = txtUrunAdi.Text;
            u2.UrunAciklamasi = txtUrunAciklamasi.Text;
            u2.katalog = cmbBoxKategoriler.SelectedItem.ToString();
            u2.SonKullanmaTarihi = dateTimeSonKullanma.Value;
            u2.BirimAlisFiyati = Convert.ToInt32(txtBirimAlisFiyati.Text);
            u2.BirimSatisFiyati = Convert.ToInt32(txtBirimSatisFiyati.Text);
            u2.Adet = Convert.ToInt32(txtAdet.Text);
            u2.serino = Convert.ToInt32(txtSeriNo.Text);
            int sonuc = 0;
            sonuc = (Convert.ToInt32(txtAdet.Text)) * Convert.ToInt32(txtBirimSatisFiyati.Text);
            lblTutar.Text = sonuc.ToString();

            s.UrunEkle(u2);
            txtUrunAdi.Text = txtUrunAciklamasi.Text = txtBirimAlisFiyati.Text = txtBirimSatisFiyati.Text = txtAdet.Text = txtSeriNo.Text =  "";
            UrunListesiYenile();
            
        }

        private void UrunListesiYenile()
        {
            listviewUrun.Items.Clear();
            int i = 0;
            foreach (Urun u in s.Urunler)
            {
                
                ListViewItem lstitem1 = new ListViewItem();
                lstitem1.Text = u.UrunAdi;
                lstitem1.SubItems.Add(u.UrunAciklamasi);
                lstitem1.SubItems.Add(u.katalog);
                lstitem1.SubItems.Add(u.SonKullanmaTarihi.ToShortDateString());
                lstitem1.SubItems.Add(u.BirimAlisFiyati.ToString());
                lstitem1.SubItems.Add(u.BirimSatisFiyati.ToString());
                lstitem1.SubItems.Add(u.Adet.ToString());
                lstitem1.SubItems.Add(u.serino.ToString());
                lstitem1.SubItems.Add(lblTutar.Text);
                
                listviewUrun.Items.Add(lstitem1);
                listviewUrun.Items[i].BackColor = Color.AliceBlue;
                i++;
            }




        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listviewUrun.SelectedItems)
            {
                item.Remove();
            }
        }
        Musteri mus;
        private void btnRaporUrun_Click(object sender, EventArgs e)
        {
        //    mus = s.Musteri[listviewMusteri.SelectedItems];
        //    Urun u = s.Urunler[listviewUrun.SelectedItems];
        //    s.UrunRaporaEkle(new UrunTanımı(mus, s));


            lbRapor1.Items.Add(listviewUrun.SelectedItems);
    
         }

        private void btnRaporMusteri_Click(object sender, EventArgs e)
        {

        }
       
    }
}
