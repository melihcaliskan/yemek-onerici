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
    public partial class sonucEkrani : Form
    {
        SqlConnection baglanti = new System.Data.SqlClient.SqlConnection(baglantiYardimcisi.get());
        SqlCommand komut = new System.Data.SqlClient.SqlCommand();
        SqlDataAdapter da;
        String sorguIDleri;
        Label[] labels;
        public sonucEkrani(String sorguIDleri)
        {
            InitializeComponent();
            this.sorguIDleri = sorguIDleri;
        }

        private void sonucEkrani_Load(object sender, EventArgs e)
        {
            baglantiYardimcisi yardimci = new baglantiYardimcisi();
            DataTable sonuc = yardimci.secilenlerinSonucu(sorguIDleri);
            if (sonuc.Rows.Count > 0)
            {
                int id = int.Parse(sonuc.Rows[0][0].ToString());
                sayi.Text = sonuc.Rows.Count + " sonuç bulundu.";
                isim.Text = sonuc.Rows[0][1].ToString();
                pictureBox1.ImageLocation = sonuc.Rows[0][2].ToString();
                malzemeleriDoldur(id);
                yapilisiDoldur(id);
                /*
                BİRDEN ÇOK YEMEK İÇİN BU KISIM ÇALIŞACAK.
                foreach (DataRow yemek in tablo.Rows)
                {
                    pics[0] = new PictureBox();
                    pics[0].Location = new Point(20, 70);
                    pics[0].Name = "pic" + 0;
                    pics[0].Size = new Size(300, 300);
                    pics[0].ImageLocation = yemek["fotograf"].ToString();
                    this.Controls.Add(pics[0]);
                }
                */
            }
            else{
                MessageBox.Show("Kriterlerinize uygun yemek bulunamadı");
                this.Close();
            }
        }
        private void malzemeleriDoldur(int id)
        {
            baglantiYardimcisi yardimci = new baglantiYardimcisi();
            DataTable malzemeler = yardimci.malzemeleriCek(id);

            int n = malzemeler.Rows.Count;
            Console.WriteLine(id + " awdawdaw");
            labels = new Label[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine((i + 1) + ". " + malzemeler.Rows[i][10].ToString());
                labels[i] = new Label();
                labels[i].Name = "malzeme";

                labels[i].Text = (i + 1) + ". " + malzemeler.Rows[i][10].ToString();
                labels[i].Location = new Point(285, 170 + 30 * i);
                this.Controls.Add(labels[i]);
            }
        }

        private void yapilisiDoldur(int id)
        {
            baglantiYardimcisi yardimci = new baglantiYardimcisi();
            DataTable yapilis = yardimci.yapilisiCek(id);

            int n = yapilis.Rows.Count;
            labels = new Label[n];


            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(yapilis.Rows[i][1].ToString());
                labels[i] = new Label();
                labels[i].Name = "yapilis";
                labels[i].AutoSize = true;

                labels[i].Text = (i + 1) + ". " + yapilis.Rows[i][1].ToString();
                labels[i].Location = new Point(445, 170 + 30 * i);
                this.Controls.Add(labels[i]);
            }
        }
    }
}
