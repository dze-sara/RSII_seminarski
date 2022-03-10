
namespace Rentacar.Admin.Reports
{
    partial class VehiclesReport
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
            this.VehicleBaseDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BaseBookingDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VehicleBaseDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseBookingDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // VehicleBaseDtoBindingSource
            // 
            this.VehicleBaseDtoBindingSource.DataSource = typeof(Rentacar.Dto.Response.VehicleBaseDto);
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsVehicles";
            reportDataSource1.Value = this.VehicleBaseDtoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Rentacar.Admin.Reports.ReportVehicles.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(932, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // BaseBookingDtoBindingSource
            // 
            this.BaseBookingDtoBindingSource.DataSource = typeof(Rentacar.Dto.BaseBookingDto);
            // 
            // VehiclesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(932, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "VehiclesReport";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VehicleBaseDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseBookingDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VehicleBaseDtoBindingSource;
        private System.Windows.Forms.BindingSource BaseBookingDtoBindingSource;
    }
}