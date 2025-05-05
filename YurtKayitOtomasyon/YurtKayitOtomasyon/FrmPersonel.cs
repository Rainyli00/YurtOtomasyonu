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

namespace YurtKayitOtomasyon
{
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        SqlBaglantisi baglan = new SqlBaglantisi();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet6.Personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet6.Personel);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtPersonelid.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtPersonelAd.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtPersonelGorev.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtPersonelid.Clear();
            TxtPersonelAd.Clear();
            TxtPersonelGorev.Clear();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdkaydet = new SqlCommand("insert into Personel(PersonelAdSoyad,PersonelDepartman) values (@k1,@k2)", baglan.baglanti());
                cmdkaydet.Parameters.AddWithValue("@k1", TxtPersonelAd.Text);
                cmdkaydet.Parameters.AddWithValue("@k2", TxtPersonelGorev.Text);
                cmdkaydet.ExecuteNonQuery();
                baglan.baglanti().Close();
                this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet6.Personel);
                MessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleştirildi", "Kayıt Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                TxtPersonelAd.Clear();
                TxtPersonelGorev.Clear();




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
                SqlCommand cmdsil = new SqlCommand("delete from Personel where Personelid=@s1", baglan.baglanti());
                cmdsil.Parameters.AddWithValue("@s1", TxtPersonelid.Text);
                cmdsil.ExecuteNonQuery();
                baglan.baglanti().Close();
                this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet6.Personel);
                MessageBox.Show("Kayıt Silme İşlemi Başarıyla Gerçekleştirildi", "Kayıt Silme İşlemi Tamamlando", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                TxtPersonelid.Clear();
                TxtPersonelAd.Clear();
                TxtPersonelGorev.Clear();

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
                SqlCommand cmdguncelle = new SqlCommand("update Personel set PersonelAdSoyad=@g1,PersonelDepartman=@g2 where Personelid=@g3", baglan.baglanti());
                cmdguncelle.Parameters.AddWithValue("@g3",TxtPersonelid.Text );
                cmdguncelle.Parameters.AddWithValue("@g1", TxtPersonelAd.Text);
                cmdguncelle.Parameters.AddWithValue("@g2", TxtPersonelGorev.Text);
                cmdguncelle.ExecuteNonQuery();
                baglan.baglanti().Close();
                this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet6.Personel);
                MessageBox.Show("Kayıt Güncelleme İşlemi Başarıyla Gerçekleştirildi", "Kayıt Güncelleme İşlemi Tamamlando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                TxtPersonelid.Clear();
                TxtPersonelAd.Clear();
                TxtPersonelGorev.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!! Lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
