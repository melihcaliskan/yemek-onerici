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
        int kullaniciId;
        Label[] labels;
        SqlConnection baglanti = new SqlConnection(baglantiYardimcisi.get());
        SqlDataAdapter da;
        private string kullaniciSifre1;

        public sonYemekler(int kullaniciId)
        {
            this.kullaniciId = kullaniciId;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            da = new SqlDataAdapter(
            @"SELECT
            dbo.yemek.isim
            FROM
            kullanici_yemekleri
            INNER JOIN dbo.yemek ON dbo.yemek.id = dbo.kullanici_yemekleri.yemek_id
            INNER JOIN dbo.kullanici ON dbo.kullanici.id = dbo.kullanici_yemekleri.uid WHERE uid=" + kullaniciId, baglanti);

            DataTable tablo = new DataTable();
            da.Fill(tablo);
            int n = tablo.Rows.Count;

            labels = new Label[n];

            for (int i = 0; i < n; i++)
            {

                labels[i] = new Label();

                labels[i].Text = (i + 1) + ". " + tablo.Rows[i][0].ToString();
                labels[i].Location = new Point(285, 170 + 30 * i);
                this.Controls.Add(labels[i]);
            }
            baglanti.Close();
        }
    }
}