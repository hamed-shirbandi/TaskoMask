using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Application.Projects.Queries.Models
{
    public class GetProjectsCountQuery:IRequest<long>
    {
        public GetProjectsCountQuery()
        {

        }
    }
}
