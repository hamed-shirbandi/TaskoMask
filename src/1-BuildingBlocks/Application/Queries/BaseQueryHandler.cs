using AutoMapper;

namespace TaskoMask.BuildingBlocks.Application.Queries;

/// <summary>
///
/// </summary>
public abstract class BaseQueryHandler
{
    #region Fields

    protected readonly IMapper _mapper;

    #endregion


    #region Ctors


    protected BaseQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    #endregion


    #region Protected Methods



    #endregion
}
