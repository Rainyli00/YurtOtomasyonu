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
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
            
        }
        

        private void ChckSifreGöster_CheckedChanged(object sender, EventArgs e)
        {
            if(ChckSifreGöster.Checked)
            {
                TxtSifre.UseSystemPasswordChar = false;
            }

            else
                TxtSifre.UseSystemPasswordChar = true;

        }
        SqlBaglantisi baglan = new SqlBaglantisi();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmdgiris = new SqlCommand("Select * From Admin Where YoneticiAd=@g1 and YoneticiSifre=@g2",baglan.baglanti());
            cmdgiris.Parameters.AddWithValue("@g1",TxtKullaniciAd.Text);
            cmdgiris.Parameters.AddWithValue("@g2", TxtSifre.Text);
            SqlDataReader oku = cmdgiris.ExecuteReader();
            if (oku.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre Girdiniz Lütfen Tekrar Deneyin!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtKullaniciAd.Clear();
                TxtSifre.Clear();
                TxtKullaniciAd.Focus();
            }
            baglan.baglanti().Close();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
