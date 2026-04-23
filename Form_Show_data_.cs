using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace windowes_form_test
{
    public partial class Form_Show_data_ : Form
    {
        DataTable dtProducts = new DataTable("Products");
        string productsPath = "ProductsData.xml";

        public Form_Show_data_()
        {
            InitializeComponent();
            SetupTables();
            LoadDataFromFile();
        }

        private void SetupTables()
        {
            if (dtProducts.Columns.Count == 0)
            {
                dataGridView1.AutoGenerateColumns = true;
                dtProducts.Columns.Add("Name");
                dtProducts.Columns.Add("Type");
                dtProducts.Columns.Add("ProductionDate", typeof(DateTime));
                dtProducts.Columns.Add("ExpirationDate", typeof(DateTime));
                dtProducts.Columns.Add("Price", typeof(double));
            }
            dataGridView1.DataSource = dtProducts;
        }

        private void LoadDataFromFile()
        {
            if (File.Exists(productsPath))
            {
                dtProducts.Clear();
                dtProducts.ReadXml(productsPath);
            }
        }

        // --- ميزة التنقل بالـ Enter ---
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && (dataGridView1.Focused || dataGridView1.IsCurrentCellInEditMode))
            {
                dataGridView1.EndEdit(); // حفظ التعديل الحالي قبل الانتقال

                if (dataGridView1.CurrentCell != null)
                {
                    int col = dataGridView1.CurrentCell.ColumnIndex;
                    int row = dataGridView1.CurrentCell.RowIndex;

                    // لو مش في آخر عمود، انقل للخلية اللي على اليمين
                    if (col < dataGridView1.Columns.Count - 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1[col + 1, row];
                    }
                    // لو في آخر عمود، انقل لأول عمود في السطر اللي بعده
                    else if (row < dataGridView1.Rows.Count - 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1[0, row + 1];
                    }
                    return true; // إخبار الويندوز إننا عالجنا الضغطة خلاص
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Save_button(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();

                //كود حساب مده الصلاحيه هيكتب هنا يشباب

                dtProducts.WriteXml(productsPath);
                MessageBox.Show("تم الحفظ بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }
    }
}