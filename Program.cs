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
                                  "1 - Найти все четные числа\n" +
                                  "2 - Найти все нечетные числа\n" +
                                  "3 - Найти все числа, сумма первой и последней цифры которых равна 6\n" +
                                  "4 - Найти все числа, содержащие комбинацию цифр: 666\n" +
                                  "11 - PARALLEL| Найти все четные числа\n" +
                                  "12 - PARALLEL| Найти все нечетные числа\n" +
                                  "13 - PARALLEL| Найти все числа, сумма первой и последней цифры которых равна 6\n" +
                                  "14 - PARALLEL| Найти все числа, содержащие комбинацию цифр: 666\n" +
                                  "0 - завершить программу");

                operationType = Convert.ToInt32(Console.ReadLine());
                int[] result;

                Func<int, int, bool> IsEven = (num, index) => num % 2 == 0;
                Func<int, int, bool> IsOdd = (num, index) => num % 2 == 1;
                Func<int, string> NumberToString = s => Convert.ToString(s);
                Func<string, bool> IsFirstPlusLastElemEqualSix= s => Int32.Parse(s[0].ToString()) + Int32.Parse(s[^1].ToString()) == 6;
                Func<string, bool> LengthGT1= s => s.Length > 1;
                Func<string, int> StringToNumber= s => Convert.ToInt32(s);
                Func<string, bool> Contains666= s => s.Contains("666");
                Func<int, int> Ordered= s => s;

                switch (operationType)
                {
                    case 1:
                        result = randArray.Where(IsEven).OrderBy(Ordered).ToArray();
                        foreach (int i in result)
                        {
                            System.Console.WriteLine("{0} ", i);
                        }
                        break;

                    case 2:
                        result = randArray.Where(IsOdd).OrderBy(Ordered).ToArray();
                        foreach (int i in result)
                        {
                            System.Console.WriteLine("{0} ", i);
                        }
                        break;

                    case 3:
                        result = randArray.Select(NumberToString).Where(LengthGT1).Where(IsFirstPlusLastElemEqualSix).Select(StringToNumber).OrderBy(Ordered).ToArray();
                        foreach (int i in result)
                        {
                            System.Console.WriteLine("{0} ", i);
                        }
                        break;

                    case 4:
                        result = randArray.Select(NumberToString).Where(Contains666).Select(StringToNumber).OrderBy(Ordered).ToArray();
                        foreach (int i in result)
                        {
                            System.Console.WriteLine("{0} ", i);
                        }
                        break;

                    case 11:
                        result = randArray.AsParallel().Where(IsEven).OrderBy(Ordered).ToArray();
                        foreach (int i in result)
                        {
                            System.Console.WriteLine("{0} ", i);
                        }
                        break;

                    case 12:
                        result = randArray.AsParallel().Where(IsOdd).OrderBy(Ordered).ToArray();
                        foreach (int i in result)
                        {
                            System.Console.WriteLine("{0} ", i);
                        }
                        break;

                    case 13:
                        result = randArray.AsParallel().Select(NumberToString).Where(LengthGT1).Where(IsFirstPlusLastElemEqualSix).Select(StringToNumber).OrderBy(Ordered).ToArray();
                        foreach (int i in result)
                        {
                            System.Console.WriteLine("{0} ", i);
                        }
                        break;

                    case 14:
                        result = randArray.AsParallel().Select(NumberToString).Where(Contains666).Select(StringToNumber).OrderBy(Ordered).ToArray();
                        foreach (int i in result)
                        {
                            System.Console.WriteLine("{0} ", i);
                        }
                        break;

                    default:
                        break;
                }

            }
        }
    }
}
