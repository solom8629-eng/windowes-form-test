using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowes_form_test
{
    public partial class Form_register : Form
    {
        DataTable dtUsers = new DataTable("UsereFilexml");
        string path = "UsereFilexml.xml";
        public Form_register()
        {
           
            InitializeComponent();
           
            if (dtUsers.Columns.Count == 0)
            {
                dtUsers.Columns.Add("Username");
                dtUsers.Columns.Add("Password");
                dtUsers.Columns.Add("NationalID");
            }
        }

        private void labelFullName_Click(object sender, EventArgs e)
        {

        }

       
        private void Submit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. شلنا سطر الـ DataTable dtUsers من هنا لأننا عرفناه فوق

                // 2. اقرأ البيانات لو الملف موجود
                if (System.IO.File.Exists(path))
                {
                    dtUsers.Clear(); // خطوة مهمة: فضي الجدول في الذاكرة قبل ما تقرأ من الملف
                    dtUsers.ReadXml(path);
                }

                // 3. إضافة اليوزر الجديد
                DataRow newRow = dtUsers.NewRow();
                newRow["Username"] = txtUsername.Text; // اتأكد إن الاسم هنا هو نفس اللي في الأعمدة فوق
                newRow["Password"] = txtPassword.Text;
                newRow["NationalID"] = txtNationalID.Text;

                dtUsers.Rows.Add(newRow);

                // 4. الحفظ
                dtUsers.WriteXml(path);
               
                txtUsername.Clear();
                txtPassword.Clear();
                txtNationalID.Clear();
                Sigin_in_form sigin_In_Form = new Sigin_in_form();
                MessageBox.Show("the Account is created successfully ,please return to login form");
                this.Hide();
                sigin_In_Form.FormClosed += (s, args) => this.Close();
                sigin_In_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ex.Message);
            }
           
        }
    }
}

