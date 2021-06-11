using System;
using System.Threading.Tasks;
using Xunit;

namespace Lab1Xunit
{
    public class UnitTest1
    {


        public void Dispose()
        {
            Console.WriteLine("Test Ended" + DateTime.Now);
        }

        [Theory]
        [InlineData(33)]
        public void Test1(int x)
        {

            Console.WriteLine("Test Started - " + DateTime.Now);
            Assert.Equal(0.17677669529663689, FormulaImplementation.FormulaImpl(x));
            Console.WriteLine("Cruel World");
        }


        
        [Fact(Timeout = 10)]
        public async void Test2()
        {
            await Task.Delay(100);
           Console.WriteLine("Test Started - " + DateTime.Now);
            Assert.Equal(0.17677669529663689, FormulaImplementation.FormulaImpl(33);
            Console.WriteLine("Cruel World");


        }

    }
}
