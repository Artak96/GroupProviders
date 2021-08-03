using Core.Interfaces.IRepositories;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        protected readonly ApplicationDBContext context;
        public BaseRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public bool Add(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public virtual T Get(int id)
        {
            var result = context.Set<T>().Find(id);
            return result;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var result = context.Set<T>().ToList();
            return result;
        }

        public bool Update(T entity)
        {
            try
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
