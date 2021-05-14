
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
            this.dateTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isNullDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.describeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isFilterDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isShowInListDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCreateOrEditDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isRequiredDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.entityModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.chkBuildAngular = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkApplication = new System.Windows.Forms.CheckBox();
            this.chkManager = new System.Windows.Forms.CheckBox();
            this.chkBuildService = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkIsRequired = new System.Windows.Forms.CheckBox();
            this.chkIsEdit = new System.Windows.Forms.CheckBox();
            this.chkIsList = new System.Windows.Forms.CheckBox();
            this.chkIsFilter = new System.Windows.Forms.CheckBox();
            this.chkIsNull = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLenght = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityModelBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNameDataGridViewTextBoxColumn,
            this.dateTypeDataGridViewTextBoxColumn,
            this.lengthDataGridViewTextBoxColumn,
            this.isNullDataGridViewCheckBoxColumn,
            this.describeDataGridViewTextBoxColumn,
            this.isFilterDataGridViewCheckBoxColumn,
            this.isShowInListDataGridViewCheckBoxColumn,
            this.isCreateOrEditDataGridViewCheckBoxColumn,
            this.isRequiredDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.entityModelBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(943, 294);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colNameDataGridViewTextBoxColumn
            // 
            this.colNameDataGridViewTextBoxColumn.DataPropertyName = "ColName";
            this.colNameDataGridViewTextBoxColumn.HeaderText = "字段名";
            this.colNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.colNameDataGridViewTextBoxColumn.Name = "colNameDataGridViewTextBoxColumn";
            this.colNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.colNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateTypeDataGridViewTextBoxColumn
            // 
            this.dateTypeDataGridViewTextBoxColumn.DataPropertyName = "DateType";
            this.dateTypeDataGridViewTextBoxColumn.HeaderText = "数据类型";
            this.dateTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateTypeDataGridViewTextBoxColumn.Name = "dateTypeDataGridViewTextBoxColumn";
            this.dateTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateTypeDataGridViewTextBoxColumn.Width = 125;
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "字段长度";
            this.lengthDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            this.lengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.lengthDataGridViewTextBoxColumn.Width = 125;
            // 
            // isNullDataGridViewCheckBoxColumn
            // 
            this.isNullDataGridViewCheckBoxColumn.DataPropertyName = "IsNull";
            this.isNullDataGridViewCheckBoxColumn.HeaderText = "是否为空";
            this.isNullDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.isNullDataGridViewCheckBoxColumn.Name = "isNullDataGridViewCheckBoxColumn";
            this.isNullDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isNullDataGridViewCheckBoxColumn.Width = 125;
            // 
            // describeDataGridViewTextBoxColumn
            // 
            this.describeDataGridViewTextBoxColumn.DataPropertyName = "Describe";
            this.describeDataGridViewTextBoxColumn.HeaderText = "描述";
            this.describeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.describeDataGridViewTextBoxColumn.Name = "describeDataGridViewTextBoxColumn";
            this.describeDataGridViewTextBoxColumn.ReadOnly = true;
            this.describeDataGridViewTextBoxColumn.Width = 125;
            // 
            // isFilterDataGridViewCheckBoxColumn
            // 
            this.isFilterDataGridViewCheckBoxColumn.DataPropertyName = "IsFilter";
            this.isFilterDataGridViewCheckBoxColumn.HeaderText = "是否筛选";
            this.isFilterDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.isFilterDataGridViewCheckBoxColumn.Name = "isFilterDataGridViewCheckBoxColumn";
            this.isFilterDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isFilterDataGridViewCheckBoxColumn.Width = 125;
            // 
            // isShowInListDataGridViewCheckBoxColumn
            // 
            this.isShowInListDataGridViewCheckBoxColumn.DataPropertyName = "IsShowInList";
            this.isShowInListDataGridViewCheckBoxColumn.HeaderText = "是否列表";
            this.isShowInListDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.isShowInListDataGridViewCheckBoxColumn.Name = "isShowInListDataGridViewCheckBoxColumn";
            this.isShowInListDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isShowInListDataGridViewCheckBoxColumn.Width = 125;
            // 
            // isCreateOrEditDataGridViewCheckBoxColumn
            // 
            this.isCreateOrEditDataGridViewCheckBoxColumn.DataPropertyName = "IsCreateOrEdit";
            this.isCreateOrEditDataGridViewCheckBoxColumn.HeaderText = "是否编辑";
            this.isCreateOrEditDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.isCreateOrEditDataGridViewCheckBoxColumn.Name = "isCreateOrEditDataGridViewCheckBoxColumn";
            this.isCreateOrEditDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isCreateOrEditDataGridViewCheckBoxColumn.Width = 125;
            // 
            // isRequiredDataGridViewCheckBoxColumn
            // 
            this.isRequiredDataGridViewCheckBoxColumn.DataPropertyName = "IsRequired";
            this.isRequiredDataGridViewCheckBoxColumn.HeaderText = "是否必填";
            this.isRequiredDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.isRequiredDataGridViewCheckBoxColumn.Name = "isRequiredDataGridViewCheckBoxColumn";
            this.isRequiredDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isRequiredDataGridViewCheckBoxColumn.Width = 125;
            // 
            // entityModelBindingSource
            // 
            this.entityModelBindingSource.DataSource = typeof(PlatformCodeBuilder.Models.EntityModel);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(965, 471);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(957, 442);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtOutPath);
            this.groupBox2.Controls.Add(this.chkBuildAngular);
            this.groupBox2.Location = new System.Drawing.Point(262, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 119);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Angular";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 28);
            this.button1.TabIndex = 26;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtOutPath
            // 
            this.txtOutPath.Location = new System.Drawing.Point(21, 69);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.ReadOnly = true;
            this.txtOutPath.Size = new System.Drawing.Size(238, 25);
            this.txtOutPath.TabIndex = 26;
            // 
            // chkBuildAngular
            // 
            this.chkBuildAngular.AutoSize = true;
            this.chkBuildAngular.Checked = true;
            this.chkBuildAngular.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBuildAngular.Location = new System.Drawing.Point(21, 24);
            this.chkBuildAngular.Name = "chkBuildAngular";
            this.chkBuildAngular.Size = new System.Drawing.Size(59, 19);
            this.chkBuildAngular.TabIndex = 25;
            this.chkBuildAngular.Text = "生成";
            this.chkBuildAngular.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkApplication);
            this.groupBox1.Controls.Add(this.chkManager);
            this.groupBox1.Controls.Add(this.chkBuildService);
            this.groupBox1.Location = new System.Drawing.Point(49, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 119);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "后端";
            // 
            // chkApplication
            // 
            this.chkApplication.AutoSize = true;
            this.chkApplication.Checked = true;
            this.chkApplication.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApplication.Location = new System.Drawing.Point(16, 85);
            this.chkApplication.Name = "chkApplication";
            this.chkApplication.Size = new System.Drawing.Size(147, 19);
            this.chkApplication.TabIndex = 23;
            this.chkApplication.Text = "生成Application";
            this.chkApplication.UseVisualStyleBackColor = true;
            // 
            // chkManager
            // 
            this.chkManager.AutoSize = true;
            this.chkManager.Checked = true;
            this.chkManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManager.Location = new System.Drawing.Point(16, 56);
            this.chkManager.Name = "chkManager";
            this.chkManager.Size = new System.Drawing.Size(115, 19);
            this.chkManager.TabIndex = 22;
            this.chkManager.Text = "生成Manager";
            this.chkManager.UseVisualStyleBackColor = true;
            // 
            // chkBuildService
            // 
            this.chkBuildService.AutoSize = true;
            this.chkBuildService.Checked = true;
            this.chkBuildService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBuildService.Location = new System.Drawing.Point(16, 24);
            this.chkBuildService.Name = "chkBuildService";
            this.chkBuildService.Size = new System.Drawing.Size(59, 19);
            this.chkBuildService.TabIndex = 24;
            this.chkBuildService.Text = "生成";
            this.chkBuildService.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "描述";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(119, 116);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(266, 25);
            this.textBox4.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Entity名";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(119, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(191, 25);
            this.textBox3.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "表名";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 25);
            this.textBox1.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(487, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 36);
            this.button2.TabIndex = 15;
            this.button2.Text = "生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDel);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.ddlType);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.chkIsRequired);
            this.tabPage2.Controls.Add(this.chkIsEdit);
            this.tabPage2.Controls.Add(this.chkIsList);
            this.tabPage2.Controls.Add(this.chkIsFilter);
            this.tabPage2.Controls.Add(this.chkIsNull);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtLenght);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtDescription);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtColName);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(957, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据属性";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(843, 397);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(84, 28);
            this.btnDel.TabIndex = 16;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "数据类型";
            // 
            // ddlType
            // 
            this.ddlType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityModelBindingSource, "DateType", true));
            this.ddlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Items.AddRange(new object[] {
            "string",
            "Guid",
            "long",
            "int",
            "decimal",
            "bool",
            "enum",
            "DateTime"});
            this.ddlType.Location = new System.Drawing.Point(365, 318);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(144, 23);
            this.ddlType.TabIndex = 14;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(843, 356);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 28);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkIsRequired
            // 
            this.chkIsRequired.AutoSize = true;
            this.chkIsRequired.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.entityModelBindingSource, "IsRequired", true));
            this.chkIsRequired.Location = new System.Drawing.Point(474, 403);
            this.chkIsRequired.Name = "chkIsRequired";
            this.chkIsRequired.Size = new System.Drawing.Size(104, 19);
            this.chkIsRequired.TabIndex = 12;
            this.chkIsRequired.Text = "编辑时必填";
            this.chkIsRequired.UseVisualStyleBackColor = true;
            // 
            // chkIsEdit
            // 
            this.chkIsEdit.AutoSize = true;
            this.chkIsEdit.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.entityModelBindingSource, "IsCreateOrEdit", true));
            this.chkIsEdit.Location = new System.Drawing.Point(339, 403);
            this.chkIsEdit.Name = "chkIsEdit";
            this.chkIsEdit.Size = new System.Drawing.Size(89, 19);
            this.chkIsEdit.TabIndex = 11;
            this.chkIsEdit.Text = "是否编辑";
            this.chkIsEdit.UseVisualStyleBackColor = true;
            // 
            // chkIsList
            // 
            this.chkIsList.AutoSize = true;
            this.chkIsList.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.entityModelBindingSource, "IsShowInList", true));
            this.chkIsList.Location = new System.Drawing.Point(208, 403);
            this.chkIsList.Name = "chkIsList";
            this.chkIsList.Size = new System.Drawing.Size(89, 19);
            this.chkIsList.TabIndex = 10;
            this.chkIsList.Text = "列表显示";
            this.chkIsList.UseVisualStyleBackColor = true;
            // 
            // chkIsFilter
            // 
            this.chkIsFilter.AutoSize = true;
            this.chkIsFilter.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.entityModelBindingSource, "IsFilter", true));
            this.chkIsFilter.Location = new System.Drawing.Point(78, 403);
            this.chkIsFilter.Name = "chkIsFilter";
            this.chkIsFilter.Size = new System.Drawing.Size(89, 19);
            this.chkIsFilter.TabIndex = 9;
            this.chkIsFilter.Text = "查询条件";
            this.chkIsFilter.UseVisualStyleBackColor = true;
            // 
            // chkIsNull
            // 
            this.chkIsNull.AutoSize = true;
            this.chkIsNull.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.entityModelBindingSource, "IsNull", true));
            this.chkIsNull.Location = new System.Drawing.Point(581, 362);
            this.chkIsNull.Name = "chkIsNull";
            this.chkIsNull.Size = new System.Drawing.Size(74, 19);
            this.chkIsNull.TabIndex = 8;
            this.chkIsNull.Text = "可为空";
            this.chkIsNull.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(578, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "字段长度";
            // 
            // txtLenght
            // 
            this.txtLenght.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityModelBindingSource, "Length", true));
            this.txtLenght.Location = new System.Drawing.Point(651, 318);
            this.txtLenght.Name = "txtLenght";
            this.txtLenght.Size = new System.Drawing.Size(139, 25);
            this.txtLenght.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "描述";
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityModelBindingSource, "Describe", true));
            this.txtDescription.Location = new System.Drawing.Point(78, 360);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(427, 25);
            this.txtDescription.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "字段名";
            // 
            // txtColName
            // 
            this.txtColName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.entityModelBindingSource, "ColName", true));
            this.txtColName.Location = new System.Drawing.Point(78, 318);
            this.txtColName.Name = "txtColName";
            this.txtColName.Size = new System.Drawing.Size(168, 25);
            this.txtColName.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 471);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码生成器";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityModelBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.CheckBox chkBuildAngular;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkApplication;
        private System.Windows.Forms.CheckBox chkManager;
        private System.Windows.Forms.CheckBox chkBuildService;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isNullDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn describeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isFilterDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isShowInListDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCreateOrEditDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isRequiredDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource entityModelBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkIsRequired;
        private System.Windows.Forms.CheckBox chkIsEdit;
        private System.Windows.Forms.CheckBox chkIsList;
        private System.Windows.Forms.CheckBox chkIsFilter;
        private System.Windows.Forms.CheckBox chkIsNull;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLenght;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtColName;
        private System.Windows.Forms.Button btnDel;
    }
}