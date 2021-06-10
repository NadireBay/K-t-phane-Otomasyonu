using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Classlar.Parametreler
{
   public class Prm
    {
        #region Static Parametreler

        public static sbyte Hata;

        public static string BilgiEkraniContent;

        public static string BelgelerimYolu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();

        public static string ResimAdi;

        public static string BarKodNo;
        internal string AdSoyad;

        #endregion

        #region ekleParametreleri

        private string barkod;
        private string kitapAdi;
        private string yazarAdiSoyadi;
        private string yayinEvi;
        private string baskiYeri;
        private string baskiTarihi;
        private string baskiSayisi;
        private string kitapTuru;
        private string sayfaSayisi;
        private string dili;
        private string konusu;
        private string teminTuru;
        private string teminTarihi;
        private string resim;

       

        private int ekleyenID;
        private int yayinEviID;
        private int yazarAdiID;

        private bool emanetDurum;

        public static string OkuyucuNo { get; internal set; }

        public string Barkod
        {
            get => barkod;
           
            set => barkod = value; 
        }

        public string KitapAdi 
        { 
            get => kitapAdi; 
            set => kitapAdi = value; 
        }

        public string YazarAdiSoyadi 
        { 
            get => yazarAdiSoyadi; 
            set => yazarAdiSoyadi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); 
        }

        public string YayinEvi 
        { 
            get => yayinEvi; 
            set => yayinEvi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        public string BaskiYeri 
        {
            get => baskiYeri; 
            set => baskiYeri = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        public string BaskiTarihi 
        { 
            get => baskiTarihi; 
            set => baskiTarihi = value; 
        }

        public string BaskiSayisi 
        { 
            get => baskiSayisi; 
            set => baskiSayisi = value; 
        }

        public string KitapTuru 
        { 
            get => kitapTuru; 
            set => kitapTuru = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        public string SayfaSayisi 
        {
            get => sayfaSayisi; 
            set => sayfaSayisi = value; 
        }

        public string Dili 
        {
            get => dili; 
            set => dili = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        public string Konusu 
        {
            get => konusu; 
            set => konusu = value; 
        }

        public string TeminTuru
        { 
            get => teminTuru; 
            set => teminTuru = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        public string TeminTarihi 
        {
            get => teminTarihi; 
            set => teminTarihi = value;
        }

        public string Resim 
        {
            get => resim; 
            set => resim = value; 
        }

        public int EkleyenID 
        {
            get => ekleyenID; 
            set => ekleyenID = value;
        }

        public int YayinEviID 
        {
            get => yayinEviID; 
            set => yayinEviID = value;
        }

        public int YazarAdiID
        {
            get => yazarAdiID; 
            set => yazarAdiID = value;
        }

        public bool EmanetDurum 
        {
            get => emanetDurum; 
            set => emanetDurum = value;
        }
        public string OkulNo { get; internal set; }
        public string Email { get; internal set; }
        public string Telefon { get; internal set; }
        public string Adresi { get; internal set; }



        #endregion

    }
}
