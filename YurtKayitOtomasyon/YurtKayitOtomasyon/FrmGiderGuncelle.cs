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
    public partial class FrmGiderGuncelle : Form
    {
        SqlBaglantisi baglantim = new SqlBaglantisi();
        public FrmGiderGuncelle()
        {
            InitializeComponent();
        }

        public string elektrik, su, dogalgaz, internet, gida, personel, diger,giderid;
        private void FrmGiderGuncelle_Load(object sender, EventArgs e)
        {
            TxtGiderID.Text = giderid;
            TxtElektrik.Text = elektrik;
            TxtDogalgaz.Text = dogalgaz;
            TxtInternet.Text = internet;
            TxtPersonel.Text = personel;
            TxtDiger.Text = diger;
            TxtGida.Text = gida;
            TxtSu.Text = su;
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdgüncelle = new SqlCommand("update Giderler set Elektrik=@g1,Su=@g2,Dogalgaz=@g3,internet=@g4,Gıda=@g5,Personel=@g6,Diger=@g7 where Odemeid=@g8", baglantim.baglanti());
                cmdgüncelle.Parameters.AddWithValue("@g8", TxtGiderID.Text);
                cmdgüncelle.Parameters.AddWithValue("@g1", TxtElektrik.Text);
                cmdgüncelle.Parameters.AddWithValue("@g2", TxtSu.Text);
                cmdgüncelle.Parameters.AddWithValue("@g3", TxtDogalgaz.Text);
                cmdgüncelle.Parameters.AddWithValue("@g4", TxtInternet.Text);
                cmdgüncelle.Parameters.AddWithValue("@g5", TxtGida.Text);
                cmdgüncelle.Parameters.AddWithValue("@g6", TxtPersonel.Text);
                cmdgüncelle.Parameters.AddWithValue("@g7", TxtDiger.Text);
                cmdgüncelle.ExecuteNonQuery();
                baglantim.baglanti().Close();
                
                MessageBox.Show("Gider Güncelleme İşlemi Başarıyla Tamamlandı", "Gider Güncelleme Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!! Lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
