using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSML_K_Logics.K_DigitLogic.Functions
{
    public class MathFunctions
    {
        public static int CalculateMultiplication(int x, int y, int k) => (x * y) % k;

        public static int CalculateUnaryNegation(int x, int k) => x > 0 ? k - x : 0;
    }
}
