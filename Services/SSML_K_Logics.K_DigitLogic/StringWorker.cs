using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSML_K_Logics.K_DigitLogic
{
    public class StringWorker
    {
        private readonly string _stringExpression;

        public StringWorker(string stringExpression)
        {
            _stringExpression = stringExpression;
        }

        public void Working()
        {
            string[] subExpr = _stringExpression.Split('v');
        }
    }
}
