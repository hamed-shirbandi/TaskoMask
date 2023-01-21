using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.Services.Tasks.Read.Api.Domain;

namespace TaskoMask.Services.Tasks.Read.Api.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreationTimeDto, CreationTimeGrpcResponse>()
                .ForMember(dest => dest.CreateDateTime, opt =>
                    opt.MapFrom(src => src.CreateDateTime.ToTimestamp()))
                .ForMember(dest => dest.ModifiedDateTime, opt =>
                    opt.MapFrom(src => src.ModifiedDateTime.ToTimestamp()));

            CreateMap<Task, GetTaskDto>();

            CreateMap<GetTaskDto, GetTaskGrpcResponse>()
            .ForMember(dest => dest.Description, opt =>
                  opt.MapFrom(src => src.Description ?? string.Empty));

            CreateMap<Comment, GetCommentDto>();

            CreateMap<GetCommentDto, GetCommentGrpcResponse>();

            CreateMap<Activity, GetActivityDto>();

            CreateMap<GetActivityDto, GetActivityGrpcResponse>();

            CreateMap<GetCardGrpcResponse, GetCardDto>();

        }
    }
}
