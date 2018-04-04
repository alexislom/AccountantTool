namespace AccountantTool.Controls
{
    partial class AdditionalInfoControl
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
            this.AddInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.OkAddInfoBtn = new System.Windows.Forms.Button();
            this.AddInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddInfoGroupBox
            // 
            this.AddInfoGroupBox.Controls.Add(this.label1);
            this.AddInfoGroupBox.Controls.Add(this.txtNotes);
            this.AddInfoGroupBox.Location = new System.Drawing.Point(13, 15);
            this.AddInfoGroupBox.Name = "AddInfoGroupBox";
            this.AddInfoGroupBox.Size = new System.Drawing.Size(410, 71);
            this.AddInfoGroupBox.TabIndex = 5;
            this.AddInfoGroupBox.TabStop = false;
            this.AddInfoGroupBox.Text = "Дополнительная информация";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Примечания";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(156, 27);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(216, 20);
            this.txtNotes.TabIndex = 0;
            // 
            // OkAddInfoBtn
            // 
            this.OkAddInfoBtn.Location = new System.Drawing.Point(348, 92);
            this.OkAddInfoBtn.Name = "OkAddInfoBtn";
            this.OkAddInfoBtn.Size = new System.Drawing.Size(75, 25);
            this.OkAddInfoBtn.TabIndex = 6;
            this.OkAddInfoBtn.Text = "Ok";
            this.OkAddInfoBtn.UseVisualStyleBackColor = true;
            this.OkAddInfoBtn.Click += new System.EventHandler(this.OkAddInfoBtn_Click);
            // 
            // AdditionalInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OkAddInfoBtn);
            this.Controls.Add(this.AddInfoGroupBox);
            this.Name = "AdditionalInfoControl";
            this.Size = new System.Drawing.Size(437, 125);
            this.AddInfoGroupBox.ResumeLayout(false);
            this.AddInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AddInfoGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button OkAddInfoBtn;
    }
}
