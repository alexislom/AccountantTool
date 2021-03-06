﻿namespace AccountantTool.Controls
{
    partial class CompanyControl
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
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CompanyGroupBox = new System.Windows.Forms.GroupBox();
            this.OkCompanyBtn = new System.Windows.Forms.Button();
            this.CompanyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(168, 20);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(227, 20);
            this.txtFullName.TabIndex = 0;
            // 
            // txtShortName
            // 
            this.txtShortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortName.Location = new System.Drawing.Point(168, 53);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(227, 20);
            this.txtShortName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Полное название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сокращённое название:";
            // 
            // CompanyGroupBox
            // 
            this.CompanyGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyGroupBox.Controls.Add(this.label1);
            this.CompanyGroupBox.Controls.Add(this.txtShortName);
            this.CompanyGroupBox.Controls.Add(this.label2);
            this.CompanyGroupBox.Controls.Add(this.txtFullName);
            this.CompanyGroupBox.Location = new System.Drawing.Point(3, 3);
            this.CompanyGroupBox.Name = "CompanyGroupBox";
            this.CompanyGroupBox.Size = new System.Drawing.Size(428, 90);
            this.CompanyGroupBox.TabIndex = 4;
            this.CompanyGroupBox.TabStop = false;
            this.CompanyGroupBox.Text = "Название компании";
            // 
            // OkCompanyBtn
            // 
            this.OkCompanyBtn.Location = new System.Drawing.Point(356, 97);
            this.OkCompanyBtn.Name = "OkCompanyBtn";
            this.OkCompanyBtn.Size = new System.Drawing.Size(75, 31);
            this.OkCompanyBtn.TabIndex = 5;
            this.OkCompanyBtn.Text = "Ok";
            this.OkCompanyBtn.UseVisualStyleBackColor = true;
            this.OkCompanyBtn.Click += new System.EventHandler(this.OkCompanyBtn_Click);
            // 
            // CompanyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OkCompanyBtn);
            this.Controls.Add(this.CompanyGroupBox);
            this.Name = "CompanyControl";
            this.Size = new System.Drawing.Size(450, 131);
            this.CompanyGroupBox.ResumeLayout(false);
            this.CompanyGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox CompanyGroupBox;
        private System.Windows.Forms.Button OkCompanyBtn;
    }
}
