using AutoMapper;
using DAL.Models;
using ListingsManager.ViewModels;

namespace ListingsManager.AutoMapper
{
    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.AccountType, opt => opt.MapFrom(src => AccountType.Standard))
                .ForMember(dst => dst.AccountStatus, opt => opt.MapFrom(src => AccountStatus.Active));
        }
    }
}