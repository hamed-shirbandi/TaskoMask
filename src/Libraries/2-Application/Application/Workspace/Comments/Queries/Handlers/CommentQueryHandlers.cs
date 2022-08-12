using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Comments.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Comments;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.DataModel.Data;

namespace TaskoMask.Application.Workspace.Comments.Queries.Handlers
{
    public class CommentQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetCommentByIdQuery, CommentBasicInfoDto>,
         IRequestHandler<GetCommentsByTaskIdQuery, IEnumerable<CommentBasicInfoDto>>


    {
        #region Fields

        private readonly ICommentRepository _commentRepository;


        #endregion

        #region Ctors

        public CommentQueryHandlers(ICommentRepository commentRepository, IDomainNotificationHandler notifications, IMapper mapper  ) : base(mapper, notifications)
        {
            _commentRepository = commentRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommentBasicInfoDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            if (comment == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Comment);

            return _mapper.Map<CommentBasicInfoDto>(comment);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<CommentBasicInfoDto>> Handle(GetCommentsByTaskIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetListByTaskIdAsync(request.TaskId);
            return _mapper.Map<IEnumerable<CommentBasicInfoDto>>(comments);
        }



        #endregion
    }
}
