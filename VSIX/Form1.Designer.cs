
namespace PlatformCodeBuilder
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isNullDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.describeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.chkManager = new System.Windows.Forms.CheckBox();
            this.chkApplication = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNameDataGridViewTextBoxColumn,
            this.dateTypeDataGridViewTextBoxColumn,
            this.lengthDataGridViewTextBoxColumn,
            this.isNullDataGridViewCheckBoxColumn,
            this.describeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.entityModelBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(8, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(945, 377);
            this.dataGridView1.TabIndex = 1;
            // 
            // colNameDataGridViewTextBoxColumn
            // 
            this.colNameDataGridViewTextBoxColumn.DataPropertyName = "ColName";
            this.colNameDataGridViewTextBoxColumn.HeaderText = "字段名";
            this.colNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.colNameDataGridViewTextBoxColumn.Name = "colNameDataGridViewTextBoxColumn";
            this.colNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateTypeDataGridViewTextBoxColumn
            // 
            this.dateTypeDataGridViewTextBoxColumn.DataPropertyName = "DateType";
            this.dateTypeDataGridViewTextBoxColumn.HeaderText = "数据类型";
            this.dateTypeDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "string",
            "long",
            "int",
            "decimal",
            "double",
            "DateTime",
            "bool"});
            this.dateTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateTypeDataGridViewTextBoxColumn.Name = "dateTypeDataGridViewTextBoxColumn";
            this.dateTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dateTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dateTypeDataGridViewTextBoxColumn.Width = 125;
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "精度";
            this.lengthDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            this.lengthDataGridViewTextBoxColumn.Width = 125;
            // 
            // isNullDataGridViewCheckBoxColumn
            // 
            this.isNullDataGridViewCheckBoxColumn.DataPropertyName = "IsNull";
            this.isNullDataGridViewCheckBoxColumn.HeaderText = "是否为空";
            this.isNullDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.isNullDataGridViewCheckBoxColumn.Name = "isNullDataGridViewCheckBoxColumn";
            this.isNullDataGridViewCheckBoxColumn.Width = 125;
            // 
            // describeDataGridViewTextBoxColumn
            // 
            this.describeDataGridViewTextBoxColumn.DataPropertyName = "Describe";
            this.describeDataGridViewTextBoxColumn.HeaderText = "描述";
            this.describeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.describeDataGridViewTextBoxColumn.Name = "describeDataGridViewTextBoxColumn";
            this.describeDataGridViewTextBoxColumn.Width = 125;
            // 
            // entityModelBindingSource
            // 
            this.entityModelBindingSource.DataSource = typeof(PlatformCodeBuilder.Models.EntityModel);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(480, 430);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 397);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 25);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "表名";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(364, 397);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(191, 25);
            this.textBox3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Entity名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "描述";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(684, 397);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(266, 25);
            this.textBox4.TabIndex = 5;
            // 
            // chkManager
            // 
            this.chkManager.AutoSize = true;
            this.chkManager.Checked = true;
            this.chkManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManager.Location = new System.Drawing.Point(129, 441);
            this.chkManager.Name = "chkManager";
            this.chkManager.Size = new System.Drawing.Size(115, 19);
            this.chkManager.TabIndex = 13;
            this.chkManager.Text = "生成Manager";
            this.chkManager.UseVisualStyleBackColor = true;
            // 
            // chkApplication
            // 
            this.chkApplication.AutoSize = true;
            this.chkApplication.Checked = true;
            this.chkApplication.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApplication.Location = new System.Drawing.Point(275, 441);
            this.chkApplication.Name = "chkApplication";
            this.chkApplication.Size = new System.Drawing.Size(147, 19);
            this.chkApplication.TabIndex = 14;
            this.chkApplication.Text = "生成Application";
            this.chkApplication.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 471);
            this.Controls.Add(this.chkApplication);
            this.Controls.Add(this.chkManager);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码生成器";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource entityModelBindingSource;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dateTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isNullDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn describeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox chkManager;
        private System.Windows.Forms.CheckBox chkApplication;
    }
}