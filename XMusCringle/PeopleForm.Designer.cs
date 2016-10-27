namespace XMusCringle
{
    partial class PeopleForm
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
            this.personBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.butSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butClose = new System.Windows.Forms.Button();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partnerIDDataGridViewComboColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.partnerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remPartnerDataGridViewButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.partnerIDDataGridViewComboColumn,
            this.partnerDataGridViewTextBoxColumn,
            this.remPartnerDataGridViewButtonColumn});
            this.dataGridView1.DataSource = this.personBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(683, 368);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(12, 386);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(92, 23);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "Save Changes";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Partner";
            this.dataGridViewTextBoxColumn1.HeaderText = "Partner";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(110, 386);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(92, 23);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(XMusCringleLib.Model.Person);
            // 
            // personIDDataGridViewTextBoxColumn
            // 
            this.personIDDataGridViewTextBoxColumn.DataPropertyName = "PersonID";
            this.personIDDataGridViewTextBoxColumn.HeaderText = "PersonID";
            this.personIDDataGridViewTextBoxColumn.Name = "personIDDataGridViewTextBoxColumn";
            this.personIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.FillWeight = 150F;
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 150;
            // 
            // partnerIDDataGridViewComboColumn
            // 
            this.partnerIDDataGridViewComboColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.partnerIDDataGridViewComboColumn.DataPropertyName = "PartnerID";
            this.partnerIDDataGridViewComboColumn.DataSource = this.personBindingSource1;
            this.partnerIDDataGridViewComboColumn.DisplayMember = "Name";
            this.partnerIDDataGridViewComboColumn.HeaderText = "PartnerID";
            this.partnerIDDataGridViewComboColumn.Name = "partnerIDDataGridViewComboColumn";
            this.partnerIDDataGridViewComboColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.partnerIDDataGridViewComboColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.partnerIDDataGridViewComboColumn.ValueMember = "PersonID";
            // 
            // partnerDataGridViewTextBoxColumn
            // 
            this.partnerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.partnerDataGridViewTextBoxColumn.DataPropertyName = "Partner";
            this.partnerDataGridViewTextBoxColumn.HeaderText = "Partner";
            this.partnerDataGridViewTextBoxColumn.Name = "partnerDataGridViewTextBoxColumn";
            this.partnerDataGridViewTextBoxColumn.Visible = false;
            // 
            // remPartnerDataGridViewButtonColumn
            // 
            this.remPartnerDataGridViewButtonColumn.HeaderText = "Remove Partner";
            this.remPartnerDataGridViewButtonColumn.Name = "remPartnerDataGridViewButtonColumn";
            this.remPartnerDataGridViewButtonColumn.Text = "Rem Partner";
            this.remPartnerDataGridViewButtonColumn.Width = 50;
            // 
            // PeopleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 421);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PeopleForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.BindingSource personBindingSource1;
        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn personIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn partnerIDDataGridViewComboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partnerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn remPartnerDataGridViewButtonColumn;

    }
}

