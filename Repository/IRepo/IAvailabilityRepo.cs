using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.IRepo
{
    public interface IAvailabilityRepo
    {
        IQueryable<Availability> GetAllAvailability();
        Availability GetAvailabilityBuId(int id);
        void AddAvailability(Availability availability);
    }
}