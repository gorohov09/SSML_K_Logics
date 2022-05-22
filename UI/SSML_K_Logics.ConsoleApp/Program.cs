using SSML_K_Logics.K_DigitLogic;
using SSML_K_Logics.K_DigitLogic.Function;
using System;

namespace SSML_K_Logics.App.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Disjunction dis = new Disjunction();
            FirstCharacteristicFunction func = new FirstCharacteristicFunction();

            Console.Write("Введите значение k: ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("Введите значение n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите формулу в аналитическом виде: ");
            string expression = Console.ReadLine();

            StringHelper stringHelper = new StringHelper(expression);

            expression = stringHelper.Clear(expression);

            if (stringHelper.IsCorrect(k))
            {
                Calculation calculation = new Calculation(k, n, dis, func);
                calculation.Calculate(expression);
                calculation.PrintTable();
            }
            else
            {

            }
        }
    }
}
