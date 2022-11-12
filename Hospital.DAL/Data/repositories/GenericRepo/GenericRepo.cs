using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class //T means any object of classs can use
                                                                  //the below methods
    {
        private readonly HospitalDb Context;

        public GenericRepo(HospitalDb context)
        {
            Context = context;
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T? GetbyID(Guid id)
        {

            return Context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity); 
        }
        public void Update(T entity)
        {
          //no need for an action to be done as the EF will track the object 
          //and Set its state to modified and update the DB
        }
        
        public void SaveChanges()// we added this method so all dealing with DB COntext to be done in DAL
        {
            Context.SaveChanges();
        }
    }
}
