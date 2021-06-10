using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp2.Classlar.Parametreler;

namespace WpfApp2.Classlar
{
   public class DBislemci
    {
        // datagrid doldurma metodu...
        public static bool GridDoldur(DataGrid grd)
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Select * From tbl_KitapListesi", con); 
            try
            {
                SQLiteDataAdapter adp = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                grd.ItemsSource = null;
                grd.ItemsSource = dt.DefaultView;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Dispose();
            }
            if (i > 0) return true; else return false;

        }

        public static bool Doldur(DataGrid grd) 
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Select * From tbl_OkuyucuListesi", con);
            try
            {
                SQLiteDataAdapter adp = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                grd.ItemsSource = null;
                grd.ItemsSource = dt.DefaultView;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Dispose();
            }
            if (i > 0) return true; else return false;
        }

        public static bool Ekleme(Prm veri)
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Insert into tbl_OkuyucuListesi " +
             "(AdSoyad,Adresi,Email,Telefon,OkulNo) " +
             "values(@AdSoyad,@Adresi,@Email,@Telefon,@OkulNo)", con);


            com.Parameters.AddWithValue("@AdSoyad", veri.AdSoyad);
            com.Parameters.AddWithValue("@Adresi", veri.Adresi);
            com.Parameters.AddWithValue("@Email", veri.Email);
            com.Parameters.AddWithValue("@Telefon", veri.Telefon);
            com.Parameters.AddWithValue("@OkulNo", veri.OkulNo);
            try
            {
                con.Open();
                i = (sbyte)com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Dispose();
            }
            if (i > 0) return true; else return false;

        }

        // ekleme işlemi / insert / veri ekleme 
        public static bool EklemeIslemi(Prm veri)
        {
            sbyte i = 0;
            SQLiteConnection con = new SQLiteConnection(DBbaglanti.DBadres);
            SQLiteCommand com = new SQLiteCommand("Insert into tbl_KitapListesi " +
             "(Barkod,KitapAdi,KitapTuru,KitapKonusu,BaskiYeri,BaskiTarihi,TeminTuru,TeminTarihi,SayfaSayisi,Resim,EkleyenID,YayinEviID,YazarAdiID) " +
             "values(@Barkod,@KitapAdi,@KitapTuru,@KitapKonusu,@BaskiYeri,@BaskiTarihi,@TeminTuru,@TeminTarihi,@SayfaSayisi,@Resim,@EkleyenID,@YayinEviID,@YazarAdiID)", con);


            com.Parameters.AddWithValue("@Barkod",veri.Barkod);
            com.Parameters.AddWithValue("@KitapAdi", veri.KitapAdi);
            com.Parameters.AddWithValue("@KitapTuru", veri.KitapTuru);
            com.Parameters.AddWithValue("@KitapKonusu", veri.Konusu);
            com.Parameters.AddWithValue("@BaskiYeri", veri.BaskiYeri);
            com.Parameters.AddWithValue("@BaskiTarihi", veri.BaskiTarihi);
            com.Parameters.AddWithValue("@TeminTuru", veri.TeminTuru);
            com.Parameters.AddWithValue("@TeminTarihi", veri.TeminTarihi);
            com.Parameters.AddWithValue("@SayfaSayisi", veri.SayfaSayisi);
            com.Parameters.AddWithValue("@Resim", veri.Resim);
            com.Parameters.AddWithValue("@EkleyenID", veri.EkleyenID);
            com.Parameters.AddWithValue("@YayinEviID", veri.YayinEviID);
            com.Parameters.AddWithValue("@YazarAdiID", veri.YazarAdiID);

            try
            {
                con.Open();
                i = (sbyte)com.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Dispose();
            }
            if (i > 0) return true; else return false;

        }

    }

}


