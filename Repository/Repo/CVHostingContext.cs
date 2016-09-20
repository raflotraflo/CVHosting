using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Microsoft.AspNet.Identity.EntityFramework;
using Repository.Models;
using System.Data.Entity;

namespace Repository.Repo
{
    public class CVHostingContext: IdentityDbContext, ICVHostingContext
    {
        public CVHostingContext() : base("DefaultConnection")
        {
        }

        public static CVHostingContext Create()
        {
            return new CVHostingContext();
        }

        public DbSet<Availability> Availability { get; set; }
        public DbSet<CVApplication> CVApplication { get; set; }
        public DbSet<CVFile> CVFile { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<User> User { get; set; }
    }
}