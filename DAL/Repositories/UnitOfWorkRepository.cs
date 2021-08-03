using Core.Interfaces.IRepositories;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository, IDisposable
    {

        private ApplicationDBContext _context;

        public UnitOfWorkRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        private IGroupRepository _group;
        public IGroupRepository Groups => _group ?? (_group = new GroupRepository(_context));

        private IProviderRepository _provider;
        public IProviderRepository Providers => _provider ?? (_provider = new ProviderRepository(_context));

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
