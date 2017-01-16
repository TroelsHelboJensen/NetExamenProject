using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Interface
{
    public interface IProgressRepository
    {
        List<ProgressModel> GetAll();
        ProgressModel Find(int? id);
        ProgressModel InsertOrUpdate(ProgressModel progress);
    }
}
