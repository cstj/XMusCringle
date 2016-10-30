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
    [Table("XmusCringle")]
    public class CringleDraw : Classes.ViewModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CringleDrawID { get; set; }

        [Required]
        public long CringleID { get; set; }

        [ForeignKey("CringleID")]
        public virtual CringleDetail CringleInfo { get; set; }

        [Required, Column("PersonID")]
        public Int64 PersonID { get; set; }

        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }

        [NotMapped]
        public string  PersonName { get { return this.Person.Name; } }

        [Required, Column("DrawnID")]
        public long DrawnID { get; set; }

        [ForeignKey("DrawnID")]
        public virtual Person Draw { get; set; }
    }
}
