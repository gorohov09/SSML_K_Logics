using SSML_K_Logics.K_DigitLogic.Function;
using System;

namespace SSML_K_Logics.K_DigitLogic
{
    public class Operation
    {
        private readonly Disjunction _disjunction;

        private readonly FirstCharacteristicFunction _firstCharacteristicFunction;

        public Operation(Disjunction disjunction, FirstCharacteristicFunction firstCharacteristicFunction)
        {
            _disjunction = disjunction;
            _firstCharacteristicFunction = firstCharacteristicFunction;
        }

        public int[] DisjuctionCalculate(int[] arg1, int[] arg2)
        {
            int[] result = new int[arg1.Length];
            for (int i = 0; i < arg1.Length; i++)
            {
                result[i] = _disjunction.Calculate(arg1[i], arg2[i]);
            }
            return result;
        }

        public int[] FirstCharacteristicFunctionCalculate(int[] arg1)
        {
            int[] result = new int[arg1.Length];
            for (int i = 0; i < arg1.Length; i++)
            {
                result[i] = _firstCharacteristicFunction.Calculate(arg1[i]);
            }
            return result;
        }
    }
}
