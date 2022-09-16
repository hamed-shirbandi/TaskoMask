using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.Services.Identity.IntegrationTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Identity.IntegrationTests.UseCases
{
    public class UserLoginUseCaseTest : IClassFixture<UserClassFixture>
    {

        #region Fields

        private readonly UserClassFixture _fixture;

        #endregion

        #region Ctor

        public UserLoginUseCaseTest(UserClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion


        #region Test Methods





        #endregion
    }
}
