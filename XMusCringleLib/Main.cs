using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMusCringleLib.Viewmodels;

namespace XMusCringleLib
{
    public class Main : Classes.ViewModelBase
    {
        public const string dbName = "dbConnString";
        private string _dbConnString;
        public string dbConnString
        {
            get { return _dbConnString; }
            set
            {
                if (_dbConnString == value) return;
                _dbConnString = value;
                RaisePropertyChanged(dbName);
            }
        }

        public Model.XMusCringleContext GetDBContext()
        {
            if (dbConnString == null) return null;
            var conn = new System.Data.SQLite.SQLiteConnection(dbConnString);
            return new Model.XMusCringleContext(conn, true);
        }


        public Main()
        {
            _dbConnString = null;
        }

        private Cringle _Cringle;
        public Cringle Cringle
        {
            get
            {
                if (_Cringle == null) _Cringle = new Cringle(this);
                return _Cringle;
            }
        }

        private NewCringle _NewCringle;
        public NewCringle NewCringle
        {
            get
            {
                if (_NewCringle == null) _NewCringle = new NewCringle(this);
                return _NewCringle;
            }
        }

        private Menu _Menu;
        public Menu Menu
        {
            get
            {
                if (_Menu == null) _Menu = new Menu(this);
                return _Menu;
            }
        }

        private People _People;
        public People People
        {
            get
            {
                if (_People == null) _People = new People(this);
                return _People;
            }
        }
    }
}
