using SSML_K_Logics.K_DigitLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SSML_K_Logics.App.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Горохов Андрей Сергеевич");
            Console.WriteLine("g = 4211");
            Console.WriteLine("n = 5");

            Console.WriteLine($"1: {(4211 + 5 - 1) % 6 + 1}");
            Console.WriteLine($"2: {(4211 + 5 - 1) % 7 + 1}");
            Console.WriteLine($"3: {(4211 + 5 - 1) % 3 + 1}");

            Console.WriteLine("\n");

            Console.Write("Введите значение k: ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("Введите значение n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите формулу в аналитическом виде: ");
            string expression = Console.ReadLine();

            StringHelper stringHelper = new StringHelper(expression);

            expression = stringHelper.Clear(expression);

            Calculation calculation = new Calculation(k, n);
            calculation.Calculate(expression);

            Console.WriteLine(calculation.PrintTable());


            //while (true)
            //{
            //    if (stringHelper.IsCorrect(k))
            //    {
            //        string time = DateTime.Now.ToString();
            //        using (StreamWriter writer = new StreamWriter(Constants.PATH_FILE_TXT, true))
            //        {
            //            writer.WriteLine($"ВРЕМЯ: {time}\n");
            //            writer.WriteLine($"Исходная формула: {expression}\n");
            //        }

            //        Calculation calculation = new Calculation(k, n);
            //        calculation.Calculate(expression);
            //        string information = calculation.PrintTable();
            //        using (StreamWriter writer = new StreamWriter(Constants.PATH_FILE_TXT, true))
            //        {
            //            writer.WriteLine(information);
            //        }

            //        Console.WriteLine("Первая форма:");
            //        string first_Form = calculation.FirstForm;
            //        Console.WriteLine(first_Form);
            //        using (StreamWriter writer = new StreamWriter(Constants.PATH_FILE_TXT, true))
            //        {
            //            writer.WriteLine("Первая форма: ");
            //            writer.WriteLine(first_Form);
            //        }

            //        Console.WriteLine("Принадлежность классу функций, сохраняющих множество E: ");
            //        Console.Write("Введи E = ");
            //        IEnumerable<int> numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).Distinct();
            //        string inform = calculation.CalculatePreserveSet(numbers);
            //        Console.WriteLine(inform);
            //        using (StreamWriter writer = new StreamWriter(Constants.PATH_FILE_TXT, true))
            //        {
            //            writer.WriteLine("Принадлежность классу функций, сохраняющих множество E: ");
            //            writer.WriteLine(inform);
            //            writer.WriteLine("\n");
            //        }
            //        break;

            //    }
            //    else
            //    {
            //        Console.WriteLine("Введите корректно формулу!");
            //    }
            //}
            //Console.WriteLine("Программа завершила работу!");

            //Console.WriteLine("dddd");
            //Console.WriteLine("dddd");
            //Console.WriteLine("dddd");
            //Console.WriteLine("dddd");
            //Console.WriteLine("dddd");
        }
    }
}
