using Aghoosh.Application.Posts.Base.Services;
using Aghoosh.Domain.Posts.Entities;
using AutoMapper;
using MediatR;

namespace Aghoosh.Application.Posts.Notices.Services
{
    public class NoticeService : BasePostService<Notice>, INoticeService
    {
        #region Fields


        #endregion

        #region Ctor

        public NoticeService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        #endregion

        #region Command Services





        #endregion

        #region Query Services




        #endregion
    }
}
