using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=HšSEYIN_CEYKEL\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLADMIN where Kullanici=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr =komut.ExecuteReader();

            if(dr.Read()) 
            {
                FrmYönlendirme fr = new FrmYönlendirme();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifrenizde Hata var yeniden deneyiniz");
            }
            baglanti.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
