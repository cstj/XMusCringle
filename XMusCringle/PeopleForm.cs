using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace XMusCringle
{
    public partial class PeopleForm : Form
    {
        XMusCringleLib.Viewmodels.People context;
        
        public PeopleForm()
        {
            InitializeComponent();
            context = ResourceLocator.Main.People;

            //this.personBindingSource.DataSource = this.db.People.Local.ToBindingList();
            //this.personBindingSource1.DataSource = this.db.People.Local.ToBindingList();
            this.dataGridView1.Refresh();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            /*
            foreach (Person person in this.db.People.Local.ToList())
            {
                if (person.Name == null) this.db.People.Remove(person);
            }
            this.db.SaveChanges();
            this.dataGridView1.Refresh();*/
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*
            DataGridView dgv = (DataGridView)sender;
            //if the sender was the Partner Column then update corasponding Partner
            if (dgv.Columns[e.ColumnIndex].Name == "partnerIDDataGridViewComboColumn")
            {
                UpdatePartnerToPerson(dgv, e.ColumnIndex, e.RowIndex);
            }*/
        }

        private void UpdatePartnerToPerson(DataGridView dgv, Int32 ColumnIndex, Int32 RowIndex)
        {
            /*
            //Get Partner ID if that was changed
            Int64? partnerID = null;
            if (dgv[ColumnIndex, RowIndex].Value != null) partnerID = Convert.ToInt64(dgv[ColumnIndex, RowIndex].Value);
            Int64 personID = Convert.ToInt64(dgv["personIDDataGridViewTextBoxColumn", RowIndex].Value);
            //Get the partner person record
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (partnerID != null)
                {
                    if (Convert.ToInt64(r.Cells["personIDDataGridViewTextBoxColumn"].Value) == partnerID)
                    {
                        r.Cells["partnerIDDataGridViewComboColumn"].Value = personID;
                        break;
                    }
                }
                else
                {
                    if (Convert.ToInt64(r.Cells["partnerIDDataGridViewComboColumn"].Value) == personID)
                    {
                        r.Cells["partnerIDDataGridViewComboColumn"].Value = null;
                    }
                }
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            DataGridView dgv = (DataGridView)sender;
            //If the remove partner button is clicked then remove the partner
            if (dgv.Columns[e.ColumnIndex].Name == "remPartnerDataGridViewButtonColumn")
            {
                dgv["partnerIDDataGridViewComboColumn", e.RowIndex].Value = null;
                UpdatePartnerToPerson(dgv, e.ColumnIndex, e.RowIndex);
            }*/
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            /*
            this.db.Configuration.ProxyCreationEnabled = proxySetting;
            this.Close();*/
        }
    }
}
