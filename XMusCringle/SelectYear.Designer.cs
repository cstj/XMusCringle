namespace XMusCringle
{
    partial class SelectYear
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
            this.butOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.comboYear = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(12, 51);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(54, 20);
            this.butOK.TabIndex = 1;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Year For Cringle";
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(72, 51);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(54, 20);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // comboYear
            // 
            this.comboYear.FormattingEnabled = true;
            this.comboYear.Location = new System.Drawing.Point(12, 25);
            this.comboYear.Name = "comboYear";
            this.comboYear.Size = new System.Drawing.Size(112, 21);
            this.comboYear.TabIndex = 4;
            // 
            // SelectYear
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(133, 77);
            this.ControlBox = false;
            this.Controls.Add(this.comboYear);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectYear";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Year";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.ComboBox comboYear;
    }
}