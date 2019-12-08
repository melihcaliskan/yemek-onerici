using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace YemekOnerici
{
    class baglantiYardimcisi
    {
        SqlConnection baglanti = new SqlConnection(get());
        SqlCommand komut;
        SqlDataAdapter da;
        public static string get()
        {
            return "Server = DESKTOP-FEK1O0B\\SQLEXPRESS; Database = odev; Integrated Security = SSPI";
        }

        public DataTable uyeleriCek()
        {
            baglanti.Open();
            da = new SqlDataAdapter(
                @"SELECT
                dbo.kullanici.ad,
                dbo.kullanici_bilgileri.okul_no,
                dbo.kullanici_bilgileri.yas,
                dbo.kullanici_bilgileri.il,
                dbo.kullanici_bilgileri.ilce,
                dbo.kullanici_bilgileri.telefon

                FROM
                dbo.kullanici
                INNER JOIN dbo.kullanici_bilgileri ON dbo.kullanici_bilgileri.uid = dbo.kullanici.id
                ", baglanti);
            DataTable uyeler = new DataTable();
            da.Fill(uyeler);
            baglanti.Close();
            return uyeler;
        }
        public DataTable yemegiCek(int id)
        {
            baglanti.Open();
            da = new SqlDataAdapter(
                @"SELECT
                dbo.gunun_yemegi.id,
                dbo.gunun_yemegi.yemek_id,
                dbo.gunun_yemegi.gun,
                dbo.yemek.id,
                dbo.yemek.isim,
                dbo.yemek.fotograf

                FROM
                dbo.gunun_yemegi
                INNER JOIN dbo.yemek ON dbo.yemek.id = dbo.gunun_yemegi.yemek_id
                WHERE
                dbo.yemek.id = " + id, baglanti);
            DataTable yemek = new DataTable();
            da.Fill(yemek);
            baglanti.Close();
            return yemek;
        }
        public DataTable malzemeleriCek(int id)
        {
            baglanti.Open();
            da = new SqlDataAdapter(
                @"SELECT
                dbo.gunun_yemegi.id,
                dbo.gunun_yemegi.yemek_id,
                dbo.gunun_yemegi.gun,
                dbo.yemek.id,
                dbo.yemek.isim,
                dbo.yemek.fotograf,
                dbo.yemek_malzemeleri.id,
                dbo.yemek_malzemeleri.yemek_id,
                dbo.yemek_malzemeleri.malzeme_id,
                dbo.malzeme.id,
                dbo.malzeme.isim

                FROM
                dbo.gunun_yemegi
                INNER JOIN dbo.yemek ON dbo.yemek.id = dbo.gunun_yemegi.yemek_id
                INNER JOIN dbo.yemek_malzemeleri ON dbo.yemek_malzemeleri.yemek_id = dbo.yemek.id
                INNER JOIN dbo.malzeme ON dbo.malzeme.id = dbo.yemek_malzemeleri.malzeme_id
                WHERE
                dbo.yemek.id = " + id, baglanti);
            DataTable malzemeler = new DataTable();
            da.Fill(malzemeler);
            baglanti.Close();
            return malzemeler;
        }
        public DataTable yapilisiCek(int id)
        {
            baglanti.Open();
            da = new SqlDataAdapter(
                @"SELECT
                dbo.yemek_yapilisi.yemek_id,
                dbo.yemek_yapilisi.tarif,
                dbo.yemek.id,
                dbo.gunun_yemegi.yemek_id,
                dbo.gunun_yemegi.gun

                FROM
                dbo.yemek_yapilisi
                INNER JOIN dbo.yemek ON dbo.yemek_yapilisi.yemek_id = dbo.yemek.id
                INNER JOIN dbo.gunun_yemegi ON dbo.yemek.id = dbo.gunun_yemegi.yemek_id
                WHERE
                dbo.yemek.id = " + id, baglanti);
            DataTable yapilis = new DataTable();
            da.Fill(yapilis);
            baglanti.Close();
            return yapilis;
        }
        public DataTable gunleriDoldur()
        {
            baglanti.Open();
            da = new SqlDataAdapter(
                @"SELECT
                dbo.gunun_yemegi.id,
                dbo.gunun_yemegi.yemek_id,
                dbo.gunun_yemegi.gun
                FROM
                dbo.gunun_yemegi
                ", baglanti);
            DataTable gunler = new DataTable();
            da.Fill(gunler);
            baglanti.Close();
            return gunler;
        }
        public DataTable secilenlerinSonucu(String sorguIDleri)
        {
            baglanti.Open();
            da = new SqlDataAdapter(@"
            SELECT
	            yemek.id,
	            yemek.isim,
	            yemek.fotograf 
            FROM
	            dbo.yemek AS yemek
	            INNER JOIN (
	            SELECT
		            malzeme_id,
		            yemek_id 
	            FROM
		            dbo.yemek_malzemeleri AS istenilenler 
	            WHERE
		            malzeme_id IN ( " + sorguIDleri + @" ) 
		            AND NOT EXISTS ( SELECT * FROM dbo.yemek_malzemeleri AS istenmeyenler WHERE istenmeyenler.yemek_id = istenilenler.yemek_id AND istenmeyenler.malzeme_id NOT IN ( " + sorguIDleri + @" )  ) 
	            ) AS malzemeler ON malzemeler.yemek_id = yemek.id 
            GROUP BY
	            yemek.id,
	            yemek.isim,
	            yemek.fotograf
            ", baglanti);
            DataTable sonuc = new DataTable();
            da.Fill(sonuc);
            baglanti.Close();
            return sonuc;
        }

    }
}
