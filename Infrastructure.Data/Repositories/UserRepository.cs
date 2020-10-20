using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<Domain.Models.User>, IUserRepository
    {
        public UserRepository()
        {

        }
    }
}
