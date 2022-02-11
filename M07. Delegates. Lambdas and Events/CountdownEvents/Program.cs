using System;

namespace CountdownEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Countdown countdown = new Countdown();
            EventClassSubscriber subscriber = new EventClassSubscriber(countdown);
            Worker responsibleWorker = new Worker(countdown);
            LazyWorker lazyWorker = new LazyWorker(countdown);

            try
            {
                countdown.StartCountdown(5);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
