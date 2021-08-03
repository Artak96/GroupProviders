using Core.Entities;
using Core.Interfaces.IRepositories;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ProviderRepository : BaseRepository<Provider>,IProviderRepository
    {
        public ProviderRepository(ApplicationDBContext context) : base(context)
        {

        }

        public override bool Delete(Provider entity)
        {
            try
            {
                context.Find<Provider>(entity).IsDeleted = true;
                context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            } 
        }

        public override Provider Get(int id)
        {
            return context.Set<Provider>().Include(p => p.Group).FirstOrDefault(x => x.Id==id);
        }

        public override IEnumerable<Provider> GetAll()
        {
            return context.Set<Provider>().Include(p=>p.Group).Where(x => x.IsDeleted == false);
        }
    }
}
