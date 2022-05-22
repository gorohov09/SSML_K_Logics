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
            Calculation calc = new Calculation(4, 1, dis, func);
            calc.Calculate("j_1[x]");
        }
    }
}
