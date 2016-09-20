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
    public class LoggerContext : IdentityDbContext, ILoggerContext
    {
        public LoggerContext() : base("DefaultConnection")
        {
        }

        public static LoggerContext Create()
        {
            return new LoggerContext();
        }

        public DbSet<MessageLog> MessageLog { get; set; }

    }
}