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
    public partial class FrmOgrenciDüzenleme : Form
    {
        SqlBaglantisi baglantim = new SqlBaglantisi();
        public FrmOgrenciDüzenleme()
        {
            InitializeComponent();
        }

        public string id, ad, soyad, TC, telefon, dogumtarihi, bölüm, mail, odano;

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {// Öğrenci Silme
                SqlCommand cmdsil = new SqlCommand("delete from Ogrenci where Ogrid=@s1", baglantim.baglanti());
                cmdsil.Parameters.AddWithValue("@s1", TxtOgrİd.Text);
                cmdsil.ExecuteNonQuery();
                baglantim.baglanti().Close();


                // Odada Kalan aktif kişi sayısını azaltma 
                SqlCommand cmdodasayi = new SqlCommand("update Odalar set OdaAktif = OdaAktif - 1 where OdaNo=@od1", baglantim.baglanti());
                cmdodasayi.Parameters.AddWithValue("@od1",CmbOdaNo.Text);
                cmdodasayi.ExecuteNonQuery();

                //Borçlar Tablosundaki Öğrenciyi Silme
                SqlCommand cmdsilborclar = new SqlCommand("delete from Borclar where Ogrid=@s1", baglantim.baglanti());
                cmdsilborclar.Parameters.AddWithValue("@s1", TxtOgrİd.Text);
                cmdsilborclar.ExecuteNonQuery();
                baglantim.baglanti().Close();

                //Boş Oda listeleme combobox

                SqlCommand cmd2 = new SqlCommand("Select OdaNo From Odalar Where OdaKapasite != OdaAktif ", baglantim.baglanti());
                SqlDataReader oku2 = cmd2.ExecuteReader();
                while (oku2.Read())
                {
                    CmbOdaNo.Items.Add(oku2[0].ToString());
                }
                baglantim.baglanti().Close();

                MessageBox.Show("Kayıt Silme İşlemi Başarıyla Gerçekleştirildi", "Kayıt Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtOgrİd.Clear();
                TxtAd.Clear();
                TxtSoyad.Clear();
                MskTC.Clear();
                MskTelefon.Clear();
                MskDogum.Clear();
                CmbBolum.Text = "";
                TxtMail.Clear();
                CmbOdaNo.Text = "";
                TxtVeliAdSoyad.Clear();
                mskVeliTel.Clear();
                rchAdres.Clear();
                TxtAd.Focus();


            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!! Lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public string veliAdSoyad, velitelefon, adres;

        private void FrmOgrenciDüzenleme_Load(object sender, EventArgs e)
        {
            TxtOgrİd.Text = id;
            TxtAd.Text = ad;
            TxtSoyad.Text = soyad;
            MskTC.Text = TC;
            MskTelefon.Text = telefon;
            MskDogum.Text = dogumtarihi;
            CmbBolum.Text = bölüm;
            TxtMail.Text = mail;
            CmbOdaNo.Text = odano;
            TxtVeliAdSoyad.Text = veliAdSoyad;
            mskVeliTel.Text = velitelefon;
            rchAdres.Text = adres;

            //ComboBox Veri Çekme (bölüm)

            SqlCommand cmd = new SqlCommand("Select BolumAd From Bolumler", baglantim.baglanti());
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString());
            }
            baglantim.baglanti().Close();

            //Boş Oda listeleme combobox

            SqlCommand cmd2 = new SqlCommand("Select OdaNo From Odalar Where OdaKapasite != OdaAktif ", baglantim.baglanti());
            SqlDataReader oku2 = cmd2.ExecuteReader();
            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());
            }
            baglantim.baglanti().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdguncelle = new SqlCommand("update Ogrenci set OgrAd=@g1,OgrSoyad=@g2,OgrTC=@g3,OgrTelefon=@g4,OgrDogum=@g5,OgrBolum=@g6,OgrMail=@g7,OgrOdaNo=@g8,OgrVeliAdSoyad=@g9,OgrVeliTelefon=@g10,OgrVeliAdres=@g11 where Ogrid = @g12", baglantim.baglanti());
                cmdguncelle.Parameters.AddWithValue("@g12", TxtOgrİd.Text);
                cmdguncelle.Parameters.AddWithValue("@g1", TxtAd.Text);
                cmdguncelle.Parameters.AddWithValue("@g2", TxtSoyad.Text);
                cmdguncelle.Parameters.AddWithValue("@g3", MskTC.Text);
                cmdguncelle.Parameters.AddWithValue("@g4", MskTelefon.Text);
                cmdguncelle.Parameters.AddWithValue("@g5", MskDogum.Text);
                cmdguncelle.Parameters.AddWithValue("@g6", CmbBolum.Text);
                cmdguncelle.Parameters.AddWithValue("@g7", TxtMail.Text);
                cmdguncelle.Parameters.AddWithValue("@g8", CmbOdaNo.Text);
                cmdguncelle.Parameters.AddWithValue("@g9", TxtVeliAdSoyad.Text);
                cmdguncelle.Parameters.AddWithValue("@g10", mskVeliTel.Text);
                cmdguncelle.Parameters.AddWithValue("@g11", rchAdres.Text);
                cmdguncelle.ExecuteNonQuery();
                baglantim.baglanti().Close();
                MessageBox.Show("Kayıt Güncelleme İşlemi Başarıyla Gerçekleştirildi", "Kayıt Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!! Lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
