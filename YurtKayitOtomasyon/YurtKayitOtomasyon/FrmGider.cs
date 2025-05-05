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
    public partial class FrmGider : Form
    {
        SqlBaglantisi baglantim = new SqlBaglantisi();
        public FrmGider()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdkaydet = new SqlCommand("insert into Giderler (Elektrik,Su,Dogalgaz,internet,Gıda,Personel,Diger) values (@k1,@k2,@k3,@k4,@k5,@k6,@k7) ", baglantim.baglanti());
                cmdkaydet.Parameters.AddWithValue("@k1", TxtElektrik.Text);
                cmdkaydet.Parameters.AddWithValue("@k2", TxtSu.Text);
                cmdkaydet.Parameters.AddWithValue("@k3", TxtDogalgaz.Text);
                cmdkaydet.Parameters.AddWithValue("@k4", TxtInternet.Text);
                cmdkaydet.Parameters.AddWithValue("@k5", TxtGida.Text);
                cmdkaydet.Parameters.AddWithValue("@k6", TxtPersonel.Text);
                cmdkaydet.Parameters.AddWithValue("@k7", TxtDiger.Text);
                cmdkaydet.ExecuteNonQuery();
                baglantim.baglanti().Close();
                MessageBox.Show("Gider Kayıtları Başarıyla Eklendi", "Gider Kaydı Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtElektrik.Clear();
                TxtSu.Clear();
                TxtDogalgaz.Clear();
                TxtInternet.Clear();
                TxtGida.Clear();
                TxtPersonel.Clear();
                TxtDiger.Clear();
                TxtElektrik.Focus();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!! Lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
