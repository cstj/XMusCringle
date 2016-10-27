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
    public partial class SelectPeople : Form
    {
        public SelectPeople()
        {
            InitializeComponent();
            /*
            //Fill Combo
            db = _db;
            this.db.People.Load();
            this.personBindingSource.DataSource = this.db.People.Local.ToBindingList();
            */
        }

        /*
        public List<CringleDBClass.Person> People
        {
            get
            {
                List<CringleDBClass.Person> temp = new List<Person>();
                foreach (Person p in listPeople.SelectedItems)
                {
                    temp.Add(p);
                }
                return temp;
            }
        }*/

        private void butCancel_Click(object sender, EventArgs e)
        {
            /*
            this.DialogResult = DialogResult.Cancel;
            this.Hide();*/
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            /*
            this.DialogResult = DialogResult.OK;
            this.Hide();*/
        }
    }
}
