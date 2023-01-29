using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Interview
{
    class Program
    {
        public static async Task Main(string[] args)
        {

            // Come assegnare il metodo Stampa ad una action?
            //Action<Person> a = Stampa;

            // Scrivere un Func<int, int>
            //Func<int, int> f = (i) => (i*i);

            // Come eseguire il Func?
            //Console.WriteLine( f(2)  );

            // Come eseguire la action?
            //a(new Person() { Name = "Alessandro" });

            //Console.ReadKey();
            var p = GetEnumerator();
            TestAsync();
            while(p.MoveNext())
            {
                Console.WriteLine(p.Current);
            }

            ConstructorQuestion cq = new ConstructorQuestion();
            await cq.Execute3();
            Console.ReadKey();
        }
       

        static IEnumerator<int> GetEnumerator()
        {
            int i = 0;
            while(i < 2)
            {
                yield return i++;
            }
            yield break;
            //Console.WriteLine($"Passo {++i}");
            //Console.WriteLine($"Passo {++i}");
            //yield return 100;
            //Console.WriteLine($"Passo {++i}");
            //Console.WriteLine($"Passo {++i}");
            //yield return 200;
            //Console.WriteLine($"Passo {++i}");
            //Console.WriteLine($"Passo {++i}");
            //yield return 300;
        }

        static void Stampa(Person p)
        {
            Console.WriteLine($"Nome: {p.Name}");
        }


        public static void TestAsync()
        {
            Action<int> job = (int i) =>
            {
                if (i % 100 == 0)
                    throw new TimeoutException();
            };

            var tasks = new Task[1000];
            for (var i = 0; i < 1000; i++)
            {
                var j = i;
                var task = Task.Run(() => job(j));
                // save it
                tasks[i] = task;
            }

            try
            {
                Task.WaitAll(tasks);

            }
            catch (AggregateException e)
            {
                foreach (Exception ex in e.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }
        }
    }

    internal class Person
    {
        internal string Name { get; set; }
        internal string Surname { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname; 
        }
    }
}
