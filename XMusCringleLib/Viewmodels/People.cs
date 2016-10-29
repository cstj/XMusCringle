using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMusCringleLib.Classes;
using System.Collections.ObjectModel;

namespace XMusCringleLib.Viewmodels
{
    public class People : Classes.ViewModelBase
    {
        Main main;

        Model.XMusCringleContext db;

        public People(Main inMain)
        {
            main = inMain;
            Refresh();
        }

        public const string PeopleListName = "PeopleList";
        public ObservableCollection<Model.Person> _PeopleList;
        public ObservableCollection<Model.Person> PeopleList
        {
            get { return _PeopleList; }
            set
            {
                if (_PeopleList == value) return;
                if (_PeopleList != null) _PeopleList.CollectionChanged -= PeopleList_CollectionChanged;
                _PeopleList = value;
                if (PeopleList != null) PeopleList.CollectionChanged += PeopleList_CollectionChanged;
                RaisePropertyChanged(PeopleListName);
            }
        }

        private void PeopleList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

        }

        public void Refresh()
        {
            db = main.GetDBContext();
            PeopleList = new ObservableCollection<Model.Person>(db.People.ToList());
            foreach (var p in PeopleList) p.db = db;
        }
    }
}
