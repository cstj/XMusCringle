namespace XMusCringle
{
    partial class MainForm
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
            this.butPeople = new System.Windows.Forms.Button();
            this.butCringle = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labFileName = new System.Windows.Forms.Label();
            this.butNew = new System.Windows.Forms.Button();
            this.butOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butPeople
            // 
            this.butPeople.Enabled = false;
            this.butPeople.Location = new System.Drawing.Point(12, 78);
            this.butPeople.Name = "butPeople";
            this.butPeople.Size = new System.Drawing.Size(96, 23);
            this.butPeople.TabIndex = 0;
            this.butPeople.Text = "People List";
            this.butPeople.UseVisualStyleBackColor = true;
            this.butPeople.Click += new System.EventHandler(this.butPeople_Click);
            // 
            // butCringle
            // 
            this.butCringle.Enabled = false;
            this.butCringle.Location = new System.Drawing.Point(11, 107);
            this.butCringle.Name = "butCringle";
            this.butCringle.Size = new System.Drawing.Size(96, 23);
            this.butCringle.TabIndex = 1;
            this.butCringle.Text = "Run Cringle";
            this.butCringle.UseVisualStyleBackColor = true;
            this.butCringle.Click += new System.EventHandler(this.butCringle_Click);
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(12, 227);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(96, 23);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current DB:";
            // 
            // labFileName
            // 
            this.labFileName.AutoSize = true;
            this.labFileName.Location = new System.Drawing.Point(12, 22);
            this.labFileName.Name = "labFileName";
            this.labFileName.Size = new System.Drawing.Size(0, 13);
            this.labFileName.TabIndex = 4;
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(11, 49);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(46, 23);
            this.butNew.TabIndex = 5;
            this.butNew.Text = "New";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // butOpen
            // 
            this.butOpen.Location = new System.Drawing.Point(61, 49);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(46, 23);
            this.butOpen.TabIndex = 6;
            this.butOpen.Text = "Open";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(119, 262);
            this.Controls.Add(this.butOpen);
            this.Controls.Add(this.butNew);
            this.Controls.Add(this.labFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butCringle);
            this.Controls.Add(this.butPeople);
            this.Name = "MainForm";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butPeople;
        private System.Windows.Forms.Button butCringle;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labFileName;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Button butOpen;
    }
}