using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Urun_Takip
{
    

    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
        //    SqlConnection baglanti = new SqlConnection("Data Source=HšSEYIN_CEYKEL\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");

            //Toplam Kategori Sayısı
            baglanti.Open();
            SqlCommand komut1= new SqlCommand("select count (*) from TBLKATEGORİ",baglanti);
            SqlDataReader dr=komut1.ExecuteReader();
            while(dr.Read())
            {
                LblToplamKategori.Text = dr[0].ToString();
            }
            baglanti.Close();

            //Toplam Ürün Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count (*)from TblUrunler ",baglanti);
            SqlDataReader dr2=komut2.ExecuteReader();
            while(dr2.Read())
            {
                LblToplamUrun.Text = dr2[0].ToString(); 
            }
            baglanti.Close();

            //En Yüksek Stoklu Ürün
            baglanti.Open ();
            SqlCommand komut3 = new SqlCommand("select * from TBLURUNLER where stok=(select MAX(Stok) from TBLURUNLER)", baglanti);
            SqlDataReader dr3=komut3.ExecuteReader();
            while (dr3.Read())
            {
                label5.Text = dr3[1].ToString();
            }
            baglanti.Close();

            //En Düşük Stoklu Ürün
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select * from TBLURUNLER where stok=(select min(Stok) from TBLURUNLER)",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                label7.Text = dr4[1].ToString();
            }
            baglanti.Close();

            //Toplam Beyaz Eşya Sayısı
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select count (*)from TBLURUNLER where Kategori=(select ID from TBLKATEGORİ where Ad='Beyaz Eşya')", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                label9.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Toplam Küçük Ev Aletleri Sayısı
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select count (*)from TBLURUNLER where Kategori=(select ID from TBLKATEGORİ where Ad='Küçük Ev Aletleri')", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                label11.Text = dr6[0].ToString();
            }
            baglanti.Close();

            //Laptop Kar Oranı
            baglanti.Open();
            SqlCommand komut10 = new SqlCommand("select Stok*(SatisFiyat-AlisFiyat) From TBLURUNLER where UrunAd='Laptop'", baglanti);
            SqlDataReader dr10 = komut10.ExecuteReader();
            while (dr10.Read())
            {
                label22.Text = dr10[0].ToString()+"₺";
            }
            baglanti.Close();

            //Toplam Kar Oranı
            baglanti.Open();
            SqlCommand komut88 = new SqlCommand("select sum(stok*(SatisFiyat-AlisFiyat)) as 'Toplam Stokla Çarpılan Sonuç' from TBLURUNLER", baglanti);
            SqlDataReader dr88 = komut88.ExecuteReader();
            while (dr88.Read())
            {
                label15.Text = dr88[0].ToString() + "₺";
            }
            baglanti.Close();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=HšSEYIN_CEYKEL\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
