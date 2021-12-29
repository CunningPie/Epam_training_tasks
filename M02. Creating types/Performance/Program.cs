using System;
using System.Diagnostics;

namespace Performance
{
    internal class C
    {
        /// <summary>
        /// Поле i для тестирования производительности.
        /// </summary>
        public int i { get; set; }

        /// <summary>
        /// Конструктор класса C, заполняющий поле i новым значением.
        /// </summary>
        public C(int i)
        {
            this.i = i;
        }
    }

    struct S
    {
        /// <summary>
        /// Поле i для тестирования производительности.
        /// </summary>
        public int i { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            C[] classes = new C[100000];
            S[] structs = new S[100000];

            var privateMemorySize = Process.GetCurrentProcess().PrivateMemorySize64;
            for (int j = 0; j < 100000; j++)
                classes[j] = new C(rand.Next());
            var delta = Process.GetCurrentProcess().PrivateMemorySize64 - privateMemorySize;

            Console.WriteLine("Private memory size delta for classes: " + delta);


            privateMemorySize = Process.GetCurrentProcess().PrivateMemorySize64;
            for (int j = 0; j < 100000; j++)
                structs[j].i = rand.Next();
            delta = Process.GetCurrentProcess().PrivateMemorySize64 - privateMemorySize;

            Console.WriteLine("Private memory size delta for structs: " + delta);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            Array.Sort<C>(classes, (x, y) => x.i - y.i);
            sw.Stop();
            Console.WriteLine("Sorting time for classes: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            Array.Sort<S>(structs, (x, y) => x.i - y.i);
            sw.Stop();
            Console.WriteLine("Sorting time for struct: " + sw.Elapsed);

            Console.ReadLine();

        }
    }
}
