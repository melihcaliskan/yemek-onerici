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
    public partial class girisEkrani : Form
    {
        SqlConnection baglanti = new SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        SqlDataAdapter da;
        public girisEkrani()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM dbo.kullanici WHERE ad = '" + txtUsername.Text.Trim() + "' AND sifre='"+ txtPassword.Text.Trim() + "'", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            if (tablo.Rows.Count == 1){
                anaMenu anaMenu = new anaMenu(int.Parse(tablo.Rows[0][0].ToString()));

                komut.CommandType = System.Data.CommandType.Text;
                komut.Connection = baglanti;

                komut.CommandText = "INSERT INTO dbo.oturum VALUES('"+ txtUsername.Text.Trim() + "', '"+ Guid.NewGuid().ToString("n") +"')";
                komut.ExecuteNonQuery();

                this.Hide();
                anaMenu.Show();
            }
            else{
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
            baglanti.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            baglantiYardimcisi yardimci = new baglantiYardimcisi();
            DataTable uyeler = yardimci.uyeleriCek();

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = uyeler;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            uyeKayit uyeKayit = new uyeKayit();
            uyeKayit.Show();
        }
    }
}
