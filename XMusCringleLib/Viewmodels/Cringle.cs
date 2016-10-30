using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XMusCringleLib.Viewmodels
{
    public class Cringle : Classes.ViewModelBase, IDisposable
    {
        Main main;

        Model.XMusCringleContext db;

        public const string CurrentCringleName = "CurrentCringle";
        private Model.CringleDetail _CurrentCringle;
        public Model.CringleDetail CurrentCringle
        {
            get { return _CurrentCringle; }
            set
            {
                if (_CurrentCringle == value) return;
                _CurrentCringle = value;
                RaisePropertyChanged(CurrentCringleName);
            }
        }

        public const string CringleListName = "CringleList";
        private ObservableCollection<Model.CringleDetail> _CringleList;
        public ObservableCollection<Model.CringleDetail> CringleList
        {
            get { return _CringleList; }
            set
            {
                if (_CringleList == value) return;
                if (_CringleList != null)
                {
                    _CringleList.CollectionChanged -= CringleList_CollectionChanged;
                }
                _CringleList = value;
                if (_CringleList != null)
                {
                    _CringleList.CollectionChanged += CringleList_CollectionChanged;
                    foreach (var a in _CringleList) a.PropertyChanged += CringleList_PropertyChanged;
                }
                RaisePropertyChanged(CringleListName);
            }
        }

        private void CringleList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var senderCringle = sender as Model.CringleDetail;
            switch (e.PropertyName)
            {
                case Model.CringleDetail.IsSelectedName:
                    if (senderCringle.IsSelected)
                    {
                        DrawPeople = new ObservableCollection<Model.Person>(senderCringle.CringleDraws.Select(d => d.Person).ToList());
                    }
                    break;
            }
        }

        public const string DrawPeopleName = "DrawPeople";
        private ObservableCollection<Model.Person> _DrawPeople;
        public ObservableCollection<Model.Person> DrawPeople
        {
            get { return _DrawPeople; }
            set
            {
                if (_DrawPeople == value) return;
                if (_DrawPeople != null) _DrawPeople.CollectionChanged -= DrawPeople_CollectionChanged;
                _DrawPeople = value;
                if (_DrawPeople != null) _DrawPeople.CollectionChanged += DrawPeople_CollectionChanged;
                RaisePropertyChanged(DrawPeopleName);
            }
        }

        private void DrawPeople_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(DrawPeopleName);
        }

        private void CringleList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(CringleListName);
        }

        public Cringle(Main inMain)
        {
            main = inMain;
            //Set year list
            NewCringleCommand = new Classes.RelayCommand(NewCringleExecute);
            SaveChangesCommand = new Classes.RelayCommand(SaveChangesExecute);
            CloseCommand = new Classes.RelayCommand(CloseExecute);
            EmailAllCommand = new Classes.RelayCommand(EmailAllExecute);
            EmailSelectedCommand = new Classes.RelayCommand(EmailSelectedExecute);
            Refresh();
        }

        public void Refresh()
        {
            db = main.GetDBContext();
            var cList = db.CringleDetails.ToList();
            CringleList = new ObservableCollection<Model.CringleDetail>(cList);
        }

        public Classes.RelayCommand NewCringleCommand { get; internal set; }
        private void NewCringleExecute()
        {
            main.NewCringle.Refresh(db);
        }

        public Classes.RelayCommand SaveChangesCommand { get; internal set; }
        private void SaveChangesExecute()
        {
            db.SaveChanges();
        }

        public Classes.RelayCommand CloseCommand { get; internal set; }
        private void CloseExecute()
        {
            this.Dispose();
        }

        public void RefreshCringle(long CringleID)
        {
            Refresh();
            foreach (var a in CringleList)
            {
                if (a.CringleID != CringleID)
                    a.IsSelected = false;
                else
                    a.IsSelected = true;
            }
        }

        public Classes.RelayCommand EmailSelectedCommand { get; private set; }
        private void EmailSelectedExecute()
        {
            DoEmails(true);
        }

        public Classes.RelayCommand EmailAllCommand { get; private set; }
        private void EmailAllExecute()
        {
            DoEmails(false);
        }

        private void DoEmails(Boolean selectedOnly)
        {
            //Save Any Changes
            db.SaveChanges();
            //Test Name & Cover letter is not nothing.
            if (CurrentCringle.OCoverLetter.Trim() == "" || CurrentCringle.OCringleName.Trim() == "")
            {
                //TODO: Msgbox to say you need to enter stuff
            }
            //Otherwise on with the show!
            else
            {
                if (selectedOnly)
                {
                    var person = DrawPeople.Where(d => d.IsSelected).FirstOrDefault();
                    if (person != null)
                    {
                        var draw = CurrentCringle.CringleDraws.Where(d => d.Person.PersonID == person.PersonID).FirstOrDefault();
                        EmailPerson(draw, CurrentCringle.CoverLetter);
                    }
                }
                else
                {
                    foreach (Model.CringleDraw draw in CurrentCringle.CringleDraws)
                    {
                        EmailPerson(draw, CurrentCringle.CoverLetter);
                    }
                }
            }
        }

        private void EmailPerson(XMusCringleLib.Model.CringleDraw draw, string coverLetter)
        {
            //Construct Cover Letter
            String Contents = coverLetter;
            Contents = Regex.Replace(coverLetter, @"(?i)%name%", draw.Person.Name);
            Contents = Regex.Replace(Contents, @"(?i)%draw%", draw.Draw.Name);
            Contents = Regex.Replace(Contents, @"(?i)%amount%", "$" + draw.CringleInfo.Amount.ToString());

            //Header
            string Subject = draw.CringleInfo.CringleName;
            Subject = Regex.Replace(Subject, @"(?i)%name%", draw.Person.Name);
            Subject = Regex.Replace(Subject, @"(?i)%draw%", draw.Draw.Name);
            Subject = Regex.Replace(Subject, @"(?i)%amount%", "$" + draw.CringleInfo.Amount.ToString());
            
            //Send Email
            MailAddress fromAddress = new MailAddress("cstjohn83@gmail.com");
            MailAddress toAddress = new MailAddress(draw.Person.Email);
            // zqdyxjmlppasamdl 
            String fromPassword = " zqdyxjmlppasamdl";
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (MailMessage msg = new MailMessage(fromAddress, toAddress))
            {
                msg.Subject = Subject;
                msg.Body = Contents;
                Boolean fail = true;
                Int32 counter = 0;
                while (fail && counter < 5)
                {
                    try
                    {
                        smtp.Send(msg);
                        fail = false;
                    }
                    catch (SmtpException s) { fail = true; }
                }
            }

        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Cringle()
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
