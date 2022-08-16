using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData
{
    public abstract class TestsBase:IDisposable
    {

        /// <summary>
        /// Run before each test method
        /// </summary>
        public TestsBase()
        {
            FixtureSetup();
        }



        /// <summary>
        /// Each test class should setup its fixture
        /// </summary>
        protected abstract void FixtureSetup();



        /// <summary>
        /// Run after each test method
        /// </summary>
        public void Dispose()
        {

        }
    }
}
