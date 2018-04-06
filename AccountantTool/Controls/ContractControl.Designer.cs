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
            this.ContractGroupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textContractStage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textSidesOfContract = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textNumberOfContract = new System.Windows.Forms.TextBox();
            this.OkContractBtn = new System.Windows.Forms.Button();
            this.dateOfConctract = new System.Windows.Forms.DateTimePicker();
            this.dateOfEnd = new System.Windows.Forms.DateTimePicker();
            this.ContractGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContractGroupBox
            // 
            this.ContractGroupBox.Controls.Add(this.dateOfEnd);
            this.ContractGroupBox.Controls.Add(this.dateOfConctract);
            this.ContractGroupBox.Controls.Add(this.label8);
            this.ContractGroupBox.Controls.Add(this.textContractStage);
            this.ContractGroupBox.Controls.Add(this.label7);
            this.ContractGroupBox.Controls.Add(this.label3);
            this.ContractGroupBox.Controls.Add(this.textSidesOfContract);
            this.ContractGroupBox.Controls.Add(this.label2);
            this.ContractGroupBox.Controls.Add(this.label1);
            this.ContractGroupBox.Controls.Add(this.textNumberOfContract);
            this.ContractGroupBox.Location = new System.Drawing.Point(14, 12);
            this.ContractGroupBox.Name = "ContractGroupBox";
            this.ContractGroupBox.Size = new System.Drawing.Size(381, 208);
            this.ContractGroupBox.TabIndex = 1;
            this.ContractGroupBox.TabStop = false;
            this.ContractGroupBox.Text = "Исполнение контракта";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Статус исполнения";
            // 
            // textContractStage
            // 
            this.textContractStage.Location = new System.Drawing.Point(151, 153);
            this.textContractStage.Name = "textContractStage";
            this.textContractStage.Size = new System.Drawing.Size(213, 20);
            this.textContractStage.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Срок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Стороны контракта";
            // 
            // textSidesOfContract
            // 
            this.textSidesOfContract.Location = new System.Drawing.Point(151, 85);
            this.textSidesOfContract.Name = "textSidesOfContract";
            this.textSidesOfContract.Size = new System.Drawing.Size(213, 20);
            this.textSidesOfContract.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата контракта";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер контракта";
            // 
            // textNumberOfContract
            // 
            this.textNumberOfContract.Location = new System.Drawing.Point(151, 29);
            this.textNumberOfContract.Name = "textNumberOfContract";
            this.textNumberOfContract.Size = new System.Drawing.Size(213, 20);
            this.textNumberOfContract.TabIndex = 0;
            // 
            // OkContractBtn
            // 
            this.OkContractBtn.Location = new System.Drawing.Point(303, 226);
            this.OkContractBtn.Name = "OkContractBtn";
            this.OkContractBtn.Size = new System.Drawing.Size(75, 23);
            this.OkContractBtn.TabIndex = 2;
            this.OkContractBtn.Text = "Ok";
            this.OkContractBtn.UseVisualStyleBackColor = true;
            this.OkContractBtn.Click += new System.EventHandler(this.OkContractBtn_Click);
            // 
            // dateOfConctract
            // 
            this.dateOfConctract.Location = new System.Drawing.Point(151, 56);
            this.dateOfConctract.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateOfConctract.Name = "dateOfConctract";
            this.dateOfConctract.Size = new System.Drawing.Size(213, 20);
            this.dateOfConctract.TabIndex = 17;
            this.dateOfConctract.Value = new System.DateTime(2018, 4, 6, 12, 0, 29, 0);
            // 
            // dateOfEnd
            // 
            this.dateOfEnd.Location = new System.Drawing.Point(151, 119);
            this.dateOfEnd.MinDate = new System.DateTime(2000, 1, 2, 0, 0, 0, 0);
            this.dateOfEnd.Name = "dateOfEnd";
            this.dateOfEnd.Size = new System.Drawing.Size(213, 20);
            this.dateOfEnd.TabIndex = 18;
            this.dateOfEnd.Value = new System.DateTime(2018, 4, 6, 12, 0, 41, 0);
            // 
            // ContractControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OkContractBtn);
            this.Controls.Add(this.ContractGroupBox);
            this.Name = "ContractControl";
            this.Size = new System.Drawing.Size(409, 259);
            this.ContractGroupBox.ResumeLayout(false);
            this.ContractGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ContractGroupBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textContractStage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textSidesOfContract;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNumberOfContract;
        private System.Windows.Forms.Button OkContractBtn;
        private System.Windows.Forms.DateTimePicker dateOfConctract;
        private System.Windows.Forms.DateTimePicker dateOfEnd;
    }
}
