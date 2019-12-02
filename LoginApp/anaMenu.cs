using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using YemekOnerici;
using System.Windows.Documents;
namespace LoginApp
{
    
    public partial class anaMenu : Form
    {
        String kullaniciadi;
        SqlConnection baglanti = new System.Data.SqlClient.SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        SqlDataAdapter da;
        List<int> secilenIDler = new List<int>();
        List<int> secilenyemekler = new List<int>();
        List<int> aa = new List<int>();
        string a;
        int b;
        

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
            comboEkle(1, listBox1);
        }
  
   

        private void frmMain_Load(object sender, EventArgs e)
        {
            label1.Text = "Hoşgeldin " + Char.ToUpper(kullaniciadi[0]) + kullaniciadi.Remove(0, 1) + ", ";
        }

        private void bul_Click(object sender, EventArgs e)
        {
            secilenIDler.Clear();
            secilenleriBul(checkedListBox1);
            secilenleriBul(checkedListBox2);
            secilenleriBul(checkedListBox3);
            secilenleriBul(checkedListBox4);
            secilenleriBul(checkedListBox5);
            secilenleriBul(checkedListBox6);

            String sorguIDleri = string.Join(",", secilenIDler);
            sonucEkrani sonucEkrani = new sonucEkrani(sorguIDleri);
            sonucEkrani.Show();
        }
        public void secilenleriBul(CheckedListBox listBoxAdi)
        {
            foreach (ListItem item in listBoxAdi.CheckedItems)
            {
                secilenIDler.Add(Int32.Parse(item.Value));
            }
        }

        private void sonYemeklerimButonu(object sender, EventArgs e)
        {
            //TODO: ID alınacak.
            sonYemekler sonYemekler = new sonYemekler(1);
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

        private void yemekEkle_Click(object sender, MouseEventArgs e)
        {
            yemekEkle yemekEkle = new yemekEkle();
            yemekEkle.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adptr = new SqlDataAdapter("Select isim,fiyat from dbo.malzeme_fiyat", baglanti);
            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] dizi = new string[100];


            //for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            // {

            // dizi[i] = checkedListBox1.CheckedItems[i].ToString();

            // textBox1.Text = dizi[i];

            foreach (string s in checkedListBox1.CheckedItems)
            {
                int i = 0;
            comboBox1.Items.Add(s);
                //dizi[i] = s;
               // textBox1.Text += "\n" + dizi[i];
               // i++;
               // baglanti.Open();
               // komut.Connection = baglanti;
               // komut.CommandText = "Select * from dbo.malzeme_fiyat where isim = '" + textBox1.Text + "'";
               // komut.ExecuteNonQuery();
               // SqlDataReader dr = komut.ExecuteReader();
                //if (dr.Read())
               // {
               //     comboBox1.Items.Add( dr["fiyat"].ToString());
               // }
                //else
               // {
               //     textBox1.Text = "veri cekilemedi";
               // }
               // baglanti.Dispose();
               // baglanti.Close();
            }
            //}
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select fiyat from dbo.malzeme_fiyat";
            komut.ExecuteNonQuery();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["fiyat"].ToString();
            }
            else
            {
                textBox1.Text = "veri cekilemedi";
            }
            baglanti.Dispose();
            baglanti.Close();

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            secilenler(checkedListBox1);

            string c;

            // String sorguIDlerii = string.Join(",",secilenyemekler);


            String sorguIDlerii = string.Join(",", secilenyemekler);


            c = sorguIDlerii;
            
            //textBox1.Text = sorguIDlerii;
            comboBox1.Items.Add(c);
            c = " ";
            




            //  foreach (char ss in checkedListBox1.SelectedIndex.ToString())
            // {
            //     int i = checkedListBox1.SelectedIndex;

            //    comboBox1.Items.Add(checkedListBox1.Items[i].ToString());
            // }
        }

        private void comboEkle(int id, ListBox combo)
        {
            DataTable malzemeler = malzemeleriCek(id);
            foreach (DataRow malzeme in malzemeler.Rows)
            {
                combo.DisplayMember = "Text";
                
                combo.ValueMember = "Value";
                combo.Items.Insert(0, new ListItem { Value = malzeme["id"].ToString(), Text = malzeme["isim"].ToString() });
                
            }
        }

        public void secilenler(CheckedListBox combo)
        {
            int i = 0;
            string a;
            string[] dizi = new string[100];
            foreach (ListItem item in combo.CheckedItems)
            {

               

               
                

                secilenyemekler.Add(Int32.Parse(item.Value));
                
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uyeBilgi ac = new uyeBilgi();
            ac.Show();
            this.Hide();
        }
    }
    }

