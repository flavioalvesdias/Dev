using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dev_Appdb.Models
{
    public class DevAppDB : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<View> View { get; set; }

    }
}