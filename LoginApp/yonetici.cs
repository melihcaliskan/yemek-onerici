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
    public partial class yonetici : Form
    {
        SqlConnection baglanti = new SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        SqlDataAdapter da;
        public yonetici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter adptr = new SqlDataAdapter("Select * from dbo.malzeme_guncel_fiyat", baglanti);
            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                komut.Connection = baglanti;
                komut.CommandText = "INSERT INTO dbo.malzeme_fiyat (id, isim, tur_id) SELECT id, isim, tur_id FROM dbo.malzeme ";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt başarılı");
            }
            catch { MessageBox.Show("Kayıt başarısız."); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adptr = new SqlDataAdapter("Select * from dbo.kullanici", baglanti);
            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE dbo.malzeme_fiyat SET fiyat = '"+ textBox2.Text+"' WHERE id = "+textBox1.Text+"";
            baglanti.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            MessageBox.Show("Güncelleme Başarılı");
        }
<<<<<<< HEAD

        private void yonetici_Load(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                komut.Connection = baglanti;
                komut.CommandText = "DELETE FROM kullanici where id=" + textBox3.Text + "";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Silindi!");
            }
            catch { MessageBox.Show("Kayıt Silinemedi"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
=======
>>>>>>> 8d0fa313892f4c53f1990b4c7268f11a62fec7f2
    }
}
    
