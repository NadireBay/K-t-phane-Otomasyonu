using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for winKitapEkle.xaml
    /// </summary>
    public partial class winKitapEkle : Window
    {

        public winKitapEkle()
        {
            InitializeComponent();
        }

        sbyte resimsecildimi = 0;

        private void txt_BaskiSayisi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!char.IsDigit(e.Text,e.Text.Length-1))
            {
                e.Handled=true;
            }
        }

        private void txt_StokAdedi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void txt_SayfaSayisi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
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

        private void btn_KitapEkle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_Barkod.Text != "" /*&& cmb_KitapTuru.Text != "" */&& txt_KitapAdi.Text != "")  
            {
                Prm veri = new Prm();
                Prm.BarKodNo = txt_Barkod.Text;
                veri.Barkod = txt_Barkod.Text;
                veri.KitapAdi = txt_KitapAdi.Text;
                veri.BaskiYeri = cmb_BaskiYeri.Text;
                veri.BaskiSayisi = txt_BaskiSayisi.Text;
                veri.BaskiTarihi = dp_BaskiTarihi.Text;
                veri.KitapTuru = cmb_KitapTuru.Text;
                veri.SayfaSayisi = txt_SayfaSayisi.Text;
                veri.Konusu = txt_Konusu.Text; 
                veri.Dili = cmb_Dili.Text;
                veri.TeminTuru = cmb_TeminTuru.Text;
                veri.TeminTarihi = dp_TeminTarihi.Text;
                
                if (resimsecildimi == 1)
                {
                    veri.Resim = Prm.ResimAdi;
                }
                else
                {
                    veri.Resim = Environment.CurrentDirectory+"\\ KitapResmi\\Adsız.png";
                }
                
                veri.YayinEviID = 1;
                veri.YazarAdiID = 1;


                if(DBislemci.EklemeIslemi(veri))
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
                Prm.BilgiEkraniContent = "Zorunlu Alanları Doldurunuz!\n Barkod , Kitap Türü veya Kitap Adı";
                bilgi.Show();
            }
        }

        string SecilenResimAdi;
        private void btn_ResimEkle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // belgelerim içerisine klasör oluşturma varsa oluşturmama durumu 
                if (!Directory.Exists(Prm.BelgelerimYolu + "\\KutuphaneTakipPro\\Resimler"))
                {
                    Directory.CreateDirectory(Prm.BelgelerimYolu + "\\KutuphaneTakipPro\\Resimler");
                }

                // open file dialog ile resim seçme
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Resim Seç";
                dlg.InitialDirectory = "";
                dlg.Filter = "Image Files (*.jpg;*.jpeg;)|*.jpg; *.jpeg;|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
                dlg.FilterIndex = 1;

                if ((bool)dlg.ShowDialog())
                {
                    //open file dialog seçilen resmi oluşturduğıumuz klasör içerisene kopyalama işlemi
                    SecilenResimAdi = dlg.FileName;
                    DateTime zaman = DateTime.Now;
                    string format = "dd-MM-yyyy-_hh-mm-ss";
                    Prm.ResimAdi = Prm.BelgelerimYolu + "\\KutuphaneTakipPro\\Resimler\\" + Prm.BarKodNo + zaman.ToString(format)+".jpg";

                    File.Copy(SecilenResimAdi, Prm.ResimAdi, true);

                    //BElgelerim İçerisinde ki resimlerimizin yolunu uri ye çevirip img_KitapResmi source sine verme
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri(@"" + Prm.ResimAdi);
                    img.EndInit();
                    img_KitapResmi.Source = img;
                    
                    //Resim Ekleme Başarılı Bilgisi
                    Prm.Hata = 0;
                    BilgiEkrani bilgi = new BilgiEkrani();
                    Prm.BilgiEkraniContent = "Resim Ekleme İşlemi Başarılı";
                    bilgi.Show();

                    resimsecildimi = 1;

                }
                else
                {
                    //Resim Ekleme Başarısız Bilgisi
                    Prm.Hata = 1;
                    BilgiEkrani bilgi = new BilgiEkrani();
                    Prm.BilgiEkraniContent = "Resim Ekleme İşlemi Başarısız";
                    bilgi.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
