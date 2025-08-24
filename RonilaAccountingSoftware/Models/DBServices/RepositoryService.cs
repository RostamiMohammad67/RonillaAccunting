using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal class RepositoryService<T>:IRepository<T> where T : class
    {
        private List<T> _items = new List<T>();
        Models.RonilaDBEntities _context;
        public RepositoryService(RonilaDBEntities context)
        {
                _context=context;
        }

        public void AddData(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
           
        }

        public void DeleteData(int Id)
        {
            var Entity = _context.Set<T>().Find(Id);
            if (Entity != null)
            {
                _context.Set<T>().Remove(Entity);
                _context.SaveChanges();
            }
        }

        public void UpdateData(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }
    }
}
