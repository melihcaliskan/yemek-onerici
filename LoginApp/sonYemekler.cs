using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YemekOnerici;

namespace LoginApp
{
    public partial class sonYemekler : Form
        
    {
        int kullaniciSifre;
        SqlConnection baglanti = new SqlConnection(baglantiYardimcisi.get());
        SqlDataAdapter da;
        private string kullaniciSifre1;

        public sonYemekler(int kullaniciSifre)
        {
            this.kullaniciSifre = kullaniciSifre;
            InitializeComponent();
        }

        public sonYemekler(string kullaniciSifre1)
        {
            this.kullaniciSifre1 = kullaniciSifre1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            da = new SqlDataAdapter(
            @"SELECT
            dbo.kullanici.id,dbo.yemek.id
            FROM
            kullanici_yemekleri
            INNER JOIN dbo.yemek ON dbo.yemek.id = dbo.kullanici_yemekleri.yemek_id
            INNER JOIN dbo.kullanici ON dbo.kullanici.id = dbo.kullanici_yemekleri.uid WHERE uid=" + kullaniciSifre, baglanti);

            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
