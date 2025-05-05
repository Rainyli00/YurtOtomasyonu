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
    public partial class FrmGelirRapor : Form
    {
        public FrmGelirRapor()
        {
            InitializeComponent();
        }

        private void FrmGelirRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSetKasa.Kasa' table. You can move, or remove it, as needed.
            this.kasaTableAdapter.Fill(this.yurtOtomasyonDataSetKasa.Kasa);
            this.reportViewer1.RefreshReport();
            
            
        }
    }
}
