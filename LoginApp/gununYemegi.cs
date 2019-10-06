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
        public void yemegiCek(int id) {
            baglantiYardimcisi yardimci = new baglantiYardimcisi();
            DataTable yemek = yardimci.yemegiCek(id);

            label1.Text = yemek.Rows[0][4].ToString();
            pictureBox1.ImageLocation = yemek.Rows[0][5].ToString();
        }
        private void malzemeleriDoldur(int id)
        {
            baglantiYardimcisi yardimci = new baglantiYardimcisi();
            DataTable malzemeler = yardimci.malzemeleriCek(id);

            int n = malzemeler.Rows.Count;
            labels = new Label[n];

            for (int i = 0; i < n; i++)
            {
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


        private void gunleriDoldur()
        {
            baglantiYardimcisi yardimci = new baglantiYardimcisi();
            DataTable gunSayisi = yardimci.gunleriDoldur();

            selectDayComboBox.DataSource = gunSayisi;
            selectDayComboBox.DisplayMember = "gun";
            selectDayComboBox.ValueMember = "yemek_id";
        }

        private void selectDayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selectDayComboBox.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                int id = int.Parse(selectDayComboBox.SelectedValue.ToString());
                //this.Controls.Remove("malzeme");
                yemegiCek(id);
                malzemeleriDoldur(id);
                yapilisiDoldur(id);
            }
        }

        private void gununYemegi_Load(object sender, EventArgs e)
        {
            gunleriDoldur();
            yemegiCek(12);
            malzemeleriDoldur(12);
            yapilisiDoldur(12);
        }
    }
}
