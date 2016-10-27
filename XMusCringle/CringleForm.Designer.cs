namespace XMusCringle
{
    partial class CringleForm
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
            this.butNew = new System.Windows.Forms.Button();
            this.listYears = new System.Windows.Forms.ListBox();
            this.butDelete = new System.Windows.Forms.Button();
            this.listDraw = new System.Windows.Forms.ListBox();
            this.textCover = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butEmailAll = new System.Windows.Forms.Button();
            this.butEmailOne = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textCringleName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(12, 269);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(87, 23);
            this.butNew.TabIndex = 0;
            this.butNew.Text = "New";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // listYears
            // 
            this.listYears.FormattingEnabled = true;
            this.listYears.Location = new System.Drawing.Point(12, 12);
            this.listYears.Name = "listYears";
            this.listYears.Size = new System.Drawing.Size(87, 251);
            this.listYears.Sorted = true;
            this.listYears.TabIndex = 3;
            this.listYears.SelectedIndexChanged += new System.EventHandler(this.listYears_SelectedIndexChanged);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(12, 298);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(87, 23);
            this.butDelete.TabIndex = 4;
            this.butDelete.Text = "Delete";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // listDraw
            // 
            this.listDraw.FormattingEnabled = true;
            this.listDraw.Location = new System.Drawing.Point(105, 12);
            this.listDraw.Name = "listDraw";
            this.listDraw.Size = new System.Drawing.Size(126, 251);
            this.listDraw.Sorted = true;
            this.listDraw.TabIndex = 5;
            this.listDraw.SelectedIndexChanged += new System.EventHandler(this.listDraw_SelectedIndexChanged);
            // 
            // textCover
            // 
            this.textCover.Location = new System.Drawing.Point(237, 80);
            this.textCover.Multiline = true;
            this.textCover.Name = "textCover";
            this.textCover.Size = new System.Drawing.Size(247, 212);
            this.textCover.TabIndex = 6;
            this.textCover.Leave += new System.EventHandler(this.textCover_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cover Letter";
            // 
            // butEmailAll
            // 
            this.butEmailAll.Location = new System.Drawing.Point(299, 298);
            this.butEmailAll.Name = "butEmailAll";
            this.butEmailAll.Size = new System.Drawing.Size(185, 23);
            this.butEmailAll.TabIndex = 9;
            this.butEmailAll.Text = "Send All Emails";
            this.butEmailAll.UseVisualStyleBackColor = true;
            this.butEmailAll.Click += new System.EventHandler(this.butEmailAll_Click);
            // 
            // butEmailOne
            // 
            this.butEmailOne.Location = new System.Drawing.Point(105, 298);
            this.butEmailOne.Name = "butEmailOne";
            this.butEmailOne.Size = new System.Drawing.Size(188, 23);
            this.butEmailOne.TabIndex = 10;
            this.butEmailOne.Text = "Send Email (Selected)";
            this.butEmailOne.UseVisualStyleBackColor = true;
            this.butEmailOne.Click += new System.EventHandler(this.butEmailOne_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Amount $";
            // 
            // textCringleName
            // 
            this.textCringleName.Location = new System.Drawing.Point(313, 12);
            this.textCringleName.MaxLength = 150;
            this.textCringleName.Name = "textCringleName";
            this.textCringleName.Size = new System.Drawing.Size(171, 20);
            this.textCringleName.TabIndex = 14;
            this.textCringleName.Leave += new System.EventHandler(this.textCringleName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Cringle Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "%Name% - Persons Name, %Draw% - Drawn Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "%Amount% - Cringle Amount";
            // 
            // textAmount
            // 
            this.textAmount.Location = new System.Drawing.Point(163, 269);
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(68, 20);
            this.textAmount.TabIndex = 18;
            this.textAmount.Leave += new System.EventHandler(this.textAmount_Leave);
            // 
            // CringleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 328);
            this.Controls.Add(this.textAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textCringleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butEmailOne);
            this.Controls.Add(this.butEmailAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textCover);
            this.Controls.Add(this.listDraw);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.listYears);
            this.Controls.Add(this.butNew);
            this.Name = "CringleForm";
            this.Text = "Cringle Draws";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.ListBox listYears;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.ListBox listDraw;
        private System.Windows.Forms.TextBox textCover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butEmailAll;
        private System.Windows.Forms.Button butEmailOne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCringleName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textAmount;
    }
}