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
        public IQueryable<CVApplication> GetAllCVs()
        {
            throw new NotImplementedException();
        }

        public CVFile GetCVFileById(int id)
        {
            throw new NotImplementedException();
        }
    }
}