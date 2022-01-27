using System;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Level newLevel = new Level();
            bool restart = true;
            bool correctInput = false;
            int width = 0;
            int height = 0;

            while (restart)
            {
                while (!correctInput)
                {
                    Console.WriteLine("Input map size. (minimum size is 5x5)");

                    Console.Write("Width: ");
                    int.TryParse(Console.ReadLine(), out width);

                    Console.Write("Height: ");
                    int.TryParse(Console.ReadLine(), out height);

                    correctInput = true;

                    if (height < 5 || width < 5)
                    {
                        Console.WriteLine("Incorrect input!");
                        correctInput = false;
                    }

                    Console.Clear();
                }

                newLevel.GenerateLevel(width, height);
                newLevel.Start();

                Console.WriteLine("Restart?(y/n)");
                restart = Console.ReadKey().KeyChar == 'y';
                Console.Clear();
            }
        }
    }
}
