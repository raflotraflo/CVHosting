using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.IRepo
{
    public interface IPlaceRepo
    {
        IQueryable<Place> GetAllPlace();
        Place GetPlaceBuId(int id);
        void AddPlace(Place place);
        void UpdatePlace(Place place);
        void DeletePlace(int id);

        void SaveChanges();
    }
}