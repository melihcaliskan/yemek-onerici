using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginApp
{
    public partial class girisEkrani : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=MELIHALIKAN22F1\\SQLEXPRESS;Database=odev;Integrated Security=SSPI");
        SqlCommand komut;
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
            baglanti.Close();
            if (tablo.Rows.Count == 1){
                anaMenu anaMenu = new anaMenu(txtUsername.Text.Trim());
                this.Hide();
                anaMenu.Show();
            }
            else{
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            da = new SqlDataAdapter("SELECT dbo.kullanici.id, dbo.kullanici.ad FROM dbo.kullanici", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
