﻿using SSML_K_Logics.K_DigitLogic.Functions;
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

        public Calculation(int k, int n) 
        { 
            _k = k; 
            _n = n;
            _variables = new Dictionary<string, int[]>();
            _operation = new Operation();
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

            if (expression.Contains("*"))
            {
                string[] subExpr = expression.Split('*');
                for (int i = 0; i < subExpr.Length; i++)
                {
                    int constant = 0;
                    if (IsConstants(subExpr[i], out constant))
                    {
                        if (constant > 0)
                        {
                            _variables[subExpr[i]] = new int[_countRow];
                            for (int k = 0; k < _countRow; k++)
                            {
                                _variables[subExpr[i]][k] = constant;
                            }
                            _priority.Push(_variables[subExpr[i]]);
                        }
                        else
                        {
                            _variables[subExpr[i][1].ToString()] = new int[_countRow];
                            for (int k = 0; k < _countRow; k++)
                            {
                                _variables[subExpr[i][1].ToString()][k] = MathFunctions.CalculateUnaryNegation(constant, _k);
                            }
                            _priority.Push(_variables[subExpr[i][1].ToString()]);
                        }
                        
                    }
                }
                for (int i = 0; i < subExpr.Length; i++)
                {
                    string arg;
                    if (IsUnaryNegation(subExpr[i], out arg))
                    {
                        _variables[subExpr[i]] = new int[_countRow];
                        for (int k = 0; k < _countRow; k++)
                        {
                            _variables[subExpr[i]] = _operation.UnaryNegationCalculate(_variables[arg], _k);
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
                else if (IsUnaryNegation(expression, out arg))
                {
                    _variables[expression] = new int[_countRow];
                    for (int k = 0; k < _countRow; k++)
                    {
                        _variables[expression] = _operation.UnaryNegationCalculate(_variables[arg], _k);
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
                int[] result = _operation.MultiplicationCalculate(array1, array2, _k);
                _priority.Push(result);
            }

            if (expression.Contains("-") && (expression.Length == 1))
            {
                var arr = _priority.Pop();
                _priority.Push(_operation.UnaryNegationCalculate(arr, _k));
            }
        }

        public string FirstForm => CalculateFirstForm();

        private string CalculateFirstForm()
        {
            return null;
        }

        public string CalculatePreserveSet(IEnumerable<int> hashSet)
        {
            return null;
        }

        public string PrintTable()
        {
            StringBuilder sb = new StringBuilder();
            int[] arrayResult = _priority.Peek();
            if (_n == 1)
            {
                sb.Append("X - Result\n");
                Console.WriteLine("X - Result");
                for (int i = 0; i < _countRow; i++)
                {
                    Console.WriteLine($"{_variables["x"][i]} -    {arrayResult[i]}");
                    sb.Append($"{_variables["x"][i]} -    {arrayResult[i]}\n");
                }
            }
            else
            {
                sb.Append("X - Y - Result\n");
                Console.WriteLine("X - Y - Result");
                for (int i = 0; i < _countRow; i++)
                {
                    Console.WriteLine($"{_variables["x"][i]} - {_variables["y"][i]} -    {arrayResult[i]}");
                    sb.Append($"{_variables["x"][i]} - {_variables["y"][i]} -    {arrayResult[i]}\n");
                }
            }
            return sb.ToString();
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

        private bool IsUnaryNegation(string str, out string arg)
        {
            arg = "";
            bool flag = false;
            if (str.Length == 1 && str.Contains('-'))
                return false;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '-')
                {
                    flag = true;
                    arg = char.ToString(str[i + 1]);
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
