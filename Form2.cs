using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
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

       
       
       

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. التأكد من إنشاء الأعمدة مرة واحدة فقط
                if (dtUsers.Columns.Count == 0)
                {
                    dtUsers.Columns.Add("Username", typeof(string));
                    dtUsers.Columns.Add("Password", typeof(string));
                    dtUsers.Columns.Add("NationalID", typeof(string));
                }

                // 2. تحميل البيانات القديمة لتجنب مسحها
                if (File.Exists(path))
                {
                    dtUsers.Clear();
                    dtUsers.ReadXml(path);
                }
                // ── VALIDATION ────────────────────────────────────────────────
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string nationalID = txtNationalID.Text.Trim();

                // Username: only English letters or numbers
                if (string.IsNullOrWhiteSpace(username) ||
                    !System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show(
                        "Username must contain English letters or numbers only.",
                        "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Clear();
                    txtUsername.Focus();
                    return;
                }

                // National ID: exactly 14 English digits
                if (string.IsNullOrWhiteSpace(nationalID) ||
                    !System.Text.RegularExpressions.Regex.IsMatch(nationalID, @"^\d{14}$"))
                {
                    MessageBox.Show(
                        "National ID must be exactly 14 digits (numbers only).",
                        "Invalid National ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNationalID.Clear();
                    txtNationalID.Focus();
                    return;
                }

                // Password: only English letters or numbers
                if (string.IsNullOrWhiteSpace(password) ||
                    !System.Text.RegularExpressions.Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show(
                        "Password must contain English letters or numbers only.",
                        "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }
                // ── END VALIDATION ────────────────────────────────────────────
                // 3. إضافة اليوزر الجديد (استخدام Trim لمنع المسافات الزائدة)
                DataRow row = dtUsers.NewRow();
                row["Username"] = username;
                row["Password"] = password;
                row["NationalID"] = nationalID;
                dtUsers.Rows.Add(row);

                // 4. الحفظ
                dtUsers.WriteXml(path);
                MessageBox.Show("Account created successfully ✅,go to login ");
                Sigin_in_form sigin_In_Form = new Sigin_in_form();
                this.Hide();
                sigin_In_Form.FormClosed += (s, args) => this.Close();
                sigin_In_Form.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

