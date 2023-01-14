using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.Services.Tasks.Read.Api.Domain;

namespace TaskoMask.Services.Tasks.Read.Api.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Task, GetTaskDto>();

        }
    }
}
