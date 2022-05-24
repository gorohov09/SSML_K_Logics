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

        public bool IsCorrect(int k) => 
            CheckBrackets() 
            && CheckOperation() 
            && CheckIndex(k) 
            //&& CheckNumbers(k)
            && !CheckNegativeNumbers();

        public string Clear(string str) => str.Replace(" ", "");

        private bool CheckBrackets()
        {
            return _stringExpression.Count(ch => ch == '(' || ch == ')') % 2 == 0;
        }

        private bool CheckOperation()
        {
            for (int i = 0; i < _stringExpression.Length; i++)
            {
                if (_stringExpression[i] == 'v' && _stringExpression[i+1] == 'v')
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

        //private bool CheckNumbers(int k) => _stringExpression.Where(ch => ch >= '0' && ch <= '9')
        //        .Select(ch => Convert.ToInt32(ch))
        //        .Any(number => number >= k);

        private bool CheckNegativeNumbers() => _stringExpression.Where(ch => ch >= '0' && ch <= '9')
                .Select(ch => Convert.ToInt32(ch))
                .Any(number => number < 0);
    }
}
