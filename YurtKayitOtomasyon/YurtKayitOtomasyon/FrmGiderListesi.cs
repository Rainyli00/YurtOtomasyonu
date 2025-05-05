using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitOtomasyon
{
    public partial class FrmGiderListesi : Form
    {
        public FrmGiderListesi()
        {
            InitializeComponent();
        }

        private void FrmGiderListesi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet4.Giderler' table. You can move, or remove it, as needed.
            this.giderlerTableAdapter.Fill(this.yurtOtomasyonDataSet4.Giderler);

        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            FrmGiderGuncelle frmgüncelle = new FrmGiderGuncelle();

            secilen = dataGridView1.SelectedCells[0].RowIndex;
            frmgüncelle.giderid = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            frmgüncelle.elektrik = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            frmgüncelle.su = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            frmgüncelle.dogalgaz = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            frmgüncelle.internet = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            frmgüncelle.gida = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            frmgüncelle.personel = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            frmgüncelle.diger = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            frmgüncelle.Show();

        }

       
    }
}
