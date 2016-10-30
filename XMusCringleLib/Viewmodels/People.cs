using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMusCringleLib.Classes;
using System.Collections.ObjectModel;

namespace XMusCringleLib.Viewmodels
{
    public class People : Classes.ViewModelBase, IDisposable
    {
        Main main;

        Model.XMusCringleContext db;

        public People(Main inMain)
        {
            SaveChangesCommand = new RelayCommand(SaveChangesExecute);
            CloseCommand = new RelayCommand(CloseExecute);
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
                if (_PeopleList != null)
                {
                    _PeopleList.CollectionChanged -= PeopleList_CollectionChanged;
                    foreach (var a in _PeopleList) a.PropertyChanged -= People_PropertyChanged;
                }

                _PeopleList = value;
                if (PeopleList != null)
                {
                    _PeopleList.CollectionChanged += PeopleList_CollectionChanged;
                    foreach (var a in _PeopleList) a.PropertyChanged += People_PropertyChanged;
                }
                RaisePropertyChanged(PeopleListName);
            }
        }

        private void PeopleList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null) foreach (var a in e.NewItems) ((ViewModelBase)a).PropertyChanged += People_PropertyChanged;
            if (e.OldItems != null) foreach (var a in e.OldItems) ((ViewModelBase)a).PropertyChanged -= People_PropertyChanged;
            foreach (var a in PeopleList) a.ReCalcPartnerList();
            RaisePropertyChanged(PeopleListName);
        }

        private void People_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var senderPerson = sender as Model.Person;
            switch (e.PropertyName)
            {
                case Model.Person.DeleteThisPersonName:
                    PeopleList.Remove(senderPerson);
                    db.People.Remove(senderPerson);
                    break;

                case Model.Person.ONameName:
                    //If we have a default add a new default person
                    if (senderPerson.IsNewItem)
                    {
                        senderPerson.IsNewItem = false;
                        AddDefaultItem();
                    }
                    break;
            }
        }

        public void Refresh()
        {
            db = main.GetDBContext();
            PeopleList = new ObservableCollection<Model.Person>(db.People.ToList());
            foreach (var p in PeopleList) p.db = db;
            AddDefaultItem(); 
        }

        private void AddDefaultItem()
        {
            Model.Person per = new Model.Person
            {
                IsNewItem = true,
                Name = ""
            };
            per.db = db;
            PeopleList.Add(per);
            db.People.Add(per);
        }

        private void RemoveDefaultItem()
        {
            var defPerson = db.People.Local.Where(d => d.Name == "").FirstOrDefault();
            if (defPerson != null)
            {
                PeopleList.Remove(defPerson);
                db.People.Remove(defPerson);
            }
        }

        public RelayCommand SaveChangesCommand { get; private set; }
        private void SaveChangesExecute()
        {
            //Remove default person
            RemoveDefaultItem();
            db.SaveChanges();
            AddDefaultItem();
        }

        public RelayCommand CloseCommand { get; private set; }
        private void CloseExecute()
        {
            this.Dispose();
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~People()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        #endregion
    }
}
