using ClosedXML.Excel;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace windowes_form_test
{
    public partial class Form_Show_data_ : Form
    {
        DataTable dtProducts = new DataTable("Products");
        string productsPath = "ProductsData.xml";

        public Form_Show_data_()
        {
            InitializeComponent(); // Builds the UI controls designed in the Form Designer
            LoadDataFromFile();      // Immediately loads & displays data when the form opens
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
            dtProducts = dv.ToTable(); //ToTable() converts the filtered view into a real standalone DataTable.
            dataGridView1.DataSource = dtProducts;
        }

        // Navigation with Enter key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //Overrides the default key handler at the form level
        {
            if (keyData == Keys.Enter &&
                (dataGridView1.Focused || dataGridView1.IsCurrentCellInEditMode)) //Only activates when Enter is pressed and the grid is focused or being edited.
            {
                dataGridView1.EndEdit();
                if (dataGridView1.CurrentCell != null)
                {
                    int col = dataGridView1.CurrentCell.ColumnIndex;
                    int row = dataGridView1.CurrentCell.RowIndex;
                    if (col < dataGridView1.Columns.Count - 1) //-1 because the difference between index and the count
                        dataGridView1.CurrentCell = dataGridView1[col + 1, row];
                    else if (row < dataGridView1.Rows.Count - 1)
                        dataGridView1.CurrentCell = dataGridView1[0, row + 1];
                    return true; 
                    //Mimicks excel style of typing that the enter key moves to right and if the columns are finished it goes for the second row
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form_Show_data__FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); //close the entire application when the form is closed
        }

       
        private void button1_Click(object sender, EventArgs e)//Save button Validation
        {
            try
            {
                dataGridView1.EndEdit();  //commits any cell currently being edited before saving

                // Loops around each column for checking each cell isnot Null
                foreach (DataRow row in dtProducts.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (string.IsNullOrWhiteSpace(row["Name"].ToString()) ||
                            string.IsNullOrWhiteSpace(row["Price"].ToString()) ||
                            string.IsNullOrWhiteSpace(row["Type"].ToString()) ||
                            string.IsNullOrWhiteSpace(row["Number of Items"].ToString()) ||
                            string.IsNullOrWhiteSpace(row["ProductionDate"].ToString()) ||
                            string.IsNullOrWhiteSpace(row["ExpirationDate"].ToString()) )
                        {
                            MessageBox.Show(
                                "Required fields: Name, Price, Type, ProductionDate, Expiration Date and Number of Items",
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

                if (File.Exists(productsPath)) //check if there is a saved data in the xml file and load it if found
                    allProducts.ReadXml(productsPath);

                // Remove current user's old rows from the full table to avoid duplication of the rows 
                for (int i = allProducts.Rows.Count - 1; i >= 0; i--)
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
                // Opens a Save dialog so the user picks where to save the Excel file
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";   //Filters the Name of the file to be saved as an excel file .xlsx
                saveDialog.Title = "Save Report As";    //the title of the window
                saveDialog.FileName = "WarehouseReport_" + DateTime.Today.ToString("yyyy-MM-dd"); //the suggested name when hitting the showreport button

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                // dtProducts is already filtered to current user only
                DataTable sourceTable = dtProducts;

                using (var workbook = new XLWorkbook())
                {
                    var sheet = workbook.Worksheets.Add("Products Report"); //Creates a new Excel workbook in memory using the ClosedXML library.

                    int totalCols = sourceTable.Columns.Count;

                    // Writes the column Headers
                    var friendlyHeaders = new Dictionary<string, string> //dictionary translates the input into the output
                    {
                        { "Name",            "Name"            }, //Internal Name ==> the Name in the excel sheet
                        { "Type",            "Type"            },
                        { "ProductionDate",  "Production Date" },
                        { "ExpirationDate",  "Expiration Date" },
                        { "Price",           "Price"           },
                        { "OwnerID",         "Owner ID"        },
                        { "Number of Items", "Number of Items" }
                    };

                     
                    for (int col = 0; col < totalCols; col++)//outerloop loops through all the columns from 0 to totalcols-1 {due to the index difference}
                    {
                        string colName = sourceTable.Columns[col].ColumnName; // saves the internal column name from the datatable at position {col}
                        var cell = sheet.Cell(1, col +1); // Row is 1 because we're writing the header row and the col+1 because the indexer starts at 0
                        cell.Value = friendlyHeaders.ContainsKey(colName)? friendlyHeaders[colName] : colName; //checks for an edited name for the column if not display the old name
                        StyleHeader(cell); // calls the style header function that edited the cell colour
                    }

                    // Write 2 extra headers
                    StyleHeader(sheet.Cell(1, totalCols + 1));
                    sheet.Cell(1, totalCols + 1).Value = "Days Until Expiry";
                    StyleHeader(sheet.Cell(1, totalCols + 2));
                    sheet.Cell(1, totalCols + 2).Value = "Offer Suggestion";

                    // innerloop that Write data rows also regarding its expiry date
                    for (int row = 0; row < sourceTable.Rows.Count; row++)
                    {
                        DataRow dataRow = sourceTable.Rows[row];
                        int daysLeft = GetDaysLeft(dataRow);
                        string type = dataRow["Type"].ToString();
                        string daysLabel = GetDaysUntilExpiryLabel(daysLeft);
                        string offer = GetOfferSuggestion(daysLeft);

                        // Row color based on urgency
                        XLColor rowColor = XLColor.NoColor;
                        if (daysLeft < 0) rowColor = XLColor.LightCoral;
                        else if (daysLeft <= 20) rowColor = XLColor.OrangeRed;
                        else if (daysLeft <= 150) rowColor = XLColor.LightYellow;
                        
                            for (int col = 0; col < totalCols; col++)
                            {
                                var cellValue = dataRow[col];
                                var cell = sheet.Cell(row + 2, col + 1);
                                cell.Value = (cellValue == DBNull.Value || cellValue == null)
                                    ? "" : cellValue.ToString();
                                if (rowColor != XLColor.NoColor)
                                    cell.Style.Fill.BackgroundColor = rowColor;
                            }

                        // A new cell for days until expiry
                        var daysCell = sheet.Cell(row + 2, totalCols + 1);
                        daysCell.Value = daysLabel;
                        daysCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        if (rowColor != XLColor.NoColor)
                            daysCell.Style.Fill.BackgroundColor = rowColor;

                        // A new cell for suggested Offers
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
                //after finishing the loops shows a window for confirmation of saving an excel
                var open = MessageBox.Show(
                    "Report saved!\nOpen it now?",
                    "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (open == DialogResult.Yes) //opens the file if user clicked Yes
                    System.Diagnostics.Process.Start(saveDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating report: " + ex.Message);
            }
        }

        // Functions that helps in calculating everything about the products
        private int GetDaysLeft(DataRow row)
        {
            DateTime production = Convert.ToDateTime(row["ProductionDate"]);
            DateTime expiry = Convert.ToDateTime(row["ExpirationDate"]);

            // Get today's date
            DateTime today = DateTime.Today;

            // Check if the expiry date is before today → meaning it is already expired
            if (expiry.Date < today)
            {
                return -1; // Return -1 as a signal that the product is expired
            }

            // If not expired, return the days left from today until expiry
            return (expiry.Date - today).Days;
        }

        private string GetDaysUntilExpiryLabel(int daysLeft)
        {
            if (daysLeft < 0) return "Expired";
            if (daysLeft == 0) return "Expires Today!";
            return daysLeft + " days left";
        }

        private string GetOfferSuggestion(int daysLeft)
        {
            if (daysLeft < 0) return "Remove from shelf";
            if (daysLeft <= 50) return "Apply 40% discount";
            if (daysLeft <= 20) return "Apply 20% discount";
            return "No offer";
        }
            //header of the first column in the excel sheet
        private void StyleHeader(IXLCell cell)
        {
            cell.Style.Font.Bold = true;
            cell.Style.Fill.BackgroundColor = XLColor.DarkBlue;
            cell.Style.Font.FontColor = XLColor.White;
            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        
            // حدد رقم العمود الخاص بالتاريخ (مثلاً لو هو العمود رقم 2)
            if (dataGridView1.Columns[e.ColumnIndex].Name == "DateColumnName")
            {
                string input = e.FormattedValue.ToString();
                DateTime tempDate;

                // بنجرب نحول النص اللي دخله المستخدم لتاريخ
                if (!string.IsNullOrEmpty(input) && !DateTime.TryParse(input, out tempDate))
                {
                    // لو فشل التحويل، بنظهر الرسالة ونمنع الخروج من الخلية
                    MessageBox.Show("please enter a valid date (e.g., 2024-05-02)", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Cancel = true; // ده بيجبر المستخدم يفضل في الخلية لحد ما يعدلها
                }
            }
        }
    }
    
}