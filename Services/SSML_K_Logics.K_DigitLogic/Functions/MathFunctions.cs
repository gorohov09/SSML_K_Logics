using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSML_K_Logics.K_DigitLogic.Functions
{
    public class MathFunctions
    {
        public static int CalculateDisjunction(int x, int y) => Math.Max(x, y);

        public static int CalculateFirstCharFunc(int x, int param) => x == param ? 1 : 0;
    }
}
