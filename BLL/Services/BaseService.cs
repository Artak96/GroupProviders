using AutoMapper;
using Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BaseService
    {
        public IUnitOfWorkRepository UOW { get; private set; }
        public IMapper Mapper { get; private set; }

        public BaseService(IUnitOfWorkRepository uow, IMapper mapper)
        {
            UOW = uow;
            Mapper = mapper;
        }
    }
}
