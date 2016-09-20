using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class CVApplicationRepo : ICVApplicationRepo
    {
        private ICVHostingContext _db;

        public CVApplicationRepo(ICVHostingContext db)
        {
            _db = db;
        }

        public IQueryable<CVApplication> GetAllCVs()
        {
            return _db.CVApplication.AsNoTracking();
        }

        public CVFile GetCVFileById(int id)
        {
            return _db.CVFile.Find(id);
        }
    }
}