using AutoMapper;
using Core.Entities;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    
    public class GroupService : BaseService,IGroupService
    {
        public GroupService(IUnitOfWorkRepository UOW,IMapper mapper) : base(UOW,mapper)
        {

        }

        public bool Add(GroupViewModel model)
        {
            Group group = Mapper.Map<GroupViewModel, Group>(model);
            group.CreateDate = DateTime.Now;
            
            if(UOW.Groups.Add(group))
            {
                UOW.SaveChange();
                return true;
            }
            return false;
            
        }

        public bool Delete(int id)
        {
            var group = UOW.Groups.Get(id);
            if (UOW.Groups.Delete(group))
            {
                return true;
            }
            return false;
        }

        public GroupViewModel Get(int id)
        {
            var group = UOW.Groups.Get(id);
            GroupViewModel groupViewModel = Mapper.Map<Group, GroupViewModel>(group);

            return groupViewModel;
        }

        public IEnumerable<GroupViewModel> GetAll()
        {
            var groups = UOW.Groups.GetAll();

            return Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(groups);
        }

        public bool Update(GroupViewModel model)
        {
            Group group = Mapper.Map<GroupViewModel, Group>(model);

            return UOW.Groups.Update(group);
        }
    }
}
