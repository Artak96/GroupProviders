using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.IServices
{
    public interface IGroupService
    {
        public bool Update(GroupViewModel model);
        public IEnumerable<GroupViewModel> GetAll();
        public GroupViewModel Get(int id);
        public bool Delete(int id);
        public bool Add(GroupViewModel model);
    }
}
