using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMusCringle
{
    public partial class SelectYear : Form
    {
        public SelectYear()
        {
            InitializeComponent();
            //Fill Combo
            for (Int32 i = (DateTime.Now.Year); i < (DateTime.Now.Year + 10); i++)
            {
                comboYear.Items.Add(i);
            }
            comboYear.SelectedIndex = 0;
        }

        public DateTime Year
        {
            get
            {
                return new DateTime((Int32)comboYear.SelectedItem,1,1);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
