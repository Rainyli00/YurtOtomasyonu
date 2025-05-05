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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }

       SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);

        }

        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {

            try
            {
                
                SqlCommand cmdekle = new SqlCommand("insert into Bolumler (BolumAd) values (@b1)", bgl.baglanti());
                //@b1 bir parametre 
                cmdekle.Parameters.AddWithValue("@b1", TxtBolumAd.Text);
                cmdekle.ExecuteNonQuery();
                bgl.baglanti().Close();
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
                MessageBox.Show("Bölüm Ekleme İşlemi Başarıyla Tamamlandı.", "Bölüm Kaydı Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                TxtBolumAd.Clear();
                TxtBolumID.Clear();
                TxtBolumAd.Focus();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata, İşlem Gerçekleştirilemedi Lütfen Tekrar Deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlCommand cmdsil = new SqlCommand("delete from Bolumler where Bolumid=@b1", bgl.baglanti());
                cmdsil.Parameters.AddWithValue("@b1", TxtBolumID.Text);
                cmdsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
                MessageBox.Show("Bölüm Silme İşlemi Başarıyla Tamamlandı.", "Bölüm Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                TxtBolumAd.Clear();
                TxtBolumID.Clear();
                TxtBolumAd.Focus();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata, İşlem Gerçekleştirilemedi Lütfen Tekrar Deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            
            TxtBolumID.Text = id;
            TxtBolumAd.Text = bolumad;
        }

        private void PcbBolumDüzenle_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlCommand cmdedit = new SqlCommand("update Bolumler set BolumAd=@b1 where Bolumid =@b2",bgl.baglanti());
                cmdedit.Parameters.AddWithValue("@b2", TxtBolumID.Text);
                cmdedit.Parameters.AddWithValue("@b1", TxtBolumAd.Text);
                
                cmdedit.ExecuteNonQuery();
                bgl.baglanti().Close();
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
                MessageBox.Show("Bölüm Güncelleme İşlemi Başarıyla Tamamlandı.", "Bölüm Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtBolumAd.Clear();
                TxtBolumID.Clear();


            }
            catch (Exception)
            {

                MessageBox.Show("Hata, İşlem Gerçekleştirilemedi Lütfen Tekrar Deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

      
    }
}
