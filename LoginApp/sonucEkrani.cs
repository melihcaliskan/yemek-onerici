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
            /*
            SqlCommand command = new SqlCommand("SELECT yemek.id, yemek.isim, yemek.fotograf FROM dbo.yemek AS yemek INNER JOIN( SELECT malzeme_id, yemek_id FROM dbo.yemek_malzemeleri AS istenilenler WHERE malzeme_id IN ( @sorguIDleri ) AND NOT EXISTS ( SELECT * FROM dbo.yemek_malzemeleri AS istenmeyenler WHERE istenmeyenler.yemek_id = istenilenler.yemek_id AND istenmeyenler.malzeme_id NOT IN ( @sorguIDleri ) ) ) AS malzemeler ON malzemeler.yemek_id = yemek.id GROUP BY yemek.id, yemek.isim, yemek.fotograf", baglanti);
            command.Parameters.AddWithValue("@sorguIDleri", sorguIDleri);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(reader["id"]+" "+reader["isim"]);
                } else
                {
                    MessageBox.Show("Kriterlerinize uygun yemek bulunamadı");
                    this.Close();
                }
            }
            */
            da = new SqlDataAdapter("SELECT yemek.id, yemek.isim, yemek.fotograf FROM dbo.yemek AS yemek INNER JOIN( SELECT malzeme_id, yemek_id FROM dbo.yemek_malzemeleri AS istenilenler WHERE malzeme_id IN ("+sorguIDleri+" ) AND NOT EXISTS ( SELECT * FROM dbo.yemek_malzemeleri AS istenmeyenler WHERE istenmeyenler.yemek_id = istenilenler.yemek_id AND istenmeyenler.malzeme_id NOT IN ("+sorguIDleri+" ) ) ) AS malzemeler ON malzemeler.yemek_id = yemek.id GROUP BY yemek.id, yemek.isim, yemek.fotograf", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            if (tablo.Rows.Count > 0)
            {
                Console.WriteLine(tablo.Rows[0]["id"].ToString());
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
