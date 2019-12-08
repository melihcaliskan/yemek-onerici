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
    public partial class uyeBilgi : Form
    {
        SqlConnection baglanti = new SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        SqlDataAdapter da;
        int a;

        public uyeBilgi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE dbo.kullanici SET ad = '" + textBox2.Text + "' ,sifre='" + textBox3.Text + "' WHERE id = " + textBox4.Text + "";
            baglanti.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            MessageBox.Show("Güncelleme Başarılı");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            button2.Enabled = true;
        }

        private void uyeBilgi_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kayit = "SELECT * from dbo.kullanici where ad=@ad";
            SqlCommand komut = new SqlCommand(kayit, baglanti);

            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
