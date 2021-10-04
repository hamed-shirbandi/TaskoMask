using AutoMapper;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Domain.TaskManagement.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class CardMappingProfile : Profile
    {
        public CardMappingProfile()
        {
            CreateMap<Card, CardBasicInfoDto>();
            CreateMap<Card, CardInputDto>();
            CreateMap<CardBasicInfoDto, CardInputDto>();
        }
    }
}
