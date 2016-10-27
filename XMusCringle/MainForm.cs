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
    public partial class MainForm : Form
    {
        XMusCringleLib.Viewmodels.Menu context;

        public MainForm()
        {
            InitializeComponent();
            context = ResourceLocator.Main.Menu;
            context.PropertyChanged += Context_PropertyChanged;
        }

        private void Context_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case XMusCringleLib.Viewmodels.Menu.EnableButtonsName:
                    butCringle.Enabled = context.EnableButtons;
                    butPeople.Enabled = context.EnableButtons;
                    break;
            }
        }

        private void butPeople_Click(object sender, EventArgs e)
        {
            PeopleForm p = new PeopleForm();
            p.ShowDialog();
        }

        private void butCringle_Click(object sender, EventArgs e)
        {
            
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            
            //Close this form
            this.Close();
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            context.NewCommand.Execute(null);
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            context.OpenFileCommand.Execute(null);
        }

        private void OpenSelectForm(String strRefrence)
        {
            /*
            Form form = null;
            try
            {
                form = formDict[strRefrence];
            }
            catch { }
            if (form == null || form.IsDisposed)
            {
                switch (strRefrence)
                {
                    case "PeopleForm":
                        form = new PeopleForm(db);
                        break;
                    case "CringleForm":
                        form = new CringleForm(db);
                        break;
                }
                formDict[strRefrence] = form;
                form.Visible = true;
            }
            form.Select();*/
        }
    }
}
