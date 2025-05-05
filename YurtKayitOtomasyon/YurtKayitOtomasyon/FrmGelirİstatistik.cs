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

namespace YurtKayitOtomasyon
{
    public partial class FrmGelirİstatistik : Form
    {
        public FrmGelirİstatistik()
        {
            InitializeComponent();
        }

       SqlBaglantisi baglantim = new SqlBaglantisi();

        private void FrmGelirİstatistik_Load(object sender, EventArgs e)
        {
            // form açılırken kasadaki toplam para miktarını getirir
            SqlCommand cmdkasa = new SqlCommand("Select Sum(OdemeMiktar) From Kasa",baglantim.baglanti());
            SqlDataReader oku = cmdkasa.ExecuteReader();
            while (oku.Read())
            {
                LblPara.Text = oku[0].ToString() + " TL";
            }

            baglantim.baglanti().Close();
            // Tekrarsız olarak ayları listeleme
            SqlCommand cmday = new SqlCommand("Select distinct(OdemeAy) from Kasa ",baglantim.baglanti());
            SqlDataReader oku2 = cmday.ExecuteReader();
            while (oku2.Read())
            {
                CmbAy.Items.Add(oku2[0].ToString());
            }
            baglantim.baglanti().Close();

            //Grafiklere veri tabanından veri çekme
            SqlCommand cmdgrafik = new SqlCommand("Select OdemeAy,sum(OdemeMiktar) From Kasa Group By OdemeAy",baglantim.baglanti());
            SqlDataReader okugrafik = cmdgrafik.ExecuteReader();
            while (okugrafik.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(okugrafik[0], okugrafik[1]);
            }
            baglantim.baglanti().Close();


        }

        private void CmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmdseciliay = new SqlCommand("Select sum(OdemeMiktar) from Kasa where OdemeAy=@a1 ", baglantim.baglanti());
            cmdseciliay.Parameters.AddWithValue("@a1",CmbAy.Text);
            SqlDataReader oku3 = cmdseciliay.ExecuteReader();
            while (oku3.Read())
            {
                LblSeciliAyKazanc.Text = oku3[0].ToString() + " TL";
            }
            baglantim.baglanti().Close();
        }
    }
}
