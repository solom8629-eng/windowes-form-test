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
    
    public partial class Form_Show_data_ : Form
    {
        public Form_Show_data_()
        {
            InitializeComponent();
        }

        private void Form_Show_data__Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseClient_informationDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.databaseClient_informationDataSet1.Products);

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

       

        private void productsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && (dataGridView1.Focused || dataGridView1.IsCurrentCellInEditMode))
            {
                try
                {
                    // 1. إجبار الجدول على إنهاء التعديل ومحاولة حفظ القيمة الحالية
                    dataGridView1.EndEdit();

                    if (dataGridView1.CurrentCell != null)
                    {
                        int col = dataGridView1.CurrentCell.ColumnIndex;
                        int row = dataGridView1.CurrentCell.RowIndex;

                        // 2. الانتقال للخانة التالية
                        if (col < dataGridView1.Columns.Count - 1)
                        {
                            dataGridView1.CurrentCell = dataGridView1[col + 1, row];
                            return true;
                        }
                        else if (row < dataGridView1.Rows.Count - 1)
                        {
                            dataGridView1.CurrentCell = dataGridView1[0, row + 1];
                            return true;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    // إذا كانت القيمة المدخلة خاطئة (مثل كتابة / في حقل تاريخ)
                    // سيلتقط البرنامج الخطأ هنا ويمنع الانتقال للخانة التالية
                    // ليعطيك فرصة لتصحيح الإدخال
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

           
      




        private void productsDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void toolStripButton1_Click_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();

            Dictionary<string, Product> productsFolder = new Dictionary<string, Product>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // 2. التحقق من أن الصف ليس فارغاً وأن أول خلية (الاسم) ليست فارغة
                if (!row.IsNewRow && row.Cells[0].Value != null && !string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                {
                    try
                    {
                        string objectName = row.Cells[0].Value.ToString();
                        Product newProd = new Product();

                        // تعبئة البيانات باستخدام أرقام الأعمدة لتجنب إيرور "Column not found"
                        // العمود 1: Type
                        newProd.Type = row.Cells[1].Value?.ToString() ?? "Unknown";

                        // العمود 2: ProductionDate (التأكد من صحة التاريخ)
                        if (row.Cells[2].Value != null && DateTime.TryParse(row.Cells[2].Value.ToString(), out DateTime pDate))
                        {
                            newProd.ProductionDate = pDate;
                        }

                        // العمود 3: ShelfLifeDays (التأكد من أنه رقم)
                        if (row.Cells[3].Value != null && int.TryParse(row.Cells[3].Value.ToString(), out int days))
                        {
                            newProd.ShelfLifeDays = days;
                        }

                        // إضافة الأوبجكت للقاموس
                        productsFolder[objectName] = newProd;
                    }
                    catch (Exception ex)
                    {
                        // منع انهيار البرنامج في حالة وجود خطأ في صف معين
                        MessageBox.Show($"خطأ في بيانات الصف: {ex.Message}");
                        continue;
                    }
                }
            }

            // 3. تحديث قاعدة البيانات (الكود الأصلي الخاص بك)
            try
            {
                this.Validate();
                this.productsBindingSource1.EndEdit();
                this.tableAdapterManager.UpdateAll(this.databaseClient_informationDataSet1);
                MessageBox.Show("تم حفظ البيانات بنجاح!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الحفظ في قاعدة البيانات: " + ex.Message);
            }

           
        }
    }
    }
    

