using AutoMapper;
using TaskoMask.Application.Commands.Models.Cards;
using TaskoMask.Application.Services.Cards.Dto;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Mapper
{
    public class CardMappingProfile : Profile
    {
        public CardMappingProfile()
        {
            #region Dto To Command

            CreateMap<CardInput, CreateCardCommand>()
              .ConstructUsing(c => new CreateCardCommand(c.Name, c.Description, c.BoardId));

            CreateMap<CardInput, UpdateCardCommand>()
              .ConstructUsing(c => new UpdateCardCommand(c.Id, c.Name, c.Description));


            #endregion

            #region Command To Domain Model

            CreateMap<CreateCardCommand, Card>()
             .ConstructUsing(c => new Card(c.Name.Trim(), c.Description, c.BoardId));

            #endregion

            #region Domain Model To Dto

            CreateMap<Card, CardOutput>();
            CreateMap<Card, CardInput>();


            #endregion

            #region Dto To Dto

            CreateMap<CardOutput, CardInput>();


            #endregion

        }
    }
}
