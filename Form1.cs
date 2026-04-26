using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace windowes_form_test
{


    public partial class Sigin_in_form : Form
    {
        DataTable dtUserInfo = new DataTable("UsereFilexml");
        string usersPath = "UsereFilexml.xml"; // المسار الموحد
        public Sigin_in_form()
        {
           
            InitializeComponent();
            PrepareUserData(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }
        private void PrepareUserData()
        {
            // 1. تعريف الأعمدة أولاً لتهيئة الجدول في الذاكرة
            if (dtUserInfo.Columns.Count == 0)
            {
                dtUserInfo.Columns.Add("Username", typeof(string));
                dtUserInfo.Columns.Add("Password", typeof(string));
                dtUserInfo.Columns.Add("NationalID", typeof(string));
            }

            // 2. التحقق من وجود الملف اللي إنت عملته يدويًا
            if (File.Exists(usersPath))
            {
                dtUserInfo.ReadXml(usersPath); // هيقرأ الـ admin اللي إنت ضفته
            }
        }


        private void buttonlogin_Click(object sender, EventArgs e)
        {

            // ── VALIDATION ────────────────────────────────────────────────
            string inputUser_Id = textBox_forID_Name.Text.Trim();
            string inputPass = textBox_Pass.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputUser_Id) ||
                !System.Text.RegularExpressions.Regex.IsMatch(inputUser_Id, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show(
                    "Username must contain English letters or numbers only.",
                    "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_forID_Name.Clear();
                textBox_forID_Name.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(inputPass) ||
                !System.Text.RegularExpressions.Regex.IsMatch(inputPass, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show(
                    "Password must contain English letters or numbers only.",
                    "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Pass.Clear();
                textBox_Pass.Focus();
                return;
            }

            // ── END VALIDATION ────────────────────────────────────────────
            DataRow[] foundRows = dtUserInfo.Select($"Username = '{inputUser_Id}' AND Password = '{inputPass}'");
           
            if (foundRows.Length > 0)
            {
                // سحب الـ NationalID والاسم من السطر اللي لقيناه
                GlobalUser.CurrentNationalID = foundRows[0]["NationalID"].ToString();
                GlobalUser.CurrentUserName = foundRows[0]["Username"].ToString();

                MessageBox.Show("Welcome " + GlobalUser.CurrentUserName);

                Form_Show_data_ mainDataForm = new Form_Show_data_();
                mainDataForm.Show();
                this.Hide();
            }

            else
            {
               
                MessageBox.Show("You don't have account please sign up frist");
            }
        
        }
        private void btn_signup_Click(object sender, EventArgs e)
        {
            Form_register form_Register = new Form_register();
            this.Hide();
            form_Register.FormClosed += (s, args) => this.Close();
            form_Register.ShowDialog();
        }
     }
}
