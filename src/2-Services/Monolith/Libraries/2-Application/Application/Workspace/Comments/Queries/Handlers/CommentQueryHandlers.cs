using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Comments.Queries.Models;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Comments;
using TaskoMask.Services.Monolith.Application.Core.Exceptions;
using TaskoMask.Services.Monolith.Application.Core.Queries;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.Core.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Queries.Handlers
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
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Comment);

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
