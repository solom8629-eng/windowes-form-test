using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace windowes_form_test
{
    public partial class Form_Show_data_ : Form
    {
        DataTable dtProducts = new DataTable("Products");
        string productsPath = "ProductsData.xml";

        public Form_Show_data_()
        {
            InitializeComponent();
            LoadDataFromFile();
        }

        private void LoadDataFromFile()
        {
            // Always build a fresh table with all columns as STRING
            // This prevents XML auto-detecting numbers as Int32
            DataTable freshTable = new DataTable("Products");
            freshTable.Columns.Add("Name", typeof(string));
            freshTable.Columns.Add("Type", typeof(string));
            freshTable.Columns.Add("ProductionDate", typeof(DateTime));
            freshTable.Columns.Add("ExpirationDate", typeof(DateTime));
            freshTable.Columns.Add("Price", typeof(decimal));
            freshTable.Columns.Add("OwnerID", typeof(string));
            freshTable.Columns.Add("Number of Items", typeof(int));

            if (File.Exists(productsPath))
                freshTable.ReadXml(productsPath);

            // Filter: show only current user's rows
            DataView dv = new DataView(freshTable);
            dv.RowFilter = $"OwnerID = '{GlobalUser.CurrentNationalID}'";

            // Bind filtered data to grid and to dtProducts
            dtProducts = dv.ToTable();
            dataGridView1.DataSource = dtProducts;
        }

        // Navigation with Enter key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter &&
                (dataGridView1.Focused || dataGridView1.IsCurrentCellInEditMode))
            {
                dataGridView1.EndEdit();
                if (dataGridView1.CurrentCell != null)
                {
                    int col = dataGridView1.CurrentCell.ColumnIndex;
                    int row = dataGridView1.CurrentCell.RowIndex;
                    if (col < dataGridView1.Columns.Count - 1)
                        dataGridView1.CurrentCell = dataGridView1[col + 1, row];
                    else if (row < dataGridView1.Rows.Count - 1)
                        dataGridView1.CurrentCell = dataGridView1[0, row + 1];
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form_Show_data__FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
        private void button1_Click(object sender, EventArgs e)//زرار الحفظ
        {
            try
            {
                dataGridView1.EndEdit();

                // Validate required fields
                foreach (DataRow row in dtProducts.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (string.IsNullOrWhiteSpace(row["Name"].ToString()) ||
                            string.IsNullOrWhiteSpace(row["Price"].ToString()) ||
                            string.IsNullOrWhiteSpace(row["Type"].ToString()) ||
                            string.IsNullOrWhiteSpace(row["Number of Items"].ToString()))//expiry and production
                        {
                            MessageBox.Show(
                                "Required fields: Name, Price, Type, and Number of Items",
                                "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Load ALL existing products from file (all users)
                DataTable allProducts = new DataTable("Products");
                allProducts.Columns.Add("Name", typeof(string));
                allProducts.Columns.Add("Type", typeof(string));
                allProducts.Columns.Add("ProductionDate", typeof(string));
                allProducts.Columns.Add("ExpirationDate", typeof(string));
                allProducts.Columns.Add("Price", typeof(decimal));
                allProducts.Columns.Add("OwnerID", typeof(string));
                allProducts.Columns.Add("Number of Items", typeof(int));

                if (File.Exists(productsPath))
                    allProducts.ReadXml(productsPath);

                // Remove current user's old rows from the full table
                for (int i = allProducts.Rows.Count - 1; i >= 0; i--)//بعدين 
                {
                    if (allProducts.Rows[i]["OwnerID"].ToString() == GlobalUser.CurrentNationalID)
                        allProducts.Rows.RemoveAt(i);
                }

                // Add current user's updated rows (no duplication loop)
                foreach (DataRow row in dtProducts.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        DataRow newRow = allProducts.NewRow();
                        newRow["Name"] = row["Name"].ToString();
                        newRow["Type"] = row["Type"].ToString();
                        if (DateTime.TryParse(row["ProductionDate"].ToString(), out DateTime prodDate))
                        {
                            newRow["ProductionDate"] = prodDate.ToString("yyyy-MM-dd");
                        }

                        if (DateTime.TryParse(row["ExpirationDate"].ToString(), out DateTime expDate))
                        {
                            newRow["ExpirationDate"] = expDate.ToString("yyyy-MM-dd");
                        }
                        newRow["Price"] = decimal.Parse(row["Price"].ToString());
                        newRow["OwnerID"] = GlobalUser.CurrentNationalID;
                        newRow["Number of Items"] = int.Parse(row["Number of Items"].ToString());
                        allProducts.Rows.Add(newRow);
                    }
                }

                // Save everything back to file
                allProducts.WriteXml(productsPath);

                MessageBox.Show("Data saved successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataFromFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving: " + ex.Message);
            }
        }

        // SHOW REPORT button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "Save Report As";
                saveDialog.FileName = "WarehouseReport_" + DateTime.Today.ToString("yyyy-MM-dd");

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                // dtProducts is already filtered to current user only
                DataTable sourceTable = dtProducts;

                using (var workbook = new XLWorkbook())
                {
                    var sheet = workbook.Worksheets.Add("Products Report");

                    int totalCols = sourceTable.Columns.Count;

                    // Friendly header names
                    var friendlyHeaders = new Dictionary<string, string>//بعدين
                    {
                        { "Name",            "Name"            },
                        { "Type",            "Type"            },
                        { "ProductionDate",  "Production Date" },
                        { "ExpirationDate",  "Expiration Date" },
                        { "Price",           "Price"           },
                        { "OwnerID",         "Owner ID"        },
                        { "Number of Items", "Number of Items" }
                    };

                    // Write existing column headers
                    for (int col = 0; col < totalCols; col++)//بعدين
                    {
                        string colName = sourceTable.Columns[col].ColumnName;
                        var cell = sheet.Cell(1, col +1);
                        cell.Value = friendlyHeaders.ContainsKey(colName)//بعدين
                            ? friendlyHeaders[colName] : colName;
                        StyleHeader(cell);
                    }

                    // Write 2 extra headers
                    StyleHeader(sheet.Cell(1, totalCols + 1));
                    sheet.Cell(1, totalCols + 1).Value = "Days Until Expiry";
                    StyleHeader(sheet.Cell(1, totalCols + 2));
                    sheet.Cell(1, totalCols + 2).Value = "Offer Suggestion";

                    // Write data rows
                    for (int row = 0; row < sourceTable.Rows.Count; row++)
                    {
                        DataRow dataRow = sourceTable.Rows[row];
                        int daysLeft = GetDaysLeft(dataRow);
                        string type = dataRow["Type"].ToString();
                        string daysLabel = GetDaysUntilExpiryLabel(daysLeft);
                        string offer = GetOfferSuggestion(type, daysLeft);

                        // Row color based on urgency
                        XLColor rowColor = XLColor.NoColor;
                        if (daysLeft < 0) rowColor = XLColor.LightCoral;
                        else if (daysLeft <= 20) rowColor = XLColor.OrangeRed;
                        else if (daysLeft <= 50) rowColor = XLColor.LightYellow;

                        for (int col = 0; col < totalCols; col++)
                        {
                            var cellValue = dataRow[col];
                            var cell = sheet.Cell(row + 2, col + 1);
                            cell.Value = (cellValue == DBNull.Value || cellValue == null)
                                ? "" : cellValue.ToString();
                            if (rowColor != XLColor.NoColor)
                                cell.Style.Fill.BackgroundColor = rowColor;
                        }

                        // Days Until Expiry cell
                        var daysCell = sheet.Cell(row + 2, totalCols + 1);
                        daysCell.Value = daysLabel;
                        daysCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        if (rowColor != XLColor.NoColor)
                            daysCell.Style.Fill.BackgroundColor = rowColor;

                        // Offer Suggestion cell
                        var offerCell = sheet.Cell(row + 2, totalCols + 2);
                        offerCell.Value = offer;
                        offerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        if (offer != "No offer")
                        {
                            offerCell.Style.Font.Bold = true;
                            offerCell.Style.Font.FontColor = XLColor.DarkRed;
                        }
                        if (rowColor != XLColor.NoColor)
                            offerCell.Style.Fill.BackgroundColor = rowColor;
                    }

                    sheet.Columns().AdjustToContents();
                    workbook.SaveAs(saveDialog.FileName);
                }

                var open = MessageBox.Show(
                    "Report saved!\nOpen it now?",
                    "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (open == DialogResult.Yes)
                    System.Diagnostics.Process.Start(saveDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating report: " + ex.Message);
            }
        }

        // Helpers
        private int GetDaysLeft(DataRow row)
        {
            
            DateTime production = Convert.ToDateTime(row["ProductionDate"]);
            DateTime expiry = Convert.ToDateTime(row["ExpirationDate"]);

            // طرح تاريخ الإنتاج من تاريخ الانتهاء للحصول على مدة الصلاحية الكلية
            return (expiry.Date - production.Date).Days;
        }

        private string GetDaysUntilExpiryLabel(int daysLeft)
        {
            if (daysLeft == int.MaxValue) return "No Expiry";
            if (daysLeft < 0) return "Expired (" + Math.Abs(daysLeft) + " days ago)";
            if (daysLeft == 0) return "Expires Today!";
            return daysLeft + " days left";
        }

        private string GetOfferSuggestion(string type, int daysLeft)
        {
            if (!type.ToLower().Contains("perishable")) return "No offer";
            if (daysLeft < 0) return "Remove from shelf";
            if (daysLeft <= 50) return "Apply 40% discount";
            if (daysLeft <= 20) return "Apply 20% discount";
            return "No offer";
        }

        private void StyleHeader(IXLCell cell)
        {
            cell.Style.Font.Bold = true;
            cell.Style.Fill.BackgroundColor = XLColor.DarkBlue;
            cell.Style.Font.FontColor = XLColor.White;
            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }
    }
}