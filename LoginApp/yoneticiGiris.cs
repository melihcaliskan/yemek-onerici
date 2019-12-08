using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using YemekOnerici;

namespace LoginApp
{
    public partial class yoneticiGiris : Form
    {
        SqlConnection baglanti = new SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        SqlDataAdapter da;
        
        public yoneticiGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "select * from dbo.yonetici_giris where yonetici_giris='" + textBox1.Text + "'and yonetici_sifre='" + textBox2.Text + "'";
            SqlDataReader da = komut.ExecuteReader();
            if (da.Read())
            {

                yonetici ac = new yonetici();
                ac.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre yanlış");
            }
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantiYardimcisi yardimci = new baglantiYardimcisi();
            DataTable uyeler = yardimci.yoneticiCek();

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = uyeler;
        }
    }
}
