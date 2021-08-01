using AutoMapper;
using TaskoMask.Application.Cards.Commands.Models;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class CardMappingProfile : Profile
    {
        public CardMappingProfile()
        {
            #region Dto To Command

            CreateMap<CardInputDto, CreateCardCommand>()
              .ConstructUsing(c => new CreateCardCommand(c.Name, c.Description, c.BoardId,c.Type));

            CreateMap<CardInputDto, UpdateCardCommand>()
              .ConstructUsing(c => new UpdateCardCommand(c.Id, c.Name, c.Description, c.Type));


            #endregion

            #region Command To Domain Model

            CreateMap<CreateCardCommand, Card>()
             .ConstructUsing(c => new Card(c.Name.Trim(), c.Description, c.BoardId, c.Type));

            #endregion

            #region Domain Model To Dto

            CreateMap<Card, CardOutputDto>();
            CreateMap<Card, CardInputDto>();


            #endregion

            #region Dto To Dto

            CreateMap<CardOutputDto, CardInputDto>();


            #endregion

        }
    }
}
