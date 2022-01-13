using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Common.Queries.Models
{
  public  class GetCountQuery<TEntity>:BaseQuery<long> where TEntity:BaseEntity
    {
        public GetCountQuery()
        {

        }

    }
}
