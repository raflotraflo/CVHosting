using System;
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
        CVApplication GetCVApplicationById(int id);
        void AddCVApplication(CVApplication app);
        void UpdateCVApplication(CVApplication app);
        void DeleteCVApplication(int id);

        CVFile GetCVFileById(int id);
        int AddCVFile(CVFile cvFile);

        void SaveChanges();
    }
}