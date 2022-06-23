namespace CarsDB
{
    partial class ClientReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CarsDataSet = new CarsDB.CarsDataSet();
            this.КлиентBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.КлиентTableAdapter = new CarsDB.CarsDataSetTableAdapters.КлиентTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CarsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.КлиентBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.КлиентBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarsDB.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(964, 426);
            this.reportViewer1.TabIndex = 0;
            // 
            // CarsDataSet
            // 
            this.CarsDataSet.DataSetName = "CarsDataSet";
            this.CarsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // КлиентBindingSource
            // 
            this.КлиентBindingSource.DataMember = "Клиент";
            this.КлиентBindingSource.DataSource = this.CarsDataSet;
            // 
            // КлиентTableAdapter
            // 
            this.КлиентTableAdapter.ClearBeforeFill = true;
            // 
            // ClientReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ClientReport";
            this.Text = "ClientReport";
            this.Load += new System.EventHandler(this.ClientReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CarsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.КлиентBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource КлиентBindingSource;
        private CarsDataSet CarsDataSet;
        private CarsDataSetTableAdapters.КлиентTableAdapter КлиентTableAdapter;
    }
}