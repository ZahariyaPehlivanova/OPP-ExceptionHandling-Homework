using System;
namespace _01.Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Write a number to calculate its square root:");
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid number");
                }

                Console.WriteLine("Square root of {0} is {1:F3}..",number,Math.Sqrt(number));
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
