﻿using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Application.Queries.Models.Organizations
{
    public class GetOrganizationsCountQuery:IRequest<long>
    {
        public GetOrganizationsCountQuery()
        {

        }
    }
}
