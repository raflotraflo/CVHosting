using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class PlaceRepo : IPlaceRepo
    {
        private ICVHostingContext _db;

        public PlaceRepo(ICVHostingContext db)
        {
            _db = db;
        }

        public void AddPlace(Place place)
        {
            _db.Place.Add(place);
        }

        public IQueryable<Place> GetAllPlace()
        {
            return _db.Place.AsNoTracking();
        }

        public Place GetPlaceBuId(int id)
        {
            return _db.Place.Find(id);
        }
    }
}