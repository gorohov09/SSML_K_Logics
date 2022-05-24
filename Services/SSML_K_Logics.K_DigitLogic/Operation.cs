using SSML_K_Logics.K_DigitLogic.Functions;
using System;

namespace SSML_K_Logics.K_DigitLogic
{
    public class Operation
    {
        public int[] DivCalculate(int[] arg1, int[] arg2)
        {
            int[] result = new int[arg1.Length];
            for (int i = 0; i < arg1.Length; i++)
            {
                result[i] = MathFunctions.CalculateDiv(arg1[i], arg2[i]);
            }
            return result;
        }

        public int[] PostCalculate(int[] arg1, int param)
        {
            int[] result = new int[arg1.Length];
            for (int i = 0; i < arg1.Length; i++)
            {
                result[i] = MathFunctions.CalculatePost(arg1[i], param);
            }
            return result;
        }
    }
}
