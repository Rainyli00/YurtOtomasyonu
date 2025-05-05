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
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }
        SqlBaglantisi baglan = new SqlBaglantisi();

        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet2.Borclar' table. You can move, or remove it, as needed.
            this.borclarTableAdapter.Fill(this.yurtOtomasyonDataSet2.Borclar);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, kalanborc,ad,soyad;
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalanborc = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            TxtAd.Text = ad;
            TxtSoyad.Text = soyad;
            TxtKalanBorc.Text = kalanborc;
            TxtOgrİd.Text = id;


        }

        private void BtnOdeme_Click(object sender, EventArgs e)
        {
            try
            {
                //ödenen borç kısmı burda ödenen tutarı kalan borçtan düşeriz.
                int odenen, kalan, yenikalan;
                odenen = Convert.ToInt16(TxtOdenen.Text);
                kalan = Convert.ToInt16(TxtKalanBorc.Text);

                yenikalan = kalan - odenen;
                TxtKalanBorc.Text = yenikalan.ToString();

                //yeni tutarı veritabanında güncelleme  
                SqlCommand borcgüncelle = new SqlCommand("update Borclar set OgrKalanBorc = @b1 where Ogrid = @b2", baglan.baglanti());
                borcgüncelle.Parameters.AddWithValue("@b2", TxtOgrİd.Text);
                borcgüncelle.Parameters.AddWithValue("@b1", yenikalan);
                borcgüncelle.ExecuteNonQuery();
                baglan.baglanti().Close();
                

                //Kasa tablosuna ekleme yapma
                SqlCommand kasaekle = new SqlCommand("insert into Kasa (OdemeAy , OdemeMiktar) values (@e1,@e2)",baglan.baglanti());
                kasaekle.Parameters.AddWithValue("@e1",TxtOdenenAy.Text);
                kasaekle.Parameters.AddWithValue("@e2", TxtOdenen.Text);
                kasaekle.ExecuteNonQuery();
                baglan.baglanti().Close();
                TxtOdenen.Clear();
                TxtOdenenAy.Clear();
                this.borclarTableAdapter.Fill(this.yurtOtomasyonDataSet2.Borclar);
                MessageBox.Show("Borç Ödendi", "Borç Tahsili Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtOgrİd.Clear();
                TxtAd.Clear();
                TxtSoyad.Clear();
                TxtKalanBorc.Clear();
                TxtOdenen.Clear();
                TxtOdenenAy.Clear();
                TxtAd.Focus();

            }
            catch (Exception)
            {

                MessageBox.Show("Hata, İşlem Gerçekleştirilemedi Lütfen Tekrar Deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            




        }
    }
}
