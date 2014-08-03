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

            // Id = Guid.NewGuid()
        }

    }
}