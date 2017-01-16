using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingMockUps.Models;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Interface
{
    public interface IUserRepository
    {
        ApplicationUser Find(int? id);
        void Delete(int? id);
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser InsertOrUpdate(ApplicationUser user);
    }
}
