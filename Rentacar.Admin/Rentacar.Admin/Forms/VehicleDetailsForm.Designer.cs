
namespace Rentacar.Admin
{
    partial class VehicleDetails
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
            this.vehicleDetailsControl1 = new Rentacar.Admin.Controls.VehicleDetailsControl();
            this.SuspendLayout();
            // 
            // vehicleDetailsControl1
            // 
            this.vehicleDetailsControl1.Location = new System.Drawing.Point(32, 13);
            this.vehicleDetailsControl1.Margin = new System.Windows.Forms.Padding(4);
            this.vehicleDetailsControl1.Name = "vehicleDetailsControl1";
            this.vehicleDetailsControl1.Size = new System.Drawing.Size(407, 378);
            this.vehicleDetailsControl1.TabIndex = 0;
            this.vehicleDetailsControl1.Vehicle = null;
            // 
            // VehicleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(484, 467);
            this.Controls.Add(this.vehicleDetailsControl1);
            this.Name = "VehicleDetails";
            this.Text = "VehicleDetails";
            this.Load += new System.EventHandler(this.VehicleDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.VehicleDetailsControl vehicleDetailsControl1;
    }
}