
namespace Rentacar.Admin.Reports
{
    partial class BookingsReport
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
            this.BaseBookingDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.BaseBookingDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BaseBookingDtoBindingSource
            // 
            this.BaseBookingDtoBindingSource.DataSource = typeof(Rentacar.Dto.BaseBookingDto);
            // 
            // reportViewer2
            // 
            reportDataSource1.Name = "dsBookings";
            reportDataSource1.Value = this.BaseBookingDtoBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Rentacar.Admin.Reports.BookingsReport.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(12, 12);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1055, 412);
            this.reportViewer2.TabIndex = 1;
            // 
            // BookingsReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1079, 450);
            this.Controls.Add(this.reportViewer2);
            this.Name = "BookingsReport";
            this.Text = "BookingsReport";
            this.Load += new System.EventHandler(this.BookingsReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaseBookingDtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource BaseBookingDtoBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}