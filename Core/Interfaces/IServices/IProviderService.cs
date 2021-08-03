using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.IServices
{
    public interface IProviderService
    {
        public bool Update(ProviderViewModel model);
        public IEnumerable<ProviderViewModel> GetAll();
        public ProviderViewModel Get(int id);
        public bool Delete(int id);
        public bool Add(ProviderViewModel model);
    }
}
