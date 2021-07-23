using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Application.Organizations.Queries.Models
{
    public class GetOrganizationsCountQuery:IRequest<long>
    {
        public GetOrganizationsCountQuery()
        {

        }
    }
}
