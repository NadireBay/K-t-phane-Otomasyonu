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

namespace WpfApp2.UKontroller
{
    /// <summary>
    /// Interaction logic for Kitap_Listesi.xaml
    /// </summary>
    public partial class Kitap_Listesi : UserControl
    {
        public Kitap_Listesi()
        {
            InitializeComponent();
        }

        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        private void btn_kitapEkle_Click(object sender, RoutedEventArgs e)
        {

            winKitapEkle ekle = new winKitapEkle();
            ekle.Owner = gk;
            gk.Opacity = 0.3;

            ekle.ShowDialog();


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DBislemci.GridDoldur(dtg_KitapListesi);
        }

        string barkodNo;
        string kitapTuru, KitapYazari;
        private void dtg_KitapListesi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            barkodNo = ((TextBlock)dtg_KitapListesi.Columns[0].GetCellContent(dtg_KitapListesi.SelectedItem)).Text;
            kitapTuru = ((TextBlock)dtg_KitapListesi.Columns[2].GetCellContent(dtg_KitapListesi.SelectedItem)).Text;
            KitapYazari = ((TextBlock)dtg_KitapListesi.Columns[3].GetCellContent(dtg_KitapListesi.SelectedItem)).Text;

            MessageBox.Show(barkodNo+" - "+kitapTuru+" - "+KitapYazari);
        }
    }
}
