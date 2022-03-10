
namespace Rentacar.Admin
{
    partial class BookingDetails
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
            this.bookingDetailsControl1 = new Rentacar.Admin.Controls.BookingDetailsControl();
            this.userDetailsControlNonEditable1 = new Rentacar.Admin.Controls.UserDetailsControlNonEditable();
            this.vehicleDetailsControlNonEditable1 = new Rentacar.Admin.Controls.VehicleDetailsControlNonEditable();
            this.SuspendLayout();
            // 
            // bookingDetailsControl1
            // 
            this.bookingDetailsControl1.AutoSize = true;
            this.bookingDetailsControl1.Location = new System.Drawing.Point(-3, -2);
            this.bookingDetailsControl1.Name = "bookingDetailsControl1";
            this.bookingDetailsControl1.Size = new System.Drawing.Size(341, 360);
            this.bookingDetailsControl1.TabIndex = 0;
            // 
            // userDetailsControlNonEditable1
            // 
            this.userDetailsControlNonEditable1.AutoSize = true;
            this.userDetailsControlNonEditable1.Location = new System.Drawing.Point(755, 28);
            this.userDetailsControlNonEditable1.Name = "userDetailsControlNonEditable1";
            this.userDetailsControlNonEditable1.Size = new System.Drawing.Size(289, 237);
            this.userDetailsControlNonEditable1.TabIndex = 2;
            this.userDetailsControlNonEditable1.User = null;
            // 
            // vehicleDetailsControlNonEditable1
            // 
            this.vehicleDetailsControlNonEditable1.Location = new System.Drawing.Point(376, 28);
            this.vehicleDetailsControlNonEditable1.Name = "vehicleDetailsControlNonEditable1";
            this.vehicleDetailsControlNonEditable1.Size = new System.Drawing.Size(363, 396);
            this.vehicleDetailsControlNonEditable1.TabIndex = 3;
            this.vehicleDetailsControlNonEditable1.Vehicle = null;
            // 
            // BookingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 426);
            this.Controls.Add(this.vehicleDetailsControlNonEditable1);
            this.Controls.Add(this.userDetailsControlNonEditable1);
            this.Controls.Add(this.bookingDetailsControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BookingDetails";
            this.Text = "BookingDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.BookingDetailsControl bookingDetailsControl1;
        private Controls.UserDetailsControlNonEditable userDetailsControlNonEditable1;
        private Controls.VehicleDetailsControlNonEditable vehicleDetailsControlNonEditable1;
    }
}