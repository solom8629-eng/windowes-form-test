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
        public Form_register()
        {
            InitializeComponent();
        }

        private void labelFullName_Click(object sender, EventArgs e)
        {

        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            Form_Show_data_ form_Show_Data = new Form_Show_data_();
            this.Hide();
            form_Show_Data.FormClosed += (s, args) => this.Close();
            form_Show_Data.ShowDialog();

        }
    }
}
