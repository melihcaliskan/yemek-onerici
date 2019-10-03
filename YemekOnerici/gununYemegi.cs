using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginApp
{
    public partial class gununYemegi : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=MELIHALIKAN22F1\\SQLEXPRESS;Database=odev;Integrated Security=SSPI");
        SqlCommand komut;
        SqlDataAdapter da;
        public gununYemegi()
        {
            InitializeComponent();
        }

        public void veriCek(int id) {

            baglanti.Open();
            da = new SqlDataAdapter(
            @"SELECT
            dbo.gunun_yemegi.gun
            FROM
            dbo.gunun_yemegi
            ", baglanti);
            DataTable gunSayisi = new DataTable();
            da.Fill(gunSayisi);
            comboBox1.DataSource = gunSayisi;
            comboBox1.DisplayMember = "gun";

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
            dbo.gunun_yemegi.gun = "+id, baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            label1.Text = tablo.Rows[0][4].ToString();
            pictureBox1.ImageLocation = tablo.Rows[0][5].ToString();

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
            dbo.gunun_yemegi.gun = "+id, baglanti);

            DataTable malzemeler = new DataTable();
            da.Fill(malzemeler);

            int n = malzemeler.Rows.Count;
            Label[] labels = new Label[n];

            for (int i = 0; i < n; i++)
            {
                labels[i] = new Label();
                labels[i].Text = malzemeler.Rows[i][10].ToString();
                labels[i].Location = new Point(285, 150 + 30 * i);
                this.Controls.Add(labels[i]);
            }
            baglanti.Close();
        }

        private void gununYemegi_Load(object sender, EventArgs e)
        {
            veriCek(1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            int index = comboBox1.SelectedIndex;
            veriCek(index+1);
            */
        }
    }
}
