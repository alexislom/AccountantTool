namespace AccountantTool.Controls
{
    partial class ContractControl
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
            this.OkContractBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ContractsListView = new AccountantTool.Helpers.EditableListView();
            this.NumberOfContractColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOfStartColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SidesOfContractColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOfEndColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConditionsOfContractColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StageOfContractColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemoveContractBtn = new System.Windows.Forms.Button();
            this.AddContractBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkContractBtn
            // 
            this.OkContractBtn.Location = new System.Drawing.Point(570, 328);
            this.OkContractBtn.Name = "OkContractBtn";
            this.OkContractBtn.Size = new System.Drawing.Size(75, 40);
            this.OkContractBtn.TabIndex = 2;
            this.OkContractBtn.Text = "Ok";
            this.OkContractBtn.UseVisualStyleBackColor = true;
            this.OkContractBtn.Click += new System.EventHandler(this.OkContractBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ContractsListView);
            this.groupBox1.Location = new System.Drawing.Point(13, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 307);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Контракты";
            // 
            // ContractsListView
            // 
            this.ContractsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NumberOfContractColumnHeader,
            this.DateOfStartColumnHeader,
            this.SidesOfContractColumnHeader,
            this.DateOfEndColumnHeader,
            this.ConditionsOfContractColumnHeader,
            this.StageOfContractColumnHeader});
            this.ContractsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContractsListView.FullRowSelect = true;
            this.ContractsListView.GridLines = true;
            this.ContractsListView.Location = new System.Drawing.Point(3, 16);
            this.ContractsListView.Name = "ContractsListView";
            this.ContractsListView.Size = new System.Drawing.Size(654, 288);
            this.ContractsListView.TabIndex = 1;
            this.ContractsListView.UseCompatibleStateImageBehavior = false;
            this.ContractsListView.View = System.Windows.Forms.View.Details;
            // 
            // NumberOfContractColumnHeader
            // 
            this.NumberOfContractColumnHeader.Text = "Номер контракта";
            this.NumberOfContractColumnHeader.Width = 103;
            // 
            // DateOfStartColumnHeader
            // 
            this.DateOfStartColumnHeader.Text = "Дата заключения";
            this.DateOfStartColumnHeader.Width = 104;
            // 
            // SidesOfContractColumnHeader
            // 
            this.SidesOfContractColumnHeader.Text = "Стороны контракта";
            this.SidesOfContractColumnHeader.Width = 115;
            // 
            // DateOfEndColumnHeader
            // 
            this.DateOfEndColumnHeader.Text = "Срок исполнения";
            this.DateOfEndColumnHeader.Width = 101;
            // 
            // ConditionsOfContractColumnHeader
            // 
            this.ConditionsOfContractColumnHeader.Text = "Условия поставки";
            this.ConditionsOfContractColumnHeader.Width = 155;
            // 
            // StageOfContractColumnHeader
            // 
            this.StageOfContractColumnHeader.Text = "Статус";
            this.StageOfContractColumnHeader.Width = 67;
            // 
            // RemoveContractBtn
            // 
            this.RemoveContractBtn.Location = new System.Drawing.Point(187, 328);
            this.RemoveContractBtn.Name = "RemoveContractBtn";
            this.RemoveContractBtn.Size = new System.Drawing.Size(75, 40);
            this.RemoveContractBtn.TabIndex = 4;
            this.RemoveContractBtn.Text = "Удалить контракт";
            this.RemoveContractBtn.UseVisualStyleBackColor = true;
            this.RemoveContractBtn.Click += new System.EventHandler(this.RemoveContractBtn_Click);
            // 
            // AddContractBtn
            // 
            this.AddContractBtn.Location = new System.Drawing.Point(38, 328);
            this.AddContractBtn.Name = "AddContractBtn";
            this.AddContractBtn.Size = new System.Drawing.Size(75, 40);
            this.AddContractBtn.TabIndex = 5;
            this.AddContractBtn.Text = "Добавить контракт";
            this.AddContractBtn.UseVisualStyleBackColor = true;
            this.AddContractBtn.Click += new System.EventHandler(this.AddContractBtn_Click);
            // 
            // ContractControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddContractBtn);
            this.Controls.Add(this.RemoveContractBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OkContractBtn);
            this.Name = "ContractControl";
            this.Size = new System.Drawing.Size(692, 376);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OkContractBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private Helpers.EditableListView ContractsListView;
        private System.Windows.Forms.ColumnHeader NumberOfContractColumnHeader;
        private System.Windows.Forms.ColumnHeader DateOfStartColumnHeader;
        private System.Windows.Forms.ColumnHeader DateOfEndColumnHeader;
        private System.Windows.Forms.ColumnHeader ConditionsOfContractColumnHeader;
        private System.Windows.Forms.ColumnHeader SidesOfContractColumnHeader;
        private System.Windows.Forms.ColumnHeader StageOfContractColumnHeader;
        private System.Windows.Forms.Button RemoveContractBtn;
        private System.Windows.Forms.Button AddContractBtn;
    }
}
