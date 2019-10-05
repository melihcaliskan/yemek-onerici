using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YemekOnerici
{
    public partial class malzemeEkle : Form
    {
        SqlConnection baglanti = new System.Data.SqlClient.SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        public malzemeEkle()
        {
            InitializeComponent();
        }

        private void malzemeEkle_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(malzemeIsimleri.Text) && !String.IsNullOrEmpty(malzemeTuru.Text)) {
                string malzemeler = malzemeIsimleri.Text;
                List<String> malzemeListesi = malzemeler.Split(',').ToList();

                komut.CommandType = System.Data.CommandType.Text;
                komut.Connection = baglanti;

                baglanti.Open();
                foreach (String malzeme in malzemeListesi)
                {
                    komut.CommandText = "INSERT INTO dbo.malzeme VALUES('" + malzeme + "', " + malzemeTuru.Text + ")";
                    komut.ExecuteNonQuery();
                }
                MessageBox.Show("Ürünler başarıyla eklendi.");
                malzemeTuru.Text = "";
                malzemeIsimleri.Text = "";
                baglanti.Close();
            } else {
                MessageBox.Show("Boş alan bırakmayın.");

            }

        }
    }
}
