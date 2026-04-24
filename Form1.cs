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
                dtUserInfo.Columns.Add("Username");
                dtUserInfo.Columns.Add("Password");
                dtUserInfo.Columns.Add("NationalID");
            }

            // 2. التحقق من وجود الملف اللي إنت عملته يدويًا
            if (File.Exists(usersPath))
            {
                dtUserInfo.ReadXml(usersPath); // هيقرأ الـ admin اللي إنت ضفته
            }
        }


        private void buttonlogin_Click(object sender, EventArgs e)
        {

            // جوه زرار الـ Login
            
            string inputUser_Id = textBox_forID_Name.Text;
            string inputPass = textBox_Pass.Text;
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
