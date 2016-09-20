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
    public interface ILoggerContext
    {
        DbSet<MessageLog> MessageLog { get; set; }

        int SaveChanges();
        DbEntityEntry Entry(object entity);

        Database Database { get; }
    }
}