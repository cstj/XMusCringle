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
    [Table("Settings")]
    public class Settings
    {
        [Key]
        public Int64 ID { get; set; }
        public string EmailFromAddress { get; set; }
        [NotMapped] //Store Password with Some Encryption
        public string Password
        {
            get
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = this.PasswordKey;
                ICryptoTransform decryptor = des.CreateDecryptor();
                // decrypt
                byte[] originalAgain = decryptor.TransformFinalBlock(this.PasswordText, 0, this.PasswordText.Length);
                return originalAgain.ToString();
            }

            set
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.GenerateKey();
                byte[] key = des.Key; // save this!
                this.PasswordKey = key;

                ICryptoTransform encryptor = des.CreateEncryptor();
                // encrypt
                byte[] text = Encoding.UTF8.GetBytes(value);
                byte[] enc = encryptor.TransformFinalBlock(text, 0, text.Length);
                this.PasswordText = enc;
            }
        }
        private byte[] PasswordKey { get; set; }
        private byte[] PasswordText { get; set; }
        public string EmailHost { get; set; }
        public string EmailPort { get; set; }
        public bool EmailSSL { get; set; }
    }/*
      * 

                //Send Email
            MailAddress fromAddress = new MailAddress("cstjohn83@gmail.com");
            MailAddress toAddress = new MailAddress(draw.Draw.Email);
            // zqdyxjmlppasamdl 
            String fromPassword = " zqdyxjmlppasamdl";
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)*/

    [Table("People")]
    public class Person : Classes.ViewModelBase
    {
        public Person()
        {
            PropertyChanged += Person_PropertyChanged;
            db = null;
        }

        #region DB Columns
        [Key]
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

        private void Person_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (db != null)
            {
                switch (e.PropertyName)
                {
                    case dbName:
                        //Change partner list to not include the current partner or the current person
                        List<Person> tmpList = db.People.Where(d => d.PersonID != this.PersonID).ToList();
                        PartnerList = tmpList;
                        break;
                }
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


    }

    [Table("CringleDraw")]
    public class CringleDraw
    {
        [Key]
        public Int64 CringleDrawID { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [ForeignKey("Year")]
        public virtual CringleDetail CringleInfo { get; set; }
        [Required, Column("PersonID")]
        public Int64 PersonID { get; set; }
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
        [NotMapped]
        public String PersonName { get { return this.Person.Name; } }
        [Required, Column("DrawnID")]
        public Int64 DrawnID { get; set; }
        [ForeignKey("DrawnID")]
        public virtual Person Draw { get; set; }

        //Navigations
    }

    [Table("CringleDetails")]
    public class CringleDetail
    {
        [Key]
        public DateTime Year { get; set; }
        [NotMapped]
        public Int32 YearOnly { 
            get { return this.Year.Year; } 
        }
        public String CoverLetter { get; set; }
        public Decimal? Amount { get; set; }
        public String CringleName { get; set; }

        [ForeignKey("Year")]
        public virtual IList<CringleDraw> CringleDraws { get; set; }
    }

    public class XMusCringleContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<CringleDetail> CringleDetails { get; set; }
        public DbSet<CringleDraw> XmusCringle { get; set; }

        public XMusCringleContext(string connectionString) : base(connectionString){}
        public XMusCringleContext(System.Data.Common.DbConnection conn, bool ownConnection) : base(conn, ownConnection) { }
    }
}