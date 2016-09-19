﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.IRepo
{
    public interface ICVApplicationRepo
    {
        IQueryable<CVApplication> GetAllCVs();
        CVFile GetCVFileById(int id);
    }
}