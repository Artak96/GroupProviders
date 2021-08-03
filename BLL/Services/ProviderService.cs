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
    public class ProviderService : BaseService,IProviderService
    {
        public IGroupService groupService;
        public ProviderService(IUnitOfWorkRepository UOW, IMapper mapper,IGroupService groupService) : base(UOW, mapper)
        {
            this.groupService = groupService;
        }
        
        public bool Add(ProviderViewModel model)
        {
            Provider provider = Mapper.Map<ProviderViewModel, Provider>(model);
            provider.CreateDate = DateTime.Now;

            if (UOW.Providers.Add(provider))
            {
                return true;
            }
            return false;

        }

        public bool Delete(int id)
        {
            var provider = UOW.Providers.Get(id);
            if (UOW.Providers.Delete(provider))
            {
                return true;
            }
            return false;
        }

        public ProviderViewModel Get(int id)
        {
            var provider = UOW.Providers.Get(id);
            ProviderViewModel providerViewModel = Mapper.Map<Provider, ProviderViewModel>(provider);

            return providerViewModel;
        }

        public IEnumerable<ProviderViewModel> GetAll()
        {
            var providers = UOW.Providers.GetAll();

            return Mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderViewModel>>(providers);
        }

        public bool Update(ProviderViewModel model)
        {
            Provider provider = Mapper.Map<ProviderViewModel, Provider>(model);

            return UOW.Providers.Update(provider);
        }
    }
}
