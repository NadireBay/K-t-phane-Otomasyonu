using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2.Classlar;
using WpfApp2.Classlar.Parametreler;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for winOkuyucuEkle.xaml
    /// </summary>
    public partial class winOkuyucuEkle : Window
    {
        public winOkuyucuEkle()
        {
            InitializeComponent();
        }

        private void btn_KitapEkle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_OkuyucuNo.Text != "" && txt_AdSoyad.Text != "")
            {
                Prm veri = new Prm();
                Prm.OkuyucuNo = txt_OkuyucuNo.Text;
                veri.OkulNo = txt_OkuyucuNo.Text;
                veri.AdSoyad = txt_AdSoyad.Text;
                veri.Adresi = txt_Adresi.Text;
                veri.Email = txt_EPosta.Text;
                veri.Telefon = txt_Telefon.Text;

                if (DBislemci.Ekleme(veri))
                {
                    Prm.Hata = 0;
                    BilgiEkrani bilgi = new BilgiEkrani();
                    Prm.BilgiEkraniContent = "Kayıt İşlemi Başarılı...";
                    bilgi.Show();
                }
                else
                {
                    Prm.Hata = 1;
                    BilgiEkrani bilgi = new BilgiEkrani();
                    Prm.BilgiEkraniContent = "Kayıt İşlemi Başarısız!";
                    bilgi.Show();
                }
            }
            else
            {
                Prm.Hata = 1;
                BilgiEkrani bilgi = new BilgiEkrani();
                Prm.BilgiEkraniContent = "Zorunlu Alanları Doldurunuz!\n Okuyucu No , Ad Soyad veya Telefon";
                bilgi.Show();
            }
        }

        private void btn_KitapEleKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1;
        }

        private void btn_KitapEkeBilgi_Click(object sender, RoutedEventArgs e)
        {
            Bonus.PopupShow(popup_bilgi);
        }
    }
}

