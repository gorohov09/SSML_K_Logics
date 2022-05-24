using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSML_K_Logics.K_DigitLogic.Functions
{
    public class MathFunctions
    {
        public static int CalculateDiv(int x, int y)
        {
            if (x >= y) return x - y;
            else return 0;
        }

        public static int CalculatePost(int x, int param) => (x + 1) % param;
    }
}
