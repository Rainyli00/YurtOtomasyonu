namespace YurtKayitOtomasyon
{
    partial class FrmGelirRapor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGelirRapor));
            this.kasaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yurtOtomasyonDataSetKasa = new YurtKayitOtomasyon.YurtOtomasyonDataSetKasa();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.yurtOtomasyonDataSet9 = new YurtKayitOtomasyon.YurtOtomasyonDataSet9();
            this.yurtOtomasyonDataSet9BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ogrenciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ogrenciTableAdapter = new YurtKayitOtomasyon.YurtOtomasyonDataSet9TableAdapters.OgrenciTableAdapter();
            this.kasaTableAdapter = new YurtKayitOtomasyon.YurtOtomasyonDataSetKasaTableAdapters.KasaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.kasaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yurtOtomasyonDataSetKasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yurtOtomasyonDataSet9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yurtOtomasyonDataSet9BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ogrenciBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // kasaBindingSource
            // 
            this.kasaBindingSource.DataMember = "Kasa";
            this.kasaBindingSource.DataSource = this.yurtOtomasyonDataSetKasa;
            // 
            // yurtOtomasyonDataSetKasa
            // 
            this.yurtOtomasyonDataSetKasa.DataSetName = "YurtOtomasyonDataSetKasa";
            this.yurtOtomasyonDataSetKasa.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetGelir";
            reportDataSource1.Value = this.kasaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "YurtKayitOtomasyon.GelirRapor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(794, 466);
            this.reportViewer1.TabIndex = 0;
            // 
            // yurtOtomasyonDataSet9
            // 
            this.yurtOtomasyonDataSet9.DataSetName = "YurtOtomasyonDataSet9";
            this.yurtOtomasyonDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // yurtOtomasyonDataSet9BindingSource
            // 
            this.yurtOtomasyonDataSet9BindingSource.DataSource = this.yurtOtomasyonDataSet9;
            this.yurtOtomasyonDataSet9BindingSource.Position = 0;
            // 
            // ogrenciBindingSource
            // 
            this.ogrenciBindingSource.DataMember = "Ogrenci";
            this.ogrenciBindingSource.DataSource = this.yurtOtomasyonDataSet9BindingSource;
            // 
            // ogrenciTableAdapter
            // 
            this.ogrenciTableAdapter.ClearBeforeFill = true;
            // 
            // kasaTableAdapter
            // 
            this.kasaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmGelirRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(794, 466);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGelirRapor";
            this.Text = "Gelir Rapor";
            this.Load += new System.EventHandler(this.FrmGelirRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kasaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yurtOtomasyonDataSetKasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yurtOtomasyonDataSet9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yurtOtomasyonDataSet9BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ogrenciBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource yurtOtomasyonDataSet9BindingSource;
        private YurtOtomasyonDataSet9 yurtOtomasyonDataSet9;
        private System.Windows.Forms.BindingSource ogrenciBindingSource;
        private YurtOtomasyonDataSet9TableAdapters.OgrenciTableAdapter ogrenciTableAdapter;
        private YurtOtomasyonDataSetKasa yurtOtomasyonDataSetKasa;
        private System.Windows.Forms.BindingSource kasaBindingSource;
        private YurtOtomasyonDataSetKasaTableAdapters.KasaTableAdapter kasaTableAdapter;
    }
}