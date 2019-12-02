using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginApp
{
    
    public partial class oturumAc : Form
    {
        
        public oturumAc()
        {
            InitializeComponent();
        }

     

        private void button2_Click(object sender, EventArgs e)
        {

            oturumAc f1 = new oturumAc();
            f1.Close();
            girisEkrani ac = new girisEkrani();
            ac.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            oturumAc f1 = new oturumAc();
            f1.Close();
            yoneticiGiris ac = new yoneticiGiris();
            ac.Show();
            this.Hide();


        }
    }
}
