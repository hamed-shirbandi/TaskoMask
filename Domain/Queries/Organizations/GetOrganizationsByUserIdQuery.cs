using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Models;

namespace TaskoMask.Domain.Queries.Organizations
{
   
    public class GetOrganizationsByUserIdQuery : IRequest<Result<Organization>>
    {
    }
}
