namespace windowes_form_test
{
    partial class Form_Show_data_
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Show_data_));
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shelfLifeDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripButton1_Click = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Width = 125;
            // 
            // productionDateDataGridViewTextBoxColumn
            // 
            this.productionDateDataGridViewTextBoxColumn.DataPropertyName = "ProductionDate";
            this.productionDateDataGridViewTextBoxColumn.HeaderText = "ProductionDate";
            this.productionDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productionDateDataGridViewTextBoxColumn.Name = "productionDateDataGridViewTextBoxColumn";
            this.productionDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // shelfLifeDaysDataGridViewTextBoxColumn
            // 
            this.shelfLifeDaysDataGridViewTextBoxColumn.DataPropertyName = "ShelfLifeDays";
            this.shelfLifeDaysDataGridViewTextBoxColumn.HeaderText = "ShelfLifeDays";
            this.shelfLifeDaysDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.shelfLifeDaysDataGridViewTextBoxColumn.Name = "shelfLifeDaysDataGridViewTextBoxColumn";
            this.shelfLifeDaysDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.productsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(116, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(701, 568);
            this.dataGridView1.TabIndex = 5;
            // 
            // productsBindingSource1
            // 
            this.productsBindingSource1.DataMember = "Products";
            // 
            // toolStripButton1_Click
            // 
            this.toolStripButton1_Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1_Click.Location = new System.Drawing.Point(908, 246);
            this.toolStripButton1_Click.Name = "toolStripButton1_Click";
            this.toolStripButton1_Click.Size = new System.Drawing.Size(198, 54);
            this.toolStripButton1_Click.TabIndex = 6;
            this.toolStripButton1_Click.Text = "Save update";
            this.toolStripButton1_Click.UseVisualStyleBackColor = true;
            this.toolStripButton1_Click.Click += new System.EventHandler(this.Save_button);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(908, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 56);
            this.button1.TabIndex = 7;
            this.button1.Text = "Show Reports";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form_Show_data_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1273, 766);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStripButton1_Click);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_Show_data_";
            this.Text = "Data";
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource productsBindingSource;
        
        private System.Windows.Forms.BindingSource productsBindingSource1;
        
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shelfLifeDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button toolStripButton1_Click;
        
        private System.Windows.Forms.Button button1;
    }
}