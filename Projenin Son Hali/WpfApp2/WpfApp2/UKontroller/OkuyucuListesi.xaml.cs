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
    /// Interaction logic for OkuyucuListesi.xaml
    /// </summary>
    public partial class OkuyucuListesi : UserControl
    {
        public OkuyucuListesi() => InitializeComponent();

        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        private void btn_okuyucuEkle_Click(object sender, RoutedEventArgs e)
        {
            winOkuyucuEkle ekle = new winOkuyucuEkle();
            ekle.Owner = gk;
            gk.Opacity = 0.3;

            ekle.ShowDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DBislemci.GridDoldur(dtg_OkuyucuListesi);
        }


    }
}