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
            this.labelFullName = new System.Windows.Forms.Label();
            this.label_Password_for_sign_up = new System.Windows.Forms.Label();
            this.labelNationalID = new System.Windows.Forms.Label();
            this.Submit_Button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelFullName
            // 
            this.labelFullName.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.Location = new System.Drawing.Point(91, 93);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(135, 35);
            this.labelFullName.TabIndex = 5;
            this.labelFullName.Text = "  Full Name";
            this.labelFullName.Click += new System.EventHandler(this.labelFullName_Click);
            // 
            // label_Password_for_sign_up
            // 
            this.label_Password_for_sign_up.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Password_for_sign_up.Location = new System.Drawing.Point(95, 169);
            this.label_Password_for_sign_up.Name = "label_Password_for_sign_up";
            this.label_Password_for_sign_up.Size = new System.Drawing.Size(170, 35);
            this.label_Password_for_sign_up.TabIndex = 6;
            this.label_Password_for_sign_up.Text = "  Password";
            // 
            // labelNationalID
            // 
            this.labelNationalID.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNationalID.Location = new System.Drawing.Point(91, 36);
            this.labelNationalID.Name = "labelNationalID";
            this.labelNationalID.Size = new System.Drawing.Size(156, 31);
            this.labelNationalID.TabIndex = 10;
            this.labelNationalID.Text = "  National ID";
            // 
            // Submit_Button
            // 
            this.Submit_Button.BackColor = System.Drawing.Color.Aqua;
            this.Submit_Button.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit_Button.Location = new System.Drawing.Point(300, 298);
            this.Submit_Button.Name = "Submit_Button";
            this.Submit_Button.Size = new System.Drawing.Size(242, 91);
            this.Submit_Button.TabIndex = 11;
            this.Submit_Button.Text = "Submit";
            this.Submit_Button.UseVisualStyleBackColor = false;
            this.Submit_Button.Click += new System.EventHandler(this.Submit_Button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(300, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 22);
            this.textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(300, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(209, 22);
            this.textBox2.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(300, 172);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(209, 22);
            this.textBox4.TabIndex = 15;
            // 
            // Form_register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 614);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Submit_Button);
            this.Controls.Add(this.labelNationalID);
            this.Controls.Add(this.label_Password_for_sign_up);
            this.Controls.Add(this.labelFullName);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
    }
}