using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public interface IGenericRepo<T> where T : class //constraint on the datatype to be object
    {
        List<T> GetAll();

        T? GetbyID(Guid id);

        void Add(T entity); //entity : object of the generic datatype

        void Update(T entity);
        void Delete(T entity);

        void SaveChanges();
    }
}
