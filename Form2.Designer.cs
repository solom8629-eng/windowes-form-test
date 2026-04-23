namespace windowes_form_test
{
    partial class Form_register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_register));
            this.labelFullName = new System.Windows.Forms.Label();
            this.label_Password_for_sign_up = new System.Windows.Forms.Label();
            this.labelNationalID = new System.Windows.Forms.Label();
            this.Submit_Button = new System.Windows.Forms.Button();
            this.txtNationalID = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelFullName
            // 
            this.labelFullName.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.Location = new System.Drawing.Point(169, 165);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(152, 35);
            this.labelFullName.TabIndex = 5;
            this.labelFullName.Text = "  Full Name";
            this.labelFullName.Click += new System.EventHandler(this.labelFullName_Click);
            // 
            // label_Password_for_sign_up
            // 
            this.label_Password_for_sign_up.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Password_for_sign_up.Location = new System.Drawing.Point(169, 239);
            this.label_Password_for_sign_up.Name = "label_Password_for_sign_up";
            this.label_Password_for_sign_up.Size = new System.Drawing.Size(156, 35);
            this.label_Password_for_sign_up.TabIndex = 6;
            this.label_Password_for_sign_up.Text = "  Password";
            // 
            // labelNationalID
            // 
            this.labelNationalID.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNationalID.Location = new System.Drawing.Point(153, 105);
            this.labelNationalID.Name = "labelNationalID";
            this.labelNationalID.Size = new System.Drawing.Size(168, 31);
            this.labelNationalID.TabIndex = 10;
            this.labelNationalID.Text = "  National ID";
            // 
            // Submit_Button
            // 
            this.Submit_Button.BackColor = System.Drawing.Color.Aqua;
            this.Submit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Submit_Button.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit_Button.Location = new System.Drawing.Point(342, 341);
            this.Submit_Button.Name = "Submit_Button";
            this.Submit_Button.Size = new System.Drawing.Size(216, 76);
            this.Submit_Button.TabIndex = 11;
            this.Submit_Button.Text = "Submit";
            this.Submit_Button.UseVisualStyleBackColor = false;
            this.Submit_Button.Click += new System.EventHandler(this.Submit_Button_Click);
            // 
            // txtNationalID
            // 
            this.txtNationalID.Location = new System.Drawing.Point(342, 105);
            this.txtNationalID.Name = "txtNationalID";
            this.txtNationalID.Size = new System.Drawing.Size(209, 22);
            this.txtNationalID.TabIndex = 12;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(342, 168);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(209, 22);
            this.txtUsername.TabIndex = 13;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(342, 242);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(209, 22);
            this.txtPassword.TabIndex = 15;
            // 
            // Form_register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(926, 614);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtNationalID);
            this.Controls.Add(this.Submit_Button);
            this.Controls.Add(this.labelNationalID);
            this.Controls.Add(this.label_Password_for_sign_up);
            this.Controls.Add(this.labelFullName);
            this.DoubleBuffered = true;
            this.Name = "Form_register";
            this.Text = "Sign up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label label_Password_for_sign_up;
        private System.Windows.Forms.Label labelNationalID;
        private System.Windows.Forms.Button Submit_Button;
        private System.Windows.Forms.TextBox txtNationalID;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
    }
}