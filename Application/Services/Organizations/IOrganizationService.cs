using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Organizations.Dto;

namespace TaskoMask.Application.Services.Organizations
{
    public interface IOrganizationService
    {
        Task<Result> CreateAsync(OrganizationInput input);
    }
}
