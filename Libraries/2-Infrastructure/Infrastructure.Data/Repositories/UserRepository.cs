﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class UserRepository :  IUserRepository
    {
        public UserRepository(IMainDbContext dbContext) 
        {

        }
    }
}
