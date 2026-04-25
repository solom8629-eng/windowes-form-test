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
                dtProducts.Columns.Add("Number of Items", typeof(int));
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

                // 1. هنعمل جدول مؤقت بنفس شكل الجدول الأصلي عشان نخزن فيه التكرار
                DataTable dtFinalSave = dtProducts.Clone();

                foreach (DataRow row in dtProducts.Rows)
                {
                    // قراءة العدد اللي اليوزر دخله (لو سابه فاضي بنعتبره 1)
                    int count = 1;
                    if (row["Number of Items"] != DBNull.Value && int.TryParse(row["Number of Items"].ToString(), out int res))
                    {
                        count = res > 0 ? res : 1;
                    }

                    // 2. تكرار إضافة المنتج بناءً على العدد
                    for (int i = 0; i < count; i++)
                    {
                        DataRow newRow = dtFinalSave.NewRow();
                        newRow.ItemArray = row.ItemArray; // بننسخ كل البيانات (الاسم، السعر، التاريخ)

                        // التأكد من ربط المنتج باليوزر الحالي
                        if (newRow["OwnerID"] == DBNull.Value || string.IsNullOrEmpty(newRow["OwnerID"].ToString()))
                        {
                            newRow["OwnerID"] = GlobalUser.CurrentNationalID;
                        }

                        dtFinalSave.Rows.Add(newRow);
                    }
                }

                // 3. حفظ الجدول النهائي اللي فيه التكرار في ملف XML
                dtFinalSave.WriteXml(productsPath);

                MessageBox.Show("Data saved successfully ");

                // إعادة تحميل البيانات عشان تظهر الفلترة صح
                LoadDataFromFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving: " + ex.Message);
            }
        }

        private void Form_Show_data__FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}