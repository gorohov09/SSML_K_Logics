using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSML_K_Logics.K_DigitLogic
{
    public class StringHelper
    {
        private readonly string _stringExpression;

        public StringHelper(string stringExpression)
        {
            _stringExpression = stringExpression;
        }

        public bool IsCorrect(int k) => CheckBrackets() && CheckOperation() && CheckIndex(k);

        private bool CheckBrackets()
        {
            return _stringExpression.Count(ch => ch == '(' || ch == ')') % 2 == 0;
        }

        private bool CheckOperation()
        {
            for (int i = 0; i < _stringExpression.Length; i++)
            {
                if (_stringExpression[i] == 'v' && _stringExpression[i] == 'v')
                    return false;
            }
            return true;
        }

        private bool CheckIndex(int k)
        {
            for (int i = 0; i < _stringExpression.Length; i++)
            {
                if (_stringExpression[i] == 'j')
                {
                    int number = int.Parse(Convert.ToString(_stringExpression[i + 2]));
                    if (number >= k)
                        return false;
                }
            }
            return true;
        }
    }
}
