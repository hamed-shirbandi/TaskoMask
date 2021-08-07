using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Organizations.Commands.Models;
using TaskoMask.Application.Organizations.Queries.Models;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Data;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Entities;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Projects.Queries.Models;
using TaskoMask.Application.Core.Dtos.Projects;
using System.Linq;

namespace TaskoMask.Application.Organizations.Services
{
    public class OrganizationService : BaseEntityService<Organization>, IOrganizationService
    {
        #region Fields

        #endregion

        #region Ctor

        public OrganizationService(IMediator mediator, IMapper mapper, IDomainNotificationHandler notifications) : base(mediator, mapper, notifications)
        { }

        #endregion

        #region Public Methods


   


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OrganizationDetailViewModel>> GetDetailAsync(string id)
        {
            var organizationQueryResult = await SendQueryAsync(new GetOrganizationByIdQuery(id));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailViewModel>(organizationQueryResult.Errors);


            var projectQueryResult = await SendQueryAsync(new GetProjectsByOrganizationIdQuery(id));
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailViewModel>(projectQueryResult.Errors);


            var organizationReportQueryResult = await SendQueryAsync(new GetOrganizationReportQuery(id));
            if (!organizationReportQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailViewModel>(organizationReportQueryResult.Errors);



            var organizationDetail = new OrganizationDetailViewModel
            {
                Organization = organizationQueryResult.Value,
                Projects = projectQueryResult.Value,
                Reports = organizationReportQueryResult.Value
            };

            return Result.Success(organizationDetail);

        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<OrganizationDetailViewModel>>> GetUserOrganizationsDetailAsync(string userId)
        {
            var organizationQueryResult = await SendQueryAsync(new GetOrganizationsByUserIdQuery(userId));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<IEnumerable<OrganizationDetailViewModel>> (organizationQueryResult.Errors);

            var organizationsDetail = new List<OrganizationDetailViewModel>();

            foreach (var organization in organizationQueryResult.Value)
            {
                var organizationDetailResult = await GetDetailAsync(organization.Id);
                if (!organizationDetailResult.IsSuccess)
                    return Result.Failure<IEnumerable<OrganizationDetailViewModel>>(organizationDetailResult.Errors);

                organizationsDetail.Add(organizationDetailResult.Value);
            }

            return Result.Success(organizationsDetail.AsEnumerable());
        }


        #endregion

        #region Private Methods


        #endregion
    }
}
