using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.IRepositories
{
    public interface IUnitOfWorkRepository
    {
        IGroupRepository Groups { get; }
        IProviderRepository Providers { get; }

        void SaveChange();
    }
}
