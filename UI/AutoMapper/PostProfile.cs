using System;
using AutoMapper;
using DAL.Models;
using ListingsManager.ViewModels;

namespace ListingsManager.AutoMapper
{
    public class PostProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<PostViewModel, Post>()
                .ForMember(dst => dst.CreationDate, opt => opt.MapFrom(src => src.CreationDate ?? DateTime.Now));
            CreateMap<Post, PostViewModel>();

            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.AccountType, opt => opt.MapFrom(src => AccountType.Standard))
                .ForMember(dst => dst.AccountStatus, opt => opt.MapFrom(src => AccountStatus.Active));



            // Id = Guid.NewGuid()
        }

    }
}