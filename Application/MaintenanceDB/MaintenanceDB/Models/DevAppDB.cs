using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MaintenanceDB.Models
{
    public class MyUser : User
    {
        //public DateTime BirthDate { get; set; }
    }

    public class CustomUserContext : IdentityStoreContext
    {
        public CustomUserContext(DbContext db)
            : base(db)
        {
            Users = new UserStore<MyUser>(db);
        }
    }

    public class MyDbContext : IdentityDbContext<MyUser, UserClaim, UserSecret, UserLogin, Role, UserRole>
    {
        public MyDbContext() : base("DevAppDB") { }
        public DbSet<SysMenu> sysMenu { get; set; }
        public DbSet<SysView> sysView { get; set; }
    }
    
}