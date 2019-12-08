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
        int kullaniciId;
        SqlConnection baglanti = new System.Data.SqlClient.SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        SqlDataAdapter da;
        List<int> secilenIDler = new List<int>();

        public anaMenu(int kullaniciId)
        {
            this.kullaniciId = kullaniciId;
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
                listBoxAdi.Items.Insert(0, new ListItem{ Value = malzeme["id"].ToString(), Text = malzeme["isim"].ToString() });
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
            baglantiYardimcisi yardimci = new baglantiYardimcisi();
            DataTable uyeBilgisi = yardimci.uyeBilgisiCek(kullaniciId);

            String kullaniciIsmi = uyeBilgisi.Rows[0][1].ToString();
            label1.Text = "Hoşgeldin " + Char.ToUpper(kullaniciIsmi[0]) + kullaniciIsmi.Remove(0, 1) + ", ";
            label8.Text = uyeBilgisi.Rows[0][2].ToString();

            switch (label8.Text)
            {
                case "Üye":
                    button1.Visible = false;
                    button2.Visible = false;
                    break;
                case "Moderatör":
                    button2.Visible = false;
                    break;
                case "Yönetici":
                    break;
                default:
                    break;
            }
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
        public void secilenleriBul(CheckedListBox listBoxAdi){
            foreach (ListItem item in listBoxAdi.CheckedItems)
            {
                secilenIDler.Add(Int32.Parse(item.Value));
            }
        }

        private void sonYemeklerimButonu(object sender, EventArgs e)
        {

            sonYemekler sonYemekler = new sonYemekler(kullaniciId);

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

        private void btnFiyatForm_Click(object sender, EventArgs e)
        {
            fiyatTablosu fiyatTablosunaGit = new fiyatTablosu();
            fiyatTablosunaGit.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            uyeBilgi ac = new uyeBilgi();
            ac.Show();
            this.Hide();
        }
    }
}
