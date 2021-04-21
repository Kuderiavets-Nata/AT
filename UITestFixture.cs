using Atata;
using NUnit.Framework;

namespace Lab15
{

    [TestFixture]

    [Parallelizable(ParallelScope.All)]

    public class UITestFixture
    {
        [SetUp]
        public void SetUp()
        {
            AtataContext.Configure().Build();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}