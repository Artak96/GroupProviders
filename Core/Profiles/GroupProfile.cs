using AutoMapper;
using Core.Entities;
using Core.ViewModels;

namespace Core.Profiles
{
    public class GroupProfile : Profile
    {
        public const string ViewModel = "GroupProfile";

        public override string ProfileName => ViewModel;
        public GroupProfile()
        {
            this.CreateMap<GroupViewModel, Group>();
            this.CreateMap<Group, GroupViewModel>();
        }
    }
}
