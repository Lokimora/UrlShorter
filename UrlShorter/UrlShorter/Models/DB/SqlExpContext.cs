using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UrlShorter.Models.DB
{
    public class SqlExpContext : DbContext
    {
        public SqlExpContext() : base("SQLDB")
        {

        }

        public DbSet<Reduction> UrlReduct { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
        }
    }
}