
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework.Internal;




namespace Lab1Nunit
{

    [TestFixture]
    public class Tests
    {

        private static IEnumerable<int[]> GetTestDataFromCSV()
        {
            using (var csv = new CsvReader(new StreamReader("/Users/natalia/Projects/Lab1/Lab1/data.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    int x = int.Parse(csv[0]);

                    yield return new[] { x };
                }
            }
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine("Hello World");


        }

        [OneTimeTearDown]
        public void OneTimeCleanup()
        {
            Console.WriteLine("Test Ended - " + DateTime.Now);

        }

        [SetUp]
        public void Setup()
        {

            Console.WriteLine("Test Started - " + DateTime.Now);
        }
        [TearDown]
        public void Cleanup()
        {
            Console.WriteLine("Cruel World");

        }




        [Test]
        [TestCaseSource("GetTestDataFromCSV")]
        public void Test1(int x)
        {

            Assert.AreEqual(0.17677669529663689, FormulaImplementation.FormulaImpl(x));
        }


        [Test]
        public void Test2([Random(double.MinValue, Double.MaxValue,3)]
        double x)
        {


            Assert.That(FormulaImplementation.FormulaImpl(x), Is.Not.Null);
        


        }


        [Test]
        [Timeout(90), Retry(5)]
        public void Test3()
        {
            

            Thread.Sleep(95);
            Assert.AreEqual(0.17677669529663689, FormulaImplementation.FormulaImpl(33));

        }

        



        [Test]
        public void Test5()

        {
            Assert.AreEqual(0.17677669529663689, FormulaImplementation.FormulaImpl(33));
        }
       
        

       
    }
}