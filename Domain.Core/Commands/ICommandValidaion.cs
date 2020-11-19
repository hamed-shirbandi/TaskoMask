using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskoMask.Domain.Core.Commands
{
    public interface ICommandValidaion
    {
        bool IsValid();
    }
}
