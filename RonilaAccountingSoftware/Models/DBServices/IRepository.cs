using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonilaAccountingSoftware.Models.DBServices
{
    internal interface IRepository<T>
    {
        void AddData(T entity);
        void UpdateData(T entity);
        void DeleteData(int Id);
        List<T> GetAll();
        T GetById(int Id);
    }
}
