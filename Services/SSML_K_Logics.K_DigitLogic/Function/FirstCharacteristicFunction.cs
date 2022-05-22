using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSML_K_Logics.K_DigitLogic.Function
{
    public class FirstCharacteristicFunction
    {
        private readonly int _i;

        public FirstCharacteristicFunction(int i) { this._i = i; }

        public int Result(int x) => x == _i ? 1 : 0;    
    }
}
