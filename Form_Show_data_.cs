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
                dtProducts.Columns.Add("OwnerID",typeof(int));
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

            // اتأكد إن السطر ده موجود عشان لو الملف لسه جديد ومفيهوش أعمدة
            if (!dtProducts.Columns.Contains("OwnerID"))
            {
                dtProducts.Columns.Add("OwnerID");
            }

            DataView dv = new DataView(dtProducts);
            // اتأكد إن المتغير GlobalUser.CurrentNationalID مش فاضي
            dv.RowFilter = $"OwnerID = '{GlobalUser.CurrentNationalID}'";
            dataGridView1.DataSource = dv;
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

       

        private void toolStripButton1_Click_Click(object sender, EventArgs e)
        {
            try
            {
           
                dataGridView1.EndEdit();

                
                foreach (DataRow row in dtProducts.Rows)
                {
                    
                    if (row.RowState == DataRowState.Added || row["OwnerID"] == DBNull.Value || string.IsNullOrEmpty(row["OwnerID"].ToString()))
                    {
                        row["OwnerID"] = GlobalUser.CurrentNationalID;
                    }
                }

                
                dtProducts.WriteXml(productsPath);

                
                MessageBox.Show("Your Data is Saved");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("خطأ أثناء الحفظ: " + ex.Message);
            }
        }
    }
}