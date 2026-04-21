namespace windowes_form_test
{
    partial class Sigin_in_form
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
            this.labelNationalID = new System.Windows.Forms.Label();
            this.labelPassowrd = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonlogin = new System.Windows.Forms.Button();
            this.buttonsignup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNationalID
            // 
            this.labelNationalID.AutoSize = true;
            this.labelNationalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNationalID.Location = new System.Drawing.Point(259, 66);
            this.labelNationalID.Name = "labelNationalID";
            this.labelNationalID.Size = new System.Drawing.Size(118, 25);
            this.labelNationalID.TabIndex = 0;
            this.labelNationalID.Text = "National ID";
            // 
            // labelPassowrd
            // 
            this.labelPassowrd.AutoSize = true;
            this.labelPassowrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassowrd.Location = new System.Drawing.Point(259, 120);
            this.labelPassowrd.Name = "labelPassowrd";
            this.labelPassowrd.Size = new System.Drawing.Size(106, 25);
            this.labelPassowrd.TabIndex = 4;
            this.labelPassowrd.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(410, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 22);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(410, 124);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(139, 22);
            this.textBox2.TabIndex = 8;
            // 
            // buttonlogin
            // 
            this.buttonlogin.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonlogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonlogin.Location = new System.Drawing.Point(410, 265);
            this.buttonlogin.Name = "buttonlogin";
            this.buttonlogin.Size = new System.Drawing.Size(194, 60);
            this.buttonlogin.TabIndex = 9;
            this.buttonlogin.Text = "Login";
            this.buttonlogin.UseVisualStyleBackColor = false;
            this.buttonlogin.Click += new System.EventHandler(this.buttonlogin_Click);
            // 
            // buttonsignup
            // 
            this.buttonsignup.BackColor = System.Drawing.Color.Yellow;
            this.buttonsignup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonsignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonsignup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonsignup.Location = new System.Drawing.Point(402, 396);
            this.buttonsignup.Name = "buttonsignup";
            this.buttonsignup.Size = new System.Drawing.Size(202, 59);
            this.buttonsignup.TabIndex = 10;
            this.buttonsignup.Text = "Sign up";
            this.buttonsignup.UseVisualStyleBackColor = false;
            this.buttonsignup.Click += new System.EventHandler(this.buttonsignup_Click);
            // 
            // Sigin_in_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 546);
            this.Controls.Add(this.buttonsignup);
            this.Controls.Add(this.buttonlogin);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelPassowrd);
            this.Controls.Add(this.labelNationalID);
            this.Name = "Sigin_in_form";
            this.Text = "Sign in form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNationalID;
        private System.Windows.Forms.Label labelPassowrd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonlogin;
        private System.Windows.Forms.Button buttonsignup;
    }
}

