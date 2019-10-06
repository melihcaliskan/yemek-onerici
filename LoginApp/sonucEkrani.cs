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
        public sonucEkrani(String sorguIDleri)
        {
            InitializeComponent();
            this.sorguIDleri = sorguIDleri;
        }

        private void sonucEkrani_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            da = new SqlDataAdapter(@"
            SELECT
	            yemek.id,
	            yemek.isim,
	            yemek.fotograf 
            FROM
	            dbo.yemek AS yemek
	            INNER JOIN (
	            SELECT
		            malzeme_id,
		            yemek_id 
	            FROM
		            dbo.yemek_malzemeleri AS istenilenler 
	            WHERE
		            malzeme_id IN ( "+sorguIDleri+ @" ) 
		            AND NOT EXISTS ( SELECT * FROM dbo.yemek_malzemeleri AS istenmeyenler WHERE istenmeyenler.yemek_id = istenilenler.yemek_id AND istenmeyenler.malzeme_id NOT IN ( " + sorguIDleri + @" )  ) 
	            ) AS malzemeler ON malzemeler.yemek_id = yemek.id 
            GROUP BY
	            yemek.id,
	            yemek.isim,
	            yemek.fotograf
            ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            if (tablo.Rows.Count > 0)
            {
                PictureBox[] pics = new PictureBox[50];
                sonuc.Text = tablo.Rows.Count + " sonuç bulundu.";
                foreach (DataRow yemek in tablo.Rows)
                {
                    pics[0] = new PictureBox();
                    pics[0].Location = new Point(20, 70);
                    pics[0].Name = "pic" + 0;
                    pics[0].Size = new Size(300, 300);
                    pics[0].ImageLocation = yemek["fotograf"].ToString();
                    this.Controls.Add(pics[0]);
                }
            }
            else
            {
                MessageBox.Show("Kriterlerinize uygun yemek bulunamadı");
                this.Close();
            }
                baglanti.Close();

        }
    }
}
