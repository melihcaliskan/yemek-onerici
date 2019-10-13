using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace YemekOnerici
{
    public partial class fiyatTablosu : Form
    {
        SqlConnection baglanti = new SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut;
        SqlDataAdapter da;
        public fiyatTablosu()
        {
            InitializeComponent();
        }

        private void fiyatTablosu_Load(object sender, EventArgs e)
        {
            malzemeListele();
        }

        private void malzemeListele()
        {
            baglanti.Open();

            da = new SqlDataAdapter(
            @"SELECT
            dbo.malzeme.isim
           
            FROM dbo.malzeme", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            //label1.Text = tablo.Rows[0][4].ToString();

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                listBox1.Items.Add(tablo.Rows[i][0].ToString());
            }

            baglanti.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            String secilenMalzeme = listBox1.SelectedItem.ToString();

            if (secilenMalzeme.Equals(""))
            {
                MessageBox.Show("Hata", "Lütfen malzeme seçiniz");
            }
            else
            {
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }

                baglanti.Open();


                da = new SqlDataAdapter(
                @"SELECT
            dbo.malzeme_guncel_fiyat.malzemeGuncelFiyat,
            dbo.malzeme_guncel_fiyat.guncellemeTarihi,
            dbo.malzeme.isim
           
            FROM
            dbo.malzeme_guncel_fiyat
            INNER JOIN dbo.malzeme ON dbo.malzeme.id =dbo.malzeme_guncel_fiyat.malzemeId
            WHERE
            dbo.malzeme.isim ='" + secilenMalzeme + "'", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);


                baglanti.Close();
                chart1.Series[0].Name = secilenMalzeme;

                for (int i = 0; i < tablo.Rows.Count; i++)
                {

                    chart1.Series[0].Points.AddXY(tablo.Rows[i][1].ToString(), tablo.Rows[i][0].ToString());
                }
                secilenMalzeme = "";
            }

            
        }

    }
}
