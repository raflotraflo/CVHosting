using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class AvailabilityRepo : IAvailabilityRepo
    {
        private ICVHostingContext _db;

        public AvailabilityRepo(ICVHostingContext db)
        {
            _db = db;
        }

        public void AddAvailability(Availability availability)
        {
            _db.Availability.Add(availability);
        }

        public IQueryable<Availability> GetAllAvailability()
        {
            return _db.Availability.AsNoTracking();
        }

        public Availability GetAvailabilityBuId(int id)
        {
            return _db.Availability.Find(id);
        }
    }
}