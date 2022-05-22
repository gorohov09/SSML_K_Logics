﻿using SSML_K_Logics.K_DigitLogic.Function;
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

        private int _countRow;

        private Dictionary<string, int[]> _variables;

        private Operation _operation;

        private Stack<int[]> _priority;

        public Calculation(int k, int n, Disjunction disjunction, FirstCharacteristicFunction func) 
        { 
            _k = k; 
            _n = n;
            _variables = new Dictionary<string, int[]>();
            _operation = new Operation(disjunction, func);
            _priority = new Stack<int[]>();
            FillArrayVariables();
        }

        public void Calculate(string expression)
        {
            int index_1 = -1; int index_2 = -1;
            index_1 = expression.IndexOf('(');
            index_2 = expression.LastIndexOf(')');
            if (index_1 != -1)
            {
                string new_expr = expression.Substring(index_1 + 1, index_2 - index_1 - 1);
                expression = expression.Replace(expression.Substring(index_1, index_2 - index_1 + 1), "");
                Calculate(new_expr);
            }
            

            if (expression.Contains("v"))
            {
                string[] subExpr = expression.Split('v');
                for (int i = 0; i < subExpr.Length; i++)
                {
                    int constant = 0;
                    if (IsConstants(subExpr[i], out constant))
                    {
                        _variables[subExpr[i]] = new int[_countRow];
                        for (int k = 0; k < _countRow; k++)
                        {
                            _variables[subExpr[i]][k] = constant;
                        }
                        _priority.Push(_variables[subExpr[i]]);
                    }
                }
                for (int i = 0; i < subExpr.Length; i++)
                {
                    int param; string arg;
                    if (IsCharacteristicFunc(subExpr[i], out param, out arg))
                    {
                        _variables[subExpr[i]] = new int[_countRow];
                        for (int k = 0; k < _countRow; k++)
                        {
                            _variables[subExpr[i]] = _operation.FirstCharacteristicFunctionCalculate(_variables[arg], param);
                        }
                        _priority.Push(_variables[subExpr[i]]);
                    }
                }
                for (int i = 0; i < subExpr.Length; i++)
                {
                    string param;
                    if (IsVariable(subExpr[i], out param))
                    {
                        _variables[$"{subExpr[i]}_new"] = new int[_countRow];
                        for (int k = 0; k < _countRow; k++)
                        {
                            _variables[$"{subExpr[i]}_new"] = _variables[param];
                        }
                        _priority.Push(_variables[$"{subExpr[i]}_new"]);
                    }
                }
            }
            else
            {
                int constant = 0;
                int param; string arg;
                if (IsConstants(expression, out constant))
                {
                    _variables[expression] = new int[_countRow];
                    for (int k = 0; k < _countRow; k++)
                    {
                        _variables[expression][k] = constant;
                    }
                    _priority.Push(_variables[expression]);
                }
                else if (IsCharacteristicFunc(expression, out param, out arg))
                {
                    _variables[expression] = new int[_countRow];
                    for (int k = 0; k < _countRow; k++)
                    {
                        _variables[expression] = _operation.FirstCharacteristicFunctionCalculate(_variables[arg], param);
                    }
                    _priority.Push(_variables[expression]);
                }
                else if (IsVariable(expression, out arg))
                {
                    _variables[$"{expression}_new"] = new int[_countRow];
                    for (int k = 0; k < _countRow; k++)
                    {
                        _variables[$"{expression}_new"] = _variables[arg];
                    }
                    _priority.Push(_variables[$"{expression}_new"]);
                }
            }

            while (_priority.Count != 1)
            {
                int[] array1 = _priority.Pop();
                int[] array2 = _priority.Pop();
                int[] result = _operation.DisjuctionCalculate(array1, array2);
                _priority.Push(result);
            }
        }

        private void FillArrayVariables()
        {
            if (_n == 1)
            {
                _variables["x"] = new int[_k];
                for (int i = 0; i < _variables["x"].Length; i++) { _variables["x"][i] = i; }
                _countRow = _k;
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
                _countRow = _k * _k;
            }
        }

        private bool IsConstants(string str, out int constant)
        {
            return int.TryParse(str, out constant);
        }

        private bool IsCharacteristicFunc(string str, out int param, out string arg)
        {
            bool flag = false;
            param = 0;
            arg = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'j')
                {
                    flag = true;
                    param = int.Parse(Convert.ToString(str[i + 2]));
                    arg = Char.ToString(str[i + 4]);
                }
            }

            return flag;
        }

        private bool IsVariable(string str, out string param)
        {
            param = "";
            if (str.Length == 1)
            {
                if (Convert.ToChar(str) == 'x' || Convert.ToChar(str) == 'y')
                {
                    param = str;
                    return true;
                }
            }
            return false;
        }
    }
}
