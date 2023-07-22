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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=HšSEYIN_CEYKEL\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Ad,count(*) from TBLURUNLER inner join TBLKATEGORİ\r\non TBLURUNLER.Kategori=TBLKATEGORİ.ID\r\ngroup by Ad\r\n", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                chart1.Series["Kategori"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();
        }
    }
}
