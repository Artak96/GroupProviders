using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T:class
    {
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
