using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void AddCVApplication(CVApplication app)
        {
            _db.CVApplication.Add(app);
        }

        public int AddCVFile(CVFile cvFile)
        {

            _db.CVFile.Add(cvFile);
            _db.SaveChanges();

            return cvFile.Id;
        }

        public void DeleteCVApplication(int id)
        {
            //TODO rch - uusunąć plik z bazy 
            var toDelete = _db.CVApplication.Find(id);
            _db.CVApplication.Remove(toDelete);
        }

        public IQueryable<CVApplication> GetAllCVs()
        {
            return _db.CVApplication.Include(c => c.Availability).Include(c => c.Place).AsNoTracking();
        }

        public CVApplication GetCVApplicationById(int id)
        {
            return _db.CVApplication.Find(id);
        }

        public CVFile GetCVFileById(int id)
        {
            return _db.CVFile.Find(id);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void UpdateCVApplication(CVApplication app)
        {
            _db.Entry(app).State = System.Data.Entity.EntityState.Modified;
        }
    }
}