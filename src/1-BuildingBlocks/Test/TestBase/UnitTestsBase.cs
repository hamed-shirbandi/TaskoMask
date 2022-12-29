namespace TaskoMask.BuildingBlocks.Test.TestBase
{
    public abstract class UnitTestsBase : IDisposable
    {

        /// <summary>
        /// Run before each test method
        /// </summary>
        public UnitTestsBase()
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
