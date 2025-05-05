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
    public partial class FrmOgrenciKayit : Form
    {
        public FrmOgrenciKayit()
        {
            InitializeComponent();
        }
       SqlBaglantisi bgl = new SqlBaglantisi();
        private void OgrenciKayitForm_Load(object sender, EventArgs e)
        {   //ComboBox Veri Çekme (bölüm)
           
            SqlCommand cmd = new SqlCommand("Select BolumAd From Bolumler",bgl.baglanti());
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {              
                CmbBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();

            //Boş Oda listeleme combobox
            
            SqlCommand cmd2 = new SqlCommand("Select OdaNo From Odalar Where OdaKapasite != OdaAktif ", bgl.baglanti());
            SqlDataReader oku2 = cmd2.ExecuteReader();
            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Girilen verileri Kaydeder Öğrenci Bilgilerini Kaydetme Kısmı
            try
            {
               
                SqlCommand cmdkaydet = new SqlCommand("INSERT INTO Ogrenci (OgrAd, OgrSoyad, OgrTC, OgrTelefon, OgrDogum, OgrBolum, OgrMail, OgrOdaNo, OgrVeliAdSoyad, OgrVeliTelefon, OgrVeliAdres) values (@k1, @k2, @k3, @k4, @k5,@k6,@k7,@k8,@k9,@k10,@k11) ", bgl.baglanti());
                cmdkaydet.Parameters.AddWithValue("@k1", TxtAd.Text);
                cmdkaydet.Parameters.AddWithValue("@k2", TxtSoyad.Text);
                cmdkaydet.Parameters.AddWithValue("@k3", MskTC.Text);
                cmdkaydet.Parameters.AddWithValue("@k4", MskTelefon.Text);
                cmdkaydet.Parameters.AddWithValue("@k5", MskDogum.Text);
                cmdkaydet.Parameters.AddWithValue("@k6", CmbBolum.Text);
                cmdkaydet.Parameters.AddWithValue("@k7", TxtMail.Text);
                cmdkaydet.Parameters.AddWithValue("@k8", CmbOdaNo.Text);
                cmdkaydet.Parameters.AddWithValue("@k9", TxtVeliAdSoyad.Text);
                cmdkaydet.Parameters.AddWithValue("@k10", mskVeliTel.Text);
                cmdkaydet.Parameters.AddWithValue("@k11", rchAdres.Text);
                cmdkaydet.ExecuteNonQuery();
                bgl.baglanti().Close();
                
                // Öğrenci id yi labele çekme
                SqlCommand komut = new SqlCommand("Select Ogrid from Ogrenci",bgl.baglanti());
                SqlDataReader oku1 = komut.ExecuteReader();

                while (oku1.Read())
                {
                    label12.Text = oku1[0].ToString();
                }
                bgl.baglanti().Close();


                // Öğrenci Borç Alanı Oluşturma
                SqlCommand cmdborckaydet = new SqlCommand("insert into Borclar (Ogrid,OgrAd,OgrSoyad) values (@b1,@b2,@b3)",bgl.baglanti());
                cmdborckaydet.Parameters.AddWithValue("@b1",label12.Text);
                cmdborckaydet.Parameters.AddWithValue("@b2", TxtAd.Text);
                cmdborckaydet.Parameters.AddWithValue("@b3",TxtSoyad.Text);
                cmdborckaydet.ExecuteNonQuery();
                


                // Öğrenci Odada aktif kalan kişi sayısını arttırma Arttırma

                SqlCommand cmdoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@o1", bgl.baglanti());
                cmdoda.Parameters.AddWithValue("@o1", CmbOdaNo.Text);
                cmdoda.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleştirildi", "Kayıt Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TxtAd.Clear();
                TxtSoyad.Clear();
                MskTC.Clear();
                MskTelefon.Clear();
                MskDogum.Clear();
                CmbBolum.SelectedIndex = -1;
                TxtMail.Clear();
                CmbOdaNo.SelectedIndex = -1;
                TxtVeliAdSoyad.Clear();
                mskVeliTel.Clear();
                rchAdres.Clear();
                
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!! Lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
            


        }
    }
}

//Data Source=Emin\SQLEXPRESS;Initial Catalog=YurtOtomasyon;Integrated Security=True;Trust Server Certificate=True