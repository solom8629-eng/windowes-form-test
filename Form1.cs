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
    public class Product
    {
        public string Type { get; set; }
        public DateTime ProductionDate { get; set; }
        public int ShelfLifeDays { get; set; }
    }
    public partial class Sigin_in_form : Form
    {
        public Sigin_in_form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonsignup_Click(object sender, EventArgs e)
        {

            Form_register register = new Form_register();
            //hide login form after click on button of sign up
            this.Hide();
            register.FormClosed += (s, args) => this.Close();
            register.ShowDialog();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            Form_Show_data_ form_Show_Data=new Form_Show_data_();
            //hide login form after click on button of sign up
            this.Hide();
            form_Show_Data.FormClosed += (s, args) => this.Close();
            form_Show_Data.ShowDialog();
        }
    }
}
