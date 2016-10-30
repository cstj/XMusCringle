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
    [Table("CringleDetails")]
    public class CringleDetail : Classes.ViewModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CringleID { get; set; }

        public string CringleName { get; set; }
        public const string CringleNameName = "CringleName";
        [NotMapped]
        public string OCringleName
        {
            get { return CringleName; }
            set
            {
                if (CringleName == value) return;
                CringleName = value;
                RaisePropertyChanged(CringleNameName);
            }
        }

        public String CoverLetter { get; set; }
        public const string OCoverLetterName = "OCoverLetter";
        [NotMapped]
        public string OCoverLetter
        {
            get { return CoverLetter; }
            set
            {
                if (CoverLetter == value) return;
                CoverLetter = value;
                RaisePropertyChanged(OCoverLetterName);
            }
        }

        public Decimal? Amount { get; set; }
        public const string OAmountName = "OAmount";
        [NotMapped]
        public decimal? OAmount
        {
            get { return Amount; }
            set
            {
                if (Amount == value) return;
                Amount = value;
                RaisePropertyChanged(OAmountName);
            }
        }

        [ForeignKey("CringleID")]
        public virtual IList<CringleDraw> CringleDraws { get; set; }

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
    }
}
