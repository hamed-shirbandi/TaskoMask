using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Application.Queries.Models.Projects
{
    public class GetProjectsCountQuery:IRequest<long>
    {
        public GetProjectsCountQuery()
        {

        }
    }
}
