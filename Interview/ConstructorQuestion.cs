using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class ConstructorQuestion
    {
        private static int _testValue;

        public ConstructorQuestion()
        {
            if (_testValue == 0)
            {
                _testValue = 5;
            }
        }

        static ConstructorQuestion()
        {
            if (_testValue == 0)
            {
                _testValue = 10;
            }
        }

        public void Execute()
        {
            if (_testValue == 5)
            {
                _testValue = 6;

            }
            Console.WriteLine($"Valore {_testValue}");
        }

        public void Execute2()
        {
            try
            {
                throw new ApplicationException();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("A");
            }
            catch (Exception)
            {
                Console.WriteLine("B");
            }
            finally
            {
                Console.WriteLine("C");
            }
        }

        public async Task Execute3()
        {
            Console.WriteLine("Before");

            await Task.Delay(5000);

            Console.WriteLine("During");

            Task.Delay(5000);

            Console.WriteLine("After");

        }
    }
}
