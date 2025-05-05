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
    public partial class FrmYöneticiDüzenleme : Form
    {
        public FrmYöneticiDüzenleme()
        {
            InitializeComponent();
        }

        SqlBaglantisi baglan = new SqlBaglantisi();
        private void FrmYöneticiDüzenleme_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet5.Admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtYoneticiid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtKullaniciAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtYoneticiid.Clear();
            TxtKullaniciAd.Clear();
            TxtSifre.Clear();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdkaydet = new SqlCommand("insert into Admin(YoneticiAd,YoneticiSifre) values (@k1,@k2)",baglan.baglanti());
                cmdkaydet.Parameters.AddWithValue("@k1", TxtKullaniciAd.Text);
                cmdkaydet.Parameters.AddWithValue("@k2", TxtSifre.Text);
                cmdkaydet.ExecuteNonQuery();
                baglan.baglanti().Close();
                this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);
                MessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleştirildi", "Kayıt Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtKullaniciAd.Clear();
                TxtSifre.Clear();
                



            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!! Lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdsil = new SqlCommand("delete from Admin where Yoneticiid=@s1", baglan.baglanti());
                cmdsil.Parameters.AddWithValue("@s1", TxtYoneticiid.Text);
                cmdsil.ExecuteNonQuery();
                baglan.baglanti().Close();
                this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);
                MessageBox.Show("Kayıt Silme İşlemi Başarıyla Gerçekleştirildi", "Kayıt Silme İşlemi Tamamlando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                TxtYoneticiid.Clear();
                TxtKullaniciAd.Clear();
                TxtSifre.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!! Lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdguncelle = new SqlCommand("update Admin set YoneticiAd=@g1,YoneticiSifre=@g2 where Yoneticiid=@g3", baglan.baglanti());
                cmdguncelle.Parameters.AddWithValue("@g3", TxtYoneticiid.Text);
                cmdguncelle.Parameters.AddWithValue("@g1", TxtKullaniciAd.Text);
                cmdguncelle.Parameters.AddWithValue("@g2", TxtSifre.Text);
                cmdguncelle.ExecuteNonQuery();
                baglan.baglanti().Close();
                this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);
                MessageBox.Show("Kayıt Güncelleme İşlemi Başarıyla Gerçekleştirildi", "Kayıt Güncelleme İşlemi Tamamlando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                TxtYoneticiid.Clear();
                TxtKullaniciAd.Clear();
                TxtSifre.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!! Lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
