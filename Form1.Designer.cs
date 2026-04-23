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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sigin_in_form));
            this.labelNationalID = new System.Windows.Forms.Label();
            this.labelPassowrd = new System.Windows.Forms.Label();
            this.textBox_forID_Name = new System.Windows.Forms.TextBox();
            this.textBox_Pass = new System.Windows.Forms.TextBox();
            this.buttonlogin = new System.Windows.Forms.Button();
            this.button_signup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelNationalID
            // 
            this.labelNationalID.AutoSize = true;
            this.labelNationalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNationalID.Location = new System.Drawing.Point(506, 164);
            this.labelNationalID.Name = "labelNationalID";
            this.labelNationalID.Size = new System.Drawing.Size(119, 25);
            this.labelNationalID.TabIndex = 0;
            this.labelNationalID.Text = "User Name";
            // 
            // labelPassowrd
            // 
            this.labelPassowrd.AutoSize = true;
            this.labelPassowrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassowrd.Location = new System.Drawing.Point(519, 214);
            this.labelPassowrd.Name = "labelPassowrd";
            this.labelPassowrd.Size = new System.Drawing.Size(106, 25);
            this.labelPassowrd.TabIndex = 4;
            this.labelPassowrd.Text = "Password";
            // 
            // textBox_forID_Name
            // 
            this.textBox_forID_Name.Location = new System.Drawing.Point(634, 164);
            this.textBox_forID_Name.Name = "textBox_forID_Name";
            this.textBox_forID_Name.Size = new System.Drawing.Size(139, 22);
            this.textBox_forID_Name.TabIndex = 7;
            // 
            // textBox_Pass
            // 
            this.textBox_Pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Pass.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_Pass.Location = new System.Drawing.Point(634, 218);
            this.textBox_Pass.Name = "textBox_Pass";
            this.textBox_Pass.Size = new System.Drawing.Size(139, 22);
            this.textBox_Pass.TabIndex = 8;
            // 
            // buttonlogin
            // 
            this.buttonlogin.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonlogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonlogin.Location = new System.Drawing.Point(547, 324);
            this.buttonlogin.Name = "buttonlogin";
            this.buttonlogin.Size = new System.Drawing.Size(226, 70);
            this.buttonlogin.TabIndex = 9;
            this.buttonlogin.Text = "Login";
            this.buttonlogin.UseVisualStyleBackColor = false;
            this.buttonlogin.Click += new System.EventHandler(this.buttonlogin_Click);
            // 
            // button_signup
            // 
            this.button_signup.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button_signup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_signup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_signup.Location = new System.Drawing.Point(547, 471);
            this.button_signup.Name = "button_signup";
            this.button_signup.Size = new System.Drawing.Size(226, 81);
            this.button_signup.TabIndex = 10;
            this.button_signup.Text = "Sign up";
            this.button_signup.UseVisualStyleBackColor = false;
            this.button_signup.Click += new System.EventHandler(this.btn_signup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(507, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "National ID";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.Location = new System.Drawing.Point(634, 260);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 22);
            this.textBox1.TabIndex = 12;
            // 
            // Sigin_in_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1261, 684);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_signup);
            this.Controls.Add(this.buttonlogin);
            this.Controls.Add(this.textBox_Pass);
            this.Controls.Add(this.textBox_forID_Name);
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
        private System.Windows.Forms.TextBox textBox_forID_Name;
        private System.Windows.Forms.TextBox textBox_Pass;
        private System.Windows.Forms.Button buttonlogin;
        private System.Windows.Forms.Button button_signup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

