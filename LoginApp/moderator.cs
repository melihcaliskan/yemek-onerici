﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YemekOnerici
{
    public partial class moderator : Form
    {

        SqlConnection baglanti = new SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        SqlDataAdapter da;

        public moderator()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            malzemeEkle malzemeEkle = new malzemeEkle();
            malzemeEkle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            yemekEkle malzemeEklee = new yemekEkle();
            malzemeEklee.Show();
        }

        private void moderator_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adptrr = new SqlDataAdapter("Select * from dbo.malzeme", baglanti);
            DataTable dtt = new DataTable();
            adptrr.Fill(dtt);
            dataGridView2.DataSource = dtt;

            SqlDataAdapter adptr = new SqlDataAdapter("Select * from dbo.yemek", baglanti);
            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            

        }
    }
}
