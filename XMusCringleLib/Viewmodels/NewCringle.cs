using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMusCringleLib.Viewmodels
{
    public class NewCringle : Classes.ViewModelBase
    {
        Main main;

        public const string PeopleInCringleName = "PeopleInCringle";
        private ObservableCollection<Model.Person> _PeopleInCringle;
        public ObservableCollection<Model.Person> PeopleInCringle
        {
            get { return _PeopleInCringle; }
            set
            {
                if (_PeopleInCringle == value) return;
                if (_PeopleInCringle != null) _PeopleInCringle.CollectionChanged -= PeopleInCringle_CollectionChanged;
                _PeopleInCringle = value;
                if (_PeopleInCringle != null) _PeopleInCringle.CollectionChanged += PeopleInCringle_CollectionChanged;
                RaisePropertyChanged(PeopleInCringleName);
            }
        }

        private void PeopleInCringle_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(PeopleInCringleName);
        }

        public const string AvilablePeopleName = "AvilablePeople";
        private ObservableCollection<Model.Person> _AvilablePeople;
        public ObservableCollection<Model.Person> AvilablePeople
        {
            get { return _AvilablePeople; }
            set
            {
                if (_AvilablePeople == value) return;
                if (_AvilablePeople != null) _AvilablePeople.CollectionChanged -= AvilablePeople_CollectionChanged;
                _AvilablePeople = value;
                if (_AvilablePeople != null) _AvilablePeople.CollectionChanged += AvilablePeople_CollectionChanged;
                RaisePropertyChanged(AvilablePeopleName);
            }
        }

        private void AvilablePeople_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(AvilablePeopleName); 
        }

        XMusCringleLib.Model.XMusCringleContext db;
        public const string CurrentCringleName = "CurrentCringle";
        private Model.CringleDetail _CurrentCringle;
        Model.CringleDetail CurrentCringle
        {
            get { return _CurrentCringle; }
            set
            {
                if (_CurrentCringle == value) return;
                _CurrentCringle = value;
                RaisePropertyChanged(CurrentCringleName);
            }
        }

        public NewCringle(Main inMain)
        {
            main = inMain;
            CurrentCringle = null;
            AddPersonCommand = new Classes.RelayCommand(AddPersonExecute);
            RemovePersonCommand = new Classes.RelayCommand(RemovePersonExecute);
            OKCommand = new Classes.RelayCommand(OKExecute);
        }

        public void Refresh(XMusCringleLib.Model.XMusCringleContext _db)
        {
            db = _db;
            PeopleInCringle = new ObservableCollection<Model.Person>();
            Model.CringleDetail cdet = new Model.CringleDetail
            {
                OCoverLetter = "Put your cover letter in here.  Use the template variables and they will be replaced wiht the values you enter.",
                OCringleName = "New Cringle",
                IsSelected = true,
                OAmount = 50,
            };
            CurrentCringle = cdet;
            //Set Avilable People
            AvilablePeople = new ObservableCollection<Model.Person>(db.People.ToList());
        }

        public Classes.RelayCommand AddPersonCommand { get; internal set; }
        private void AddPersonExecute()
        {
            var peopleToAdd = AvilablePeople.Where(a => a.IsSelected).ToList();
            foreach (var p in peopleToAdd)
            {
                PeopleInCringle.Add(p);
                AvilablePeople.Remove(p);
            }
        }

        public Classes.RelayCommand RemovePersonCommand { get; internal set; }
        private void RemovePersonExecute()
        {
            var peopleToRemove = PeopleInCringle.Where(a => a.IsSelected).ToList();
            foreach (var p in peopleToRemove)
            {
                AvilablePeople.Add(p);
                PeopleInCringle.Remove(p);
            }
        }

        public Classes.RelayCommand OKCommand { get; internal set; }
        private void OKExecute()
        {
            //Add Cringle
            db.CringleDetails.Add(CurrentCringle);
            RunDraw(PeopleInCringle.ToList());
            main.Cringle.RefreshCringle(CurrentCringle.CringleID);
        }

        private void RunDraw(List<XMusCringleLib.Model.Person> people)
        {
            //Got a list of 'people' have ot pair them up with random people
            //Create Copy of list
            List<Model.Person> selFullPeople = new List<Model.Person>();
            foreach (Model.Person p in people)
                selFullPeople.Add(p);
            //Save First
            //db.SaveChanges();

            //Init random!
            Random rand = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            //Do untill we have a good success or counter exceeds
            bool success = false;
            long counter = 0;
            while (success == false && counter <= 100000000)
            {
                //Assume i will succeed
                counter++;
                success = true;
                foreach (Model.Person p in people)
                {
                    //Create Selection List
                    List< Model.Person> selPeople = SelectionList(p, selFullPeople, true);
                    //Check we have a valid list
                    if (selPeople.Count > 0)
                    {
                        //Make selection
                        int intPerson = rand.Next(0, selPeople.Count());
                        Model.CringleDraw draw = new Model.CringleDraw()
                        {
                            CringleInfo = CurrentCringle,
                            Draw = selPeople[intPerson],
                            Person = p,
                            PersonID = p.PersonID,
                            CringleID = CurrentCringle.CringleID
                        };
                        db.XmusCringle.Add(draw);

                        //Remove the person they drew
                        foreach (Model.Person pe in selFullPeople)
                        {
                            if (pe.PersonID == selPeople[intPerson].PersonID)
                            {
                                selFullPeople.Remove(pe);
                                break;
                            }
                        }
                    }
                    //No valid list, we FAILED!
                    else
                    {
                        success = false;
                        break;
                    }
                }
            }
            //If we're here we MUST have sucedded or REALLY failed (list 10000 times)
            if (success)
            {
                //save oru changes
                db.SaveChanges();
            }
        }

        //Create personalised list of people to choose from
        private List<Model.Person> SelectionList(Model.Person person, List<XMusCringleLib.Model.Person> fullList, Boolean removePartner)
        {
            //Create copty of full List removing self and partner
            List<Model.Person> selPeople = new List<Model.Person>();
            foreach (Model.Person p in fullList)
            {
                if (p.PersonID != person.PersonID && (p.PersonID != person.PartnerID && removePartner))
                    selPeople.Add(p);
            }
            return selPeople;
        }
    }
}
