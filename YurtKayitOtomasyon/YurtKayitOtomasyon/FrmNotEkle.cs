using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http.Headers;

namespace YurtKayitOtomasyon
{
    public partial class FrmNotEkle : Form
    {
        public FrmNotEkle()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Lütfen Kayıt Yeri Seçiniz";
                saveFileDialog1.Filter = "Metin Dosyası | *.txt";
                //saveFileDialog1.InitialDirectory = "Buraya Kaydetmesini İstediğniz dosyanının yolu girilecek";
                saveFileDialog1.ShowDialog();
                StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName);
                kaydet.WriteLine(richTextBox1.Text);
                kaydet.Close();
                MessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleştirildi", "Kayıt Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!! Lütfen tekrar deneyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
