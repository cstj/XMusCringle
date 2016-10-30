using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMusCringleLib.Classes;
using XMusCringleLib.Model;

namespace XMusCringleLib.Viewmodels
{
    public class Menu : Classes.ViewModelBase
    {
        Main main;

        public Menu(Main inMain)
        {
            main = inMain;
            main.PropertyChanged += Main_PropertyChanged;
            OpenFileCommand = new RelayCommand(OpenFileExecute);
            NewCommand = new RelayCommand(NewExecute);
            PeopleCommand = new RelayCommand(PeopleExecute);
            RunCringleCommand = new RelayCommand(RungCringleExecute);
        }

        public const string EnableButtonsName = "EnableButtons";
        private bool _EnableButtons;
        public bool EnableButtons
        {
            get { return _EnableButtons; }
            set
            {
                if (_EnableButtons == value) return;
                _EnableButtons = value;
                RaisePropertyChanged(EnableButtonsName);
            }
        } 

        private void Main_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case Main.dbName:
                    if (main.dbConnString == null) EnableButtons = false;
                    else EnableButtons = true;
                    break;
            }
        }

        public RelayCommand OpenFileCommand { get; private set; }
        private void OpenFileExecute()
        {
            Ookii.Dialogs.Wpf.VistaOpenFileDialog ofd = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();
            ofd.Filter = "Cringle Files (*.cringle)|*.cringle|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Multiselect = false;
            bool? result = ofd.ShowDialog();
            if (result == true)
            {
                OpenFile(ofd.FileName);
            }
        }

        public void OpenFile(String fileName)
        {
            try
            {
                System.Data.SQLite.SQLiteConnectionStringBuilder dbBuild = new System.Data.SQLite.SQLiteConnectionStringBuilder();
                dbBuild.DataSource = fileName;
                string connString = "Provider=System.Data.SQLite;" + dbBuild.ToString();
                var conn = new System.Data.SQLite.SQLiteConnection(dbBuild.ToString());
                //Test Connection (kinda crap way but hey)
                using (var context = new Model.XMusCringleContext(conn, true))
                {
                    var c = context.People.ToList();
                }

                main.dbConnString = connString;
            }
            catch (Exception e)
            {
                main.dbConnString = null;
            }
        }

        public RelayCommand NewCommand { get; private set; }
        private void NewExecute()
        {
            //Create new saveas dialog for placeing the new db
            Ookii.Dialogs.Wpf.VistaSaveFileDialog sfd = new Ookii.Dialogs.Wpf.VistaSaveFileDialog();
            sfd.OverwritePrompt = true;
            sfd.AddExtension = true;
            sfd.DefaultExt = "cringle";
            bool? result = sfd.ShowDialog();
            //Was ok clicked
            if (result == true)
            {
                //Copy base file into saved filename given
                String source = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "base.cringle");
                System.IO.File.Copy(source, sfd.FileName, true);
                //Open file
                OpenFile(sfd.FileName);
            }
        }

        public RelayCommand PeopleCommand { get; private set; }
        private void PeopleExecute()
        {
            main.People.Refresh();
        }

        public RelayCommand RunCringleCommand { get; private set; }
        private void RungCringleExecute()
        {
            main.Cringle.Refresh();
        }
    }
}
