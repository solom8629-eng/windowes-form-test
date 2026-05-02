using System;
using System.Windows.Forms;
using System.Drawing;

namespace windowes_form_test
{
    public class AddProductForm : Form
    {
        private Label lblTitle, lblID, lblName, lblQty, lblPrice, lblType, lblExpiry;
        private TextBox txtID, txtName, txtQty, txtPrice;
        private RadioButton rbPerishable, rbNonPerishable;
        private DateTimePicker dtpExpiry;
        private Button btnSave, btnCancel;

        private Inventory inventory;

        public AddProductForm(Inventory inventory)
        {
            this.inventory = inventory;
            BuildForm();
        }

        private void BuildForm()
        {
            this.Text = "Add New Product";
            this.Size = new Size(380, 430);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblTitle = new Label();
            lblTitle.Text = "Add New Product";
            lblTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Size = new Size(300, 30);

            lblID = MakeLabel("Product ID:", new System.Drawing.Point(20, 60));
            txtID = MakeTextBox(new System.Drawing.Point(160, 57));

            lblName = MakeLabel("Name:", new System.Drawing.Point(20, 100));
            txtName = MakeTextBox(new System.Drawing.Point(160, 97));

            lblQty = MakeLabel("Quantity:", new System.Drawing.Point(20, 140));
            txtQty = MakeTextBox(new System.Drawing.Point(160, 137));

            lblPrice = MakeLabel("Price:", new System.Drawing.Point(20, 180));
            txtPrice = MakeTextBox(new System.Drawing.Point(160, 177));

            lblType = MakeLabel("Type:", new System.Drawing.Point(20, 220));
            rbPerishable = new RadioButton();
            rbPerishable.Text = "Perishable";
            rbPerishable.Location = new System.Drawing.Point(160, 218);
            rbPerishable.Size = new Size(110, 25);
            rbPerishable.Checked = true;
            rbPerishable.CheckedChanged += (s, e) => dtpExpiry.Enabled = rbPerishable.Checked;

            rbNonPerishable = new RadioButton();
            rbNonPerishable.Text = "Non-Perishable";
            rbNonPerishable.Location = new System.Drawing.Point(160, 243);
            rbNonPerishable.Size = new Size(130, 25);

            lblExpiry = MakeLabel("Expiry Date:", new System.Drawing.Point(20, 283));
            dtpExpiry = new DateTimePicker();
            dtpExpiry.Location = new System.Drawing.Point(160, 280);
            dtpExpiry.Size = new Size(170, 25);
            dtpExpiry.Format = DateTimePickerFormat.Short;

            btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new System.Drawing.Point(70, 345);
            btnSave.Size = new Size(100, 35);
            btnSave.BackColor = Color.SeaGreen;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new System.Drawing.Point(195, 345);
            btnCancel.Size = new Size(100, 35);
            btnCancel.BackColor = Color.Crimson;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblTitle,
                lblID,    txtID,
                lblName,  txtName,
                lblQty,   txtQty,
                lblPrice, txtPrice,
                lblType,  rbPerishable, rbNonPerishable,
                lblExpiry, dtpExpiry,
                btnSave,  btnCancel
            });
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtQty.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQty.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("Quantity must be a positive whole number.", "Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtPrice.Text, out double price) || price < 0)
            {
                MessageBox.Show("Price must be a positive number.", "Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtID.Text.Trim();
            string name = txtName.Text.Trim();

            if (rbPerishable.Checked)
                inventory.AddProduct(new PerishableProduct(id, name, qty, price, dtpExpiry.Value));
            else
                inventory.AddProduct(new NonPerishableProduct(id, name, qty, price));

            MessageBox.Show("Product added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private Label MakeLabel(string text, System.Drawing.Point loc)
        {
            Label l = new Label();
            l.Text = text;
            l.Location = loc;
            l.Size = new Size(130, 25);
            l.Font = new Font("Segoe UI", 10);
            l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            return l;
        }

        private TextBox MakeTextBox(System.Drawing.Point loc)
        {
            TextBox t = new TextBox();
            t.Location = loc;
            t.Size = new Size(170, 25);
            t.Font = new Font("Segoe UI", 10);
            return t;
        }
    }
}