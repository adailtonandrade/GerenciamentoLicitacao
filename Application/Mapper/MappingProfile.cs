using Application.ViewModels;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BiddingCreateVM, Bidding>().ReverseMap();
            CreateMap<BiddingDTO, Bidding>().ReverseMap();
        }
    }
}
