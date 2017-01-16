using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingMockUps.Interface
{
    /*
     * Generic Interface for both Category and the header. :) 
     */

    public interface ICategoryRepository<T> where T : class
    {
        T Find(int? id);
        IEnumerable<T> GetAll();
        T InsertOrUpdate(T category);
        void Delete(int? id);
    }
}
