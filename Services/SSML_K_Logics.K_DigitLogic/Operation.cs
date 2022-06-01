using SSML_K_Logics.K_DigitLogic.Functions;
using System;

namespace SSML_K_Logics.K_DigitLogic
{
    public class Operation
    {
        public int[] MultiplicationCalculate(int[] arg1, int[] arg2, int k)
        {
            int[] result = new int[arg1.Length];
            for (int i = 0; i < arg1.Length; i++)
            {
                result[i] = MathFunctions.CalculateMultiplication(arg1[i], arg2[i], k);
            }
            return result;
        }

        public int[] UnaryNegationCalculate(int[] arg1, int k)
        {
            int[] result = new int[arg1.Length];
            for (int i = 0; i < arg1.Length; i++)
            {
                result[i] = MathFunctions.CalculateUnaryNegation(arg1[i], k);
            }
            return result;
        }
    }
}
