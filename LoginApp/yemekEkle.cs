using System;
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
    public partial class yemekEkle : Form
    {
        SqlConnection baglanti = new System.Data.SqlClient.SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        SqlDataAdapter da;
        List<int> secilenIDler = new List<int>();
        public yemekEkle()
        {
            InitializeComponent();
        }

        private void yemekEkle_Load(object sender, EventArgs e)
        {
            tabloyaEkle(1, checkedListBox1);
            tabloyaEkle(2, checkedListBox2);
            tabloyaEkle(3, checkedListBox3);
            tabloyaEkle(4, checkedListBox6);
            tabloyaEkle(5, checkedListBox5);
            tabloyaEkle(6, checkedListBox4);
        }
        private void tabloyaEkle(int id, CheckedListBox listBoxAdi)
        {
            DataTable malzemeler = malzemeleriCek(id);
            foreach (DataRow malzeme in malzemeler.Rows)
            {
                listBoxAdi.DisplayMember = "Text";
                listBoxAdi.ValueMember = "Value";
                listBoxAdi.Items.Insert(0, new ListItem { Value = malzeme["id"].ToString(), Text = malzeme["isim"].ToString() });
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
                                    dbo.malzeme.tur_id = " + id, baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        private void ekle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(yemekIsmi.Text) && !String.IsNullOrEmpty(yemekFotografi.Text))
            {
                secilenIDler.Clear();
                secilenleriBul(checkedListBox1);
                secilenleriBul(checkedListBox2);
                secilenleriBul(checkedListBox3);
                secilenleriBul(checkedListBox4);
                secilenleriBul(checkedListBox5);
                secilenleriBul(checkedListBox6);
                komut.CommandType = System.Data.CommandType.Text;
                komut.Connection = baglanti;
                baglanti.Open();

                komut.CommandText = "INSERT INTO dbo.yemek VALUES('" + yemekIsmi.Text + "', '" + yemekFotografi.Text + "','" + yemekYapilisi.Text + "')";
                komut.ExecuteNonQuery();

                //MALZEMELERİ YEMEKLE İLİŞKİLENDİREBİLMEK İÇİN VERİTABANINA SON EKLENEN YEMEK ID'SİNİ ÇEKİYORUZ.
                komut.CommandText = "SELECT MAX(id) FROM yemek";
                komut.Connection = baglanti;
                int sonId = Convert.ToInt32(komut.ExecuteScalar());

                foreach (int malzeme_id in secilenIDler)
                {
                    komut.CommandText = "INSERT INTO dbo.yemek_malzemeleri VALUES(" + sonId + ", " + malzeme_id + ")";
                    komut.ExecuteNonQuery();
                }

                baglanti.Close();

                MessageBox.Show("Yemek başarıyla eklendi.");
                this.Close();
            } else
            {
                MessageBox.Show("Boş alan bırakmayın");
            }
        }
        public void secilenleriBul(CheckedListBox listBoxAdi)
        {
            foreach (ListItem item in listBoxAdi.CheckedItems)
            {
                Console.WriteLine(item.Text);
                secilenIDler.Add(Int32.Parse(item.Value));
            }
        }
    }
}
