using AccountantTool.Helpers;

namespace AccountantTool.Controls
{
    partial class RequisitesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RequisitesGroupBox = new System.Windows.Forms.GroupBox();
            this.textRequisitesStreet = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textRequisitesFlat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textRequisitesEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textRequisitesSite = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textRequisitesHouse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textRequisitesCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textRequisitesDistrict = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textRequisitesRegion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textRequisitesCountry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textRequisitesIndex = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddDepartmentBtn = new System.Windows.Forms.Button();
            this.RemoveDepartmentBtn = new System.Windows.Forms.Button();
            this.AddOtherRequisiteBtn = new System.Windows.Forms.Button();
            this.RemoveOtherRequisiteBtn = new System.Windows.Forms.Button();
            this.OkRequisitesBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DepartmentsListView = new AccountantTool.Helpers.EditableListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OtherRequisitesListView = new AccountantTool.Helpers.EditableListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RequisitesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RequisitesGroupBox
            // 
            this.RequisitesGroupBox.Controls.Add(this.textRequisitesStreet);
            this.RequisitesGroupBox.Controls.Add(this.label10);
            this.RequisitesGroupBox.Controls.Add(this.label9);
            this.RequisitesGroupBox.Controls.Add(this.textRequisitesFlat);
            this.RequisitesGroupBox.Controls.Add(this.label8);
            this.RequisitesGroupBox.Controls.Add(this.textRequisitesEmail);
            this.RequisitesGroupBox.Controls.Add(this.label7);
            this.RequisitesGroupBox.Controls.Add(this.textRequisitesSite);
            this.RequisitesGroupBox.Controls.Add(this.label6);
            this.RequisitesGroupBox.Controls.Add(this.textRequisitesHouse);
            this.RequisitesGroupBox.Controls.Add(this.label5);
            this.RequisitesGroupBox.Controls.Add(this.textRequisitesCity);
            this.RequisitesGroupBox.Controls.Add(this.label4);
            this.RequisitesGroupBox.Controls.Add(this.textRequisitesDistrict);
            this.RequisitesGroupBox.Controls.Add(this.label3);
            this.RequisitesGroupBox.Controls.Add(this.textRequisitesRegion);
            this.RequisitesGroupBox.Controls.Add(this.label2);
            this.RequisitesGroupBox.Controls.Add(this.textRequisitesCountry);
            this.RequisitesGroupBox.Controls.Add(this.label1);
            this.RequisitesGroupBox.Controls.Add(this.textRequisitesIndex);
            this.RequisitesGroupBox.Location = new System.Drawing.Point(16, 3);
            this.RequisitesGroupBox.Name = "RequisitesGroupBox";
            this.RequisitesGroupBox.Size = new System.Drawing.Size(599, 222);
            this.RequisitesGroupBox.TabIndex = 0;
            this.RequisitesGroupBox.TabStop = false;
            this.RequisitesGroupBox.Text = "Реквизиты";
            // 
            // textRequisitesStreet
            // 
            this.textRequisitesStreet.Location = new System.Drawing.Point(389, 56);
            this.textRequisitesStreet.Name = "textRequisitesStreet";
            this.textRequisitesStreet.Size = new System.Drawing.Size(185, 20);
            this.textRequisitesStreet.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(328, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Улица";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Помещение";
            // 
            // textRequisitesFlat
            // 
            this.textRequisitesFlat.Location = new System.Drawing.Point(389, 121);
            this.textRequisitesFlat.Name = "textRequisitesFlat";
            this.textRequisitesFlat.Size = new System.Drawing.Size(185, 20);
            this.textRequisitesFlat.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Адрес электронной почты";
            // 
            // textRequisitesEmail
            // 
            this.textRequisitesEmail.Location = new System.Drawing.Point(180, 186);
            this.textRequisitesEmail.Name = "textRequisitesEmail";
            this.textRequisitesEmail.Size = new System.Drawing.Size(241, 20);
            this.textRequisitesEmail.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Сайт комапании";
            // 
            // textRequisitesSite
            // 
            this.textRequisitesSite.Location = new System.Drawing.Point(130, 121);
            this.textRequisitesSite.Name = "textRequisitesSite";
            this.textRequisitesSite.Size = new System.Drawing.Size(159, 20);
            this.textRequisitesSite.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Дом";
            // 
            // textRequisitesHouse
            // 
            this.textRequisitesHouse.Location = new System.Drawing.Point(389, 88);
            this.textRequisitesHouse.Name = "textRequisitesHouse";
            this.textRequisitesHouse.Size = new System.Drawing.Size(185, 20);
            this.textRequisitesHouse.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Город";
            // 
            // textRequisitesCity
            // 
            this.textRequisitesCity.Location = new System.Drawing.Point(389, 25);
            this.textRequisitesCity.Name = "textRequisitesCity";
            this.textRequisitesCity.Size = new System.Drawing.Size(185, 20);
            this.textRequisitesCity.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Район";
            // 
            // textRequisitesDistrict
            // 
            this.textRequisitesDistrict.Location = new System.Drawing.Point(130, 150);
            this.textRequisitesDistrict.Name = "textRequisitesDistrict";
            this.textRequisitesDistrict.Size = new System.Drawing.Size(159, 20);
            this.textRequisitesDistrict.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Область";
            // 
            // textRequisitesRegion
            // 
            this.textRequisitesRegion.Location = new System.Drawing.Point(130, 88);
            this.textRequisitesRegion.Name = "textRequisitesRegion";
            this.textRequisitesRegion.Size = new System.Drawing.Size(159, 20);
            this.textRequisitesRegion.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Страна";
            // 
            // textRequisitesCountry
            // 
            this.textRequisitesCountry.Location = new System.Drawing.Point(130, 56);
            this.textRequisitesCountry.Name = "textRequisitesCountry";
            this.textRequisitesCountry.Size = new System.Drawing.Size(159, 20);
            this.textRequisitesCountry.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Индекс";
            // 
            // textRequisitesIndex
            // 
            this.textRequisitesIndex.Location = new System.Drawing.Point(130, 25);
            this.textRequisitesIndex.Name = "textRequisitesIndex";
            this.textRequisitesIndex.Size = new System.Drawing.Size(159, 20);
            this.textRequisitesIndex.TabIndex = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Отдел";
            this.columnHeader1.Width = 92;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Телефон";
            this.columnHeader2.Width = 137;
            // 
            // AddDepartmentBtn
            // 
            this.AddDepartmentBtn.Location = new System.Drawing.Point(16, 421);
            this.AddDepartmentBtn.Name = "AddDepartmentBtn";
            this.AddDepartmentBtn.Size = new System.Drawing.Size(75, 41);
            this.AddDepartmentBtn.TabIndex = 3;
            this.AddDepartmentBtn.Text = "Добавить отдел";
            this.AddDepartmentBtn.UseVisualStyleBackColor = true;
            this.AddDepartmentBtn.Click += new System.EventHandler(this.AddDepartmentBtn_Click);
            // 
            // RemoveDepartmentBtn
            // 
            this.RemoveDepartmentBtn.Location = new System.Drawing.Point(108, 421);
            this.RemoveDepartmentBtn.Name = "RemoveDepartmentBtn";
            this.RemoveDepartmentBtn.Size = new System.Drawing.Size(75, 41);
            this.RemoveDepartmentBtn.TabIndex = 4;
            this.RemoveDepartmentBtn.Text = "Удалить отдел";
            this.RemoveDepartmentBtn.UseVisualStyleBackColor = true;
            this.RemoveDepartmentBtn.Click += new System.EventHandler(this.RemoveDepartmentBtn_Click);
            // 
            // AddOtherRequisiteBtn
            // 
            this.AddOtherRequisiteBtn.Location = new System.Drawing.Point(441, 419);
            this.AddOtherRequisiteBtn.Name = "AddOtherRequisiteBtn";
            this.AddOtherRequisiteBtn.Size = new System.Drawing.Size(75, 41);
            this.AddOtherRequisiteBtn.TabIndex = 5;
            this.AddOtherRequisiteBtn.Text = "Добавить реквизит";
            this.AddOtherRequisiteBtn.UseVisualStyleBackColor = true;
            this.AddOtherRequisiteBtn.Click += new System.EventHandler(this.AddOtherRequisiteBtn_Click);
            // 
            // RemoveOtherRequisiteBtn
            // 
            this.RemoveOtherRequisiteBtn.Location = new System.Drawing.Point(540, 419);
            this.RemoveOtherRequisiteBtn.Name = "RemoveOtherRequisiteBtn";
            this.RemoveOtherRequisiteBtn.Size = new System.Drawing.Size(75, 41);
            this.RemoveOtherRequisiteBtn.TabIndex = 6;
            this.RemoveOtherRequisiteBtn.Text = "Удалить реквизит";
            this.RemoveOtherRequisiteBtn.UseVisualStyleBackColor = true;
            this.RemoveOtherRequisiteBtn.Click += new System.EventHandler(this.RemoveOtherRequisiteBtn_Click);
            // 
            // OkRequisitesBtn
            // 
            this.OkRequisitesBtn.Location = new System.Drawing.Point(270, 422);
            this.OkRequisitesBtn.Name = "OkRequisitesBtn";
            this.OkRequisitesBtn.Size = new System.Drawing.Size(75, 38);
            this.OkRequisitesBtn.TabIndex = 7;
            this.OkRequisitesBtn.Text = "Ok";
            this.OkRequisitesBtn.UseVisualStyleBackColor = true;
            this.OkRequisitesBtn.Click += new System.EventHandler(this.OkRequisitesBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // DepartmentsListView
            // 
            this.DepartmentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.DepartmentsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentsListView.FullRowSelect = true;
            this.DepartmentsListView.GridLines = true;
            this.DepartmentsListView.Location = new System.Drawing.Point(16, 231);
            this.DepartmentsListView.Name = "DepartmentsListView";
            this.DepartmentsListView.Size = new System.Drawing.Size(272, 173);
            this.DepartmentsListView.TabIndex = 8;
            this.DepartmentsListView.UseCompatibleStateImageBehavior = false;
            this.DepartmentsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Отдел";
            this.columnHeader5.Width = 124;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Телефон";
            this.columnHeader6.Width = 140;
            // 
            // OtherRequisitesListView
            // 
            this.OtherRequisitesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.OtherRequisitesListView.FullRowSelect = true;
            this.OtherRequisitesListView.GridLines = true;
            this.OtherRequisitesListView.Location = new System.Drawing.Point(304, 231);
            this.OtherRequisitesListView.Name = "OtherRequisitesListView";
            this.OtherRequisitesListView.Size = new System.Drawing.Size(311, 173);
            this.OtherRequisitesListView.TabIndex = 2;
            this.OtherRequisitesListView.UseCompatibleStateImageBehavior = false;
            this.OtherRequisitesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Иной реквизит";
            this.columnHeader3.Width = 139;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Его значение";
            this.columnHeader4.Width = 167;
            // 
            // RequisitesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DepartmentsListView);
            this.Controls.Add(this.OkRequisitesBtn);
            this.Controls.Add(this.RemoveOtherRequisiteBtn);
            this.Controls.Add(this.AddOtherRequisiteBtn);
            this.Controls.Add(this.RemoveDepartmentBtn);
            this.Controls.Add(this.AddDepartmentBtn);
            this.Controls.Add(this.OtherRequisitesListView);
            this.Controls.Add(this.RequisitesGroupBox);
            this.Name = "RequisitesControl";
            this.Size = new System.Drawing.Size(632, 465);
            this.RequisitesGroupBox.ResumeLayout(false);
            this.RequisitesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RequisitesGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textRequisitesSite;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textRequisitesHouse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textRequisitesCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textRequisitesDistrict;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textRequisitesRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRequisitesCountry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textRequisitesIndex;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textRequisitesEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textRequisitesFlat;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button AddDepartmentBtn;
        private System.Windows.Forms.Button RemoveDepartmentBtn;
        private System.Windows.Forms.Button AddOtherRequisiteBtn;
        private System.Windows.Forms.Button RemoveOtherRequisiteBtn;
        private System.Windows.Forms.Button OkRequisitesBtn;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private EditableListView DepartmentsListView;
        private EditableListView OtherRequisitesListView;
        private System.Windows.Forms.TextBox textRequisitesStreet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
