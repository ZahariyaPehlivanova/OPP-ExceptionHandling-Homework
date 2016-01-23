using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start;
            int end;
            int[] array = new int[10];

            ReadStartNumber(out start);

            ReadEndNumber(start, out end);

            int previousNumber = start;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter a number in the range [{0}...{1}].", previousNumber, end);
                array[i] = ReadNumber(start, end, previousNumber);
                previousNumber = array[i];
            }

            Console.WriteLine("Numbers: [{0}]", string.Join(", ", array));
        }

        private static void ReadStartNumber(out int start)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Starting number:");
                    bool validStart = int.TryParse(Console.ReadLine(), out start);

                    if (!validStart)
                    {
                        throw new FormatException();
                    }break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }

        private static void ReadEndNumber(int start, out int end)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("End number:");
                    bool validEnd = int.TryParse(Console.ReadLine(), out end);

                    if (!validEnd)
                    {
                        throw new FormatException();
                    }

                    if (end < start)
                    {
                        throw new IndexOutOfRangeException();
                    }break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number!");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The end number should be equal or bigger than the start number");
                }
            }
        }

        private static int ReadNumber(int start, int end, int previousNumber)
        {
            int currentNumber;

            while (true)
            {
                try
                {
                    bool currNumber = int.TryParse(Console.ReadLine(), out currentNumber);

                    if (!currNumber)
                    {
                        throw new FormatException();
                    }

                    if (currentNumber <= previousNumber)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    if (currentNumber < start || currentNumber > end)
                    {
                        throw new IndexOutOfRangeException();
                    }break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The number you entered is out of range!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The number you entered should be bigger than the previous one!");
                }
            }

            return currentNumber;
        }
    }
}
