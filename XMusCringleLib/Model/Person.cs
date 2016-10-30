using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Linq;


namespace XMusCringleLib.Model
{
    [Table("People")]
    public class Person : Classes.ViewModelBase
    {
        #region DB Columns
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 PersonID { get; set; }
        public const string OPersonIDName = "OPersonID";
        [NotMapped]
        public Int64 OPersonID
        {
            get { return PersonID; }
            set
            {
                if (PersonID == value) return;
                PersonID = value;
                RaisePropertyChanged(OPersonIDName);
            }
        }

        [Required]
        public string Name { get; set; }
        public const string ONameName = "OName";
        [NotMapped]
        public string OName
        {
            get { return Name; }
            set
            {
                if (Name == value) return;
                Name = value;
                RaisePropertyChanged(ONameName);
            }
        }

        [Required]
        public string Email { get; set; }
        public const string OEmailName = "OEmail";
        [NotMapped]
        public string OEmail
        {
            get { return Email; }
            set
            {
                if (Email == value) return;
                Email = value;
                RaisePropertyChanged(OEmailName);
            }
        }

        public Int64? PartnerID { get; set; }
        public const string OPartnerIDName = "OPartnerID";
        [NotMapped]
        public Int64? OPartnerID
        {
            get { return PartnerID; }
            set
            {
                if (PartnerID == value) return;
                PartnerID = value;
                RaisePropertyChanged(OPartnerIDName);
            }
        }

        [ForeignKey("PartnerID")]
        public virtual Person Partner { get; set; }
        public const string OPartnerName = "OPartner";
        [NotMapped]
        public Person OPartner
        {
            get { return Partner; }
            set
            {
                if (Partner == value) return;
                Partner = value;
                RaisePropertyChanged(OPartnerName);
            }
        }
        #endregion

        #region Change Handleing
        public Person()
        {
            PropertyChanged += Person_PropertyChanged;
            RemovePartnerCommand = new Classes.RelayCommand(RemovePartnerExecute);
            DeletePersonCommand = new Classes.RelayCommand(DeletePersonExecute);
            db = null;
        }

        private void Person_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (db != null)
            {
                switch (e.PropertyName)
                {
                    case dbName:
                        //Change partner list to not include the current partner or the current person
                        ReCalcPartnerList();
                        break;

                    case OPartnerName:
                        if (OPartner != null)
                            OPartner.OPartner = this;//If the partner is set, set the partner's partner to this person
                        break;

                    case OPartnerIDName:
                        if (OPartnerID != null)
                            OPartner.OPartnerID = PersonID;
                        break;
                }
            }
        }

        public void ReCalcPartnerList()
        {
            if (db != null)
            {
                List<Person> tmpList = db.People.Where(d => d.PersonID != this.PersonID).ToList();
                //tmpList.AddRange(db.People.Local.Where(d => d.Name != this.Name).ToList());
                PartnerList = tmpList;
            }
        }

        public const string dbName = "db";
        [NotMapped]
        private XMusCringleContext _db;
        [NotMapped]
        public XMusCringleContext db
        {
            get { return _db; }
            set
            {
                if (_db == value) return;
                _db = value;
                RaisePropertyChanged(dbName);
            }
        }

        public const string PartnerListName = "PartnerList";
        [NotMapped]
        private List<Person> _PartnerList;
        [NotMapped]
        public List<Person> PartnerList
        {
            get { return _PartnerList; }
            set
            {
                if (_PartnerList == value) return;
                _PartnerList = value;
                RaisePropertyChanged(PartnerListName);
            }
        }

        [NotMapped]
        public Classes.RelayCommand RemovePartnerCommand { get; private set; }
        private void RemovePartnerExecute()
        {
            //Set partner to null
            OPartner.OPartnerID = null;
            OPartner.OPartner = null;

            OPartner = null;
            OPartnerID = null;
        }

        public const string DeleteThisPersonName = "DeleteThisPerson";
        [NotMapped]
        private bool _DeleteThisPerson;
        [NotMapped]
        public bool DeleteThisPerson
        {
            get { return _DeleteThisPerson; }
            set
            {
                if (_DeleteThisPerson == value) return;
                _DeleteThisPerson = value;
                RaisePropertyChanged(DeleteThisPersonName);
            }
        }
        [NotMapped]
        public Classes.RelayCommand DeletePersonCommand { get; private set; }
        private void DeletePersonExecute()
        {
            //If we are deleteing then remove any partners
            if (OPartner != null)
            {
                OPartner.OPartner = null;
                OPartner.OPartnerID = null;
            }
            DeleteThisPerson = true;
        }

        public const string IsSelectedName = "IsSelected";
        [NotMapped]
        private bool _IsSelected;
        [NotMapped]
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected == value) return;
                _IsSelected = value;
                RaisePropertyChanged(IsSelectedName);
            }
        }

        [NotMapped]
        public bool IsNewItem = false;
        #endregion
    }
}
