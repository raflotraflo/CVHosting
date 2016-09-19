using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface ICVHostingContext
    {
        DbSet<Availability> Availability { get; set; }
        DbSet<CVApplication> CVApplication { get; set; }
        DbSet<CVFile> CVFile { get; set; }
        DbSet<Place> Place { get; set; }
        DbSet<User> User { get; set; }

        int SaveChanges();
        DbEntityEntry Entry(object entity);

        Database Database { get; }
    }
}
