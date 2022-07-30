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
using System.Data.Sql;

namespace Veri_Tabanli_Secim_Projesi
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GD3NFC9\\SQLEXPRESS;Initial Catalog=DbSecimProje;Integrated Security=True");

        private void btnOyGiriş_Click(object sender, EventArgs e)
        {
            try
            {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_İLCE (ILCEAD,APARTİ,BPARTİ,CPARTİ,DPARTİ,EPARTİ) values (@P1,@P2,@P3,@P4,@P5,@P6),", baglanti);

            komut.Parameters.AddWithValue("@P1",txtİlce.Text);
            komut.Parameters.AddWithValue("@P2",txtA.Text);
            komut.Parameters.AddWithValue("@P3",txtB.Text);
            komut.Parameters.AddWithValue("@P4",txtC.Text);
            komut.Parameters.AddWithValue("@P5",txtD.Text);
            komut.Parameters.AddWithValue("@P6",txtE.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Oy Girişi Gerçekleşti.");
                }
            
            catch (SqlException ex)
            {
                MessageBox.Show("there was an issue!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı kapanıyor!");
            }

        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm = new FrmGrafikler();
            frm.Show();
        }


    }
}
