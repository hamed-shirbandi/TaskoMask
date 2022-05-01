using Suzianna.Core.Screenplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Tests.Acceptance.API.Tasks;
using TaskoMask.Tests.Acceptance.Share.Models;

namespace TaskoMask.Tests.Acceptance.Screenplay
{
    public static class PerformTask
    {
        public static ITask LoginOwnerTask(OwnerLoginDto ownerLoginDto)
        {
            //TODO: dynamic select between api level and ui level 
            return new LoginOwnerAPITask(ownerLoginDto);
        }


        public static ITask RegisterOwnerTask(OwnerRegisterDto ownerRegisterDto)
        {
            //TODO: dynamic select between api level and ui level 
            return new RegisterOwnerApiTask(ownerRegisterDto);
        }
    }
}
