
namespace Rentacar.Admin
{
    partial class UserDetails
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
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.userDetailsControl1 = new Rentacar.Admin.UserDetailsControl();
            this.SuspendLayout();
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteUser.Location = new System.Drawing.Point(16, 391);
            this.buttonDeleteUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(201, 59);
            this.buttonDeleteUser.TabIndex = 1;
            this.buttonDeleteUser.Text = "DELETE USER";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(241, 391);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(197, 59);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "EXIT";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // userDetailsControl1
            // 
            this.userDetailsControl1.Location = new System.Drawing.Point(16, 15);
            this.userDetailsControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.userDetailsControl1.Name = "userDetailsControl1";
            this.userDetailsControl1.Size = new System.Drawing.Size(424, 369);
            this.userDetailsControl1.TabIndex = 0;
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 479);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDeleteUser);
            this.Controls.Add(this.userDetailsControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserDetails";
            this.Text = "UserDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private UserDetailsControl userDetailsControl1;
        private System.Windows.Forms.Button buttonDeleteUser;
        private System.Windows.Forms.Button buttonExit;
    }
}