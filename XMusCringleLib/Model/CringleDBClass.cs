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
    public class XMusCringleContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<CringleDetail> CringleDetails { get; set; }
        public DbSet<CringleDraw> XmusCringle { get; set; }

        public XMusCringleContext(string connectionString) : base(connectionString){}
        public XMusCringleContext(System.Data.Common.DbConnection conn, bool ownConnection) : base(conn, ownConnection) { }
    }
}