using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Lab1MSTest
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        [ClassInitialize]
        public static void ClassInitialize()
        {
            Console.WriteLine("Hello World");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("Test Ended - " + DateTime.Now);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine("Test Started - " + DateTime.Now);
        }



        //[TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        //             @"/Users/natalia/Projects/Lab1/Lab1MSTest/data.csv", "data#csv", DataAccessMethod.Sequential)]
        //public void TestMethod1()
        //{
        //    int x = Convert.ToInt32(TestContext.DataRow[0]);

        //    Assert.AreEqual(0.17677669529663689, FormulaImplementation.FormulaImpl(x));
        //}

        //[DataRow(33), TestMethod]
        [TestMethod]
        [DataRow(33)]
        [DataTestMethod]
        public void TestMethod2(int x)
        {
         
            Assert.AreEqual(0.17677669529663689, FormulaImplementation.FormulaImpl(x));
        }

        [DataRow(33), Timeout(90), TestMethod]// [TestMethod] [DataRow(5, 1)] [Timeout(1000)]
        public void TestMethod3(int x)
        {
            Thread.Sleep(95);
            Assert.AreEqual(0.17677669529663689, FormulaImplementation.FormulaImpl(x));
        }

        [TestMethod]// [TestMethod]
        public void TestMethod4()
        {
            Random objRan = new Random(5);
            Assert.AreEqual(0.17677669529663689, FormulaImplementation.FormulaImpl(Convert.ToInt32(objRan)));
        }



        [TestCleanup]
        public void TestCleanup()
        {
            Console.WriteLine("Cruel World");
        }
    }
}
