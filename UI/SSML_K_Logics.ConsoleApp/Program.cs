using SSML_K_Logics.K_DigitLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SSML_K_Logics.App.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение k: ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("Введите значение n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите формулу в аналитическом виде: ");
            string expression = Console.ReadLine();

            StringHelper stringHelper = new StringHelper(expression);

            expression = stringHelper.Clear(expression);

            while (true)
            {
                if (stringHelper.IsCorrect(k))
                {
                    Calculation calculation = new Calculation(k, n);
                    calculation.Calculate(expression);
                    calculation.PrintTable();

                    Console.WriteLine("Первая форма:");
                    string first_Form = calculation.FirstForm;
                    Console.WriteLine(first_Form);

                    Console.WriteLine("Принадлежность классу функций, сохраняющих множество E");
                    Console.Write("Введи E = ");
                    IEnumerable<int> numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).Distinct();
                    string inform = calculation.CalculatePreserveSet(numbers);
                    Console.WriteLine(inform);
                    break;

                }
                else
                {
                    Console.WriteLine("Введите корректно формулу!");
                }
            }
            Console.WriteLine("Программа завершила работу!");
        }
    }
}
