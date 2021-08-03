using AutoMapper;
using Core.Entities;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Profiles
{
    public class ProviderProfile : Profile
    {
        public const string ViewModel = "ProviderProfile";

        public override string ProfileName => ViewModel;
        public ProviderProfile()
        {
            this.CreateMap<ProviderViewModel, Provider>();
            this.CreateMap<Provider,ProviderViewModel>();
        }

    }
}
