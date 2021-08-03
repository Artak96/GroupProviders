using Core.Entities;
using Core.Interfaces.IRepositories;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class GroupRepository : BaseRepository<Group>,IGroupRepository
    {
        public GroupRepository(ApplicationDBContext context) : base(context)
        {

        }

        public override bool Delete(Group entity)
        {
            try
            {
                entity.IsDeleted = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public override IEnumerable<Group> GetAll()
        {
            return context.Set<Group>().Where(x => x.IsDeleted == false);
        }
    }
    
}
