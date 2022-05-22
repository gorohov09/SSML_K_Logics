using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSML_K_Logics.K_DigitLogic
{
    public class Calculation
    {
        /// <summary>
        /// Задание числа k
        /// </summary>
        private readonly int _k;

        /// <summary>
        /// Кол-во существенных переменных k-значной логики
        /// </summary>
        private readonly int _n;

        private Dictionary<string, int[]> _variables;

        public Calculation(int k, int n) 
        { 
            _k = k; 
            _n = n;
            _variables = new Dictionary<string, int[]>();
            FillArrayVariables();
        }

        private void FillArrayVariables()
        {
            if (_n == 1)
            {
                _variables["x"] = new int[_k];
                for (int i = 0; i < _variables["x"].Length; i++) { _variables["x"][i] = i; }
            }
            else
            {
                _variables["x"] = new int[_k*_k];
                _variables["y"] = new int[_k*_k];
                for (int i = 0, index = 0; i < _k; i++)
                {
                    for (int j = 0; j < _k; j++)
                    {
                        _variables["x"][index] = i;
                        _variables["y"][index] = j;
                        index++;
                    }
                }
            }
        }
    }
}
