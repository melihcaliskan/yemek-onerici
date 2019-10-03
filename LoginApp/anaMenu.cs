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
using System.Windows.Controls;
using System.Windows.Documents;

namespace LoginApp
{
    public partial class anaMenu : Form
    {
        String kullaniciadi;
        SqlConnection baglanti = new System.Data.SqlClient.SqlConnection("Server = MELIHALIKAN22F1\\SQLEXPRESS; Database = odev; Integrated Security = SSPI");
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        SqlDataAdapter da;

        public anaMenu(String kullaniciadi)
        {
            this.kullaniciadi = kullaniciadi;
            InitializeComponent();

            tabloyaEkle(1, checkedListBox1);
            tabloyaEkle(2, checkedListBox2);
            tabloyaEkle(3, checkedListBox3);
            tabloyaEkle(4, checkedListBox6);
            tabloyaEkle(5, checkedListBox5);
            tabloyaEkle(6, checkedListBox4);
        }
        private void tabloyaEkle(int id, CheckedListBox listBoxAdi){
            DataTable malzemeler = malzemeleriCek(id);
            foreach (DataRow malzeme in malzemeler.Rows)
            {
                listBoxAdi.DisplayMember = "Text";
                listBoxAdi.ValueMember = "Value";
                listBoxAdi.Items.Insert(0, new { Value = malzeme["id"], Text = malzeme["isim"] });
            }
        }
        private DataTable malzemeleriCek(int id)
        {
            baglanti.Open();
            da = new SqlDataAdapter(@"SELECT
                                    dbo.malzeme.id,
                                    dbo.malzeme.isim,
                                    dbo.malzeme.tur_id
                                    FROM
                                    dbo.malzeme
                                    WHERE
                                    dbo.malzeme.tur_id = "+id, baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            label1.Text = "Hoşgeldin " + Char.ToUpper(kullaniciadi[0]) + kullaniciadi.Remove(0, 1) + ", ";
        }

        private void bul_Click(object sender, EventArgs e)
        {
            List<int> secilenIDler = new List<int>();
            foreach (var value in checkedListBox1.CheckedItems)
            {
                //Console.WriteLine((value as ListItem).Value);
            }
        }

        private void sonYemeklerimButonu(object sender, EventArgs e)
        {
            sonYemekler sonYemekler = new sonYemekler();
            sonYemekler.Show();
        }
        private void gununYemegiButonu(object sender, EventArgs e)
        {
            gununYemegi gununYemegi = new gununYemegi();
            gununYemegi.Show();
        }

        private void malzemeEkleButonu_Click(object sender, EventArgs e)
        {
            malzemeEkle malzemeEkle = new malzemeEkle();
            malzemeEkle.Show();
        }
    }
}
