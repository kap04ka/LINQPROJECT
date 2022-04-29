using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQPROJECT
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfNumbers;
            Console.WriteLine("Введите количество элементов в массиве");
            amountOfNumbers = Convert.ToInt32(Console.ReadLine());

            int[] randArray = new int[amountOfNumbers];

            Random rand = new Random();

            for (int i = 0; i < randArray.Length; i++)
            {
                randArray[i] = rand.Next(100000);
                Console.WriteLine(randArray[i]);
            }

            int operationType = -1;

            while (operationType != 0)
            {
                Console.WriteLine("Введите номер операции\n" +
                                  "1 - найти все четные числа\n" +
                                  "2 - найти все нечетные числа\n" +
                                  "3 - Найти все числа, сумма первой и последней цифры которых равна 6\n" +
                                  "4 - Найти все числа, содержащие комбинацию цифр: 666\n" +
                                  "0 - завершить программу");

                operationType = Convert.ToInt32(Console.ReadLine());

                switch (operationType)
                {
                    case 1:
                        int[] result_even = randArray.Where((num, index) => num % 2 == 0).OrderBy(num => num).ToArray();
                        foreach (int i in result_even)
                        {
                            System.Console.WriteLine("{0} ", i);
                        }
                        break;

                    case 2:
                        int[] result_odd = randArray.Where((num, index) => num % 2 == 1).OrderBy(num => num).ToArray();
                        foreach (int i in result_odd)
                        {
                            System.Console.WriteLine("{0} ", i);
                        }
                        break;
                    case 3:
                        int[] result_sum_6 = randArray.Select(s => Convert.ToString(s)).Where(s => Int32.Parse(s[0].ToString()) + Int32.Parse(s[^1].ToString()) == 6).Select(s => Convert.ToInt32(s)).OrderBy(s => s).ToArray();
                        foreach (int i in result_sum_6)
                        {
                            System.Console.Write("{0} ", i);
                        }
                        break;
                    case 4:
                        int[] result_contains_666 = randArray.Select(s => Convert.ToString(s)).Where(s => s.Contains("666")).Select(s => Convert.ToInt32(s)).OrderBy(s => s).ToArray();
                        foreach (int i in result_contains_666)
                        {
                            System.Console.Write("{0} ", i);
                        }
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
