﻿using SSML_K_Logics.K_DigitLogic;
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
            Calculation calc = new Calculation(3, 2, dis, func);
            calc.Calculate("(j_1[x]v((j_2[y]vx)vy))");
        }
    }
}
