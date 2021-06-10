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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.Classlar;
using WpfApp2.UKontroller;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const Visibility hidden = Visibility.Hidden;

        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void btn_kapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void brd_sagust_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         //   uc_cagir.Uc_Ekle(Content_icerik, new Kitap_Listesi());

        }

        private void btn_SimgeDurumu_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_TamEkran_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                grd_AnaGridWindow.Margin = new Thickness(0, 0, 0, 0);
            }
            else
            {
                this.WindowState = WindowState.Normal;
                grd_AnaGridWindow.Margin = new Thickness(15);
            }
        }

        private void btn_HamburgerMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (btn_HamburgerMenu.Width != 60)
            {
                GridLength grd = new GridLength(80, GridUnitType.Pixel);
                grdClmn_menu.Width = grd;

                lbl_menu1.Visibility = Visibility.Hidden;
                lbl_menu2.Visibility = Visibility.Hidden;
                lbl_menu3.Visibility = Visibility.Hidden;
                lbl_menu4.Visibility = Visibility.Hidden;
                lbl_menu5.Visibility = Visibility.Hidden;
                lbl_menu6.Visibility = Visibility.Hidden;

                lbl_logo.Width = 60;
                lbl_LogoYazi.Width = 0;
                btn_HamburgerMenu.Width = 60;

                menu_altlabel.Visibility = Visibility.Hidden;
                menu_altpencere_resim.Visibility = Visibility.Hidden;
            }
            else
            {
                GridLength grd = new GridLength(220, GridUnitType.Pixel);
                grdClmn_menu.Width = grd;

                lbl_menu1.Visibility = Visibility.Visible;
                lbl_menu2.Visibility = Visibility.Visible;
                lbl_menu3.Visibility = Visibility.Visible;
                lbl_menu4.Visibility = Visibility.Visible;
                lbl_menu5.Visibility = Visibility.Visible;
                lbl_menu6.Visibility = Visibility.Visible;

                lbl_logo.Width = 150;
                lbl_LogoYazi.Width = 150;
                btn_HamburgerMenu.Width = 100;

                menu_altlabel.Visibility = Visibility.Visible;
                menu_altpencere_resim.Visibility = Visibility.Visible;
            }
        }

        // menu butonları - menu butons

        #region menubutonlar
        int secimdurumu;
        private void menubuton_kitaplistesi_Click(object sender, RoutedEventArgs e)
        {
            uc_cagir.Uc_Ekle(Content_icerik, new Kitap_Listesi());

             secimdurumu = 1;
              secilendurum();
        }

        private void menubuton_okuyuculistesi_Click(object sender, RoutedEventArgs e)
        {
            uc_cagir.Uc_Ekle(Content_icerik, new OkuyucuListesi());

            secimdurumu = 2;
            secilendurum();
        }

        private void menubuton_emanetlistesi_Click(object sender, RoutedEventArgs e)
        {
             secimdurumu = 3;
             secilendurum();
        }

        private void menubuton_zamanidolanlar_Click(object sender, RoutedEventArgs e)
        {
                 secimdurumu = 4;
                secilendurum();
        }

        private void menubuton_ayarlar_Click(object sender, RoutedEventArgs e)
        {
                secimdurumu = 5;
                secilendurum();
        }

        private void menubuton_hakkinda_Click(object sender, RoutedEventArgs e)
        {
                 secimdurumu = 6;
                 secilendurum();
        }

        // checked status - seçilen durumu
        void secilendurum()
        {
            if(secimdurumu == 1)
            {
                menubuton_kitaplistesi.IsChecked = true;
            }
            else
            {
                menubuton_kitaplistesi.IsChecked = false;
            }
            if (secimdurumu == 2)
            {
                menubuton_okuyuculistesi.IsChecked = true;
            }
            else
            {
                menubuton_okuyuculistesi.IsChecked = false;
            }
            if (secimdurumu == 3)
            {
                menubuton_emanetlistesi.IsChecked = true;
            }
            else
            {
                menubuton_emanetlistesi.IsChecked = false;
            }
            if (secimdurumu == 4)
            {
                menubuton_zamanidolanlar.IsChecked = true;
            }
            else
            {
                menubuton_zamanidolanlar.IsChecked = false;
            }
            if (secimdurumu == 5)
            {
                menubuton_ayarlar.IsChecked = true;
            }
            else
            {
                menubuton_ayarlar.IsChecked = false;
            }
            if (secimdurumu == 6)
            {
                menubuton_hakkinda.IsChecked = true;
            }
            else
            {
                menubuton_hakkinda.IsChecked = false;
            }
        }
        #endregion

        private void menubuton_kitaplistesi_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
    