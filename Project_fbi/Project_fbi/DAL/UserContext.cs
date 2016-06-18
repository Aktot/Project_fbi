using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Project_fbi.DAL
{
    public class UserContext:DbContext
    {
       
            public DbSet<UserCollection> Users { get; set; }
            public DbSet<ImageCollection> Images { get; set; }
            public DbSet<History> Histories { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    }
