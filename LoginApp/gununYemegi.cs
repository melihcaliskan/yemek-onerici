﻿using System;
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
    public partial class gununYemegi : Form
    {
        SqlConnection baglanti = new SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut;
        SqlDataAdapter da;
        Label[] labels;


        public gununYemegi()
        {
            
            InitializeComponent();
        }

        public void veriCek(int id) {
            baglanti.Open();
            
            da = new SqlDataAdapter(
            @"SELECT
            dbo.gunun_yemegi.id,
            dbo.gunun_yemegi.yemek_id,
            dbo.gunun_yemegi.gun,
            dbo.yemek.id,
            dbo.yemek.isim,
            dbo.yemek.fotograf,
            dbo.yemek.yapilis

            FROM
            dbo.gunun_yemegi
            INNER JOIN dbo.yemek ON dbo.yemek.id = dbo.gunun_yemegi.yemek_id
            WHERE
            dbo.gunun_yemegi.gun = "+id, baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            label1.Text = tablo.Rows[0][4].ToString();
            pictureBox1.ImageLocation = tablo.Rows[0][5].ToString();
            yapilis_text.Text = tablo.Rows[0][6].ToString();

            baglanti.Close();

        }
        private void malzemeleriDoldur(int ID)
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
            dbo.gunun_yemegi.gun = " + ID, baglanti);

            DataTable malzemeler = new DataTable();
            da.Fill(malzemeler);
            int n = malzemeler.Rows.Count;
           
            labels = new Label[n];

        
            for (int i = 0; i < n; i++)
            {

                labels[i] = new Label();

                labels[i].Text = (i + 1) + ". " + malzemeler.Rows[i][10].ToString();
                labels[i].Location = new Point(285, 170 + 30 * i);
                this.Controls.Add(labels[i]);
            }

            baglanti.Close();
        }

        
        private void gunleriDoldur()
        {
            baglanti.Open();
            da = new SqlDataAdapter(
            @"SELECT
            dbo.gunun_yemegi.gun
            FROM
            dbo.gunun_yemegi
            ", baglanti);


            DataTable gunSayisi = new DataTable();
            da.Fill(gunSayisi);
            selectDayComboBox.DataSource = gunSayisi;
            selectDayComboBox.DisplayMember = "gun";
            baglanti.Close();
        }

       

        private void selectDayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = int.Parse(selectDayComboBox.Text);
            malzemeleriDoldur(index);
            veriCek(index);
        }

        private void gununYemegi_Load(object sender, EventArgs e)
        {
            malzemeleriDoldur(1);
            gunleriDoldur();
            veriCek(1);
        }
    }
}
