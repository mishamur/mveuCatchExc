using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mveuCatchExc
{
    public static class AriphmeticParse
    {
        public static double Parse(string input)
        {
            char operation = ' ';
            int indexOper = 0;
            //ищем операнд
            for (int i = 0; i < input.Length; i++)
            {
                if (isOperation(input[i]))
                {
                    operation = input[i];
                    indexOper = i;
                    break;
                }
            }

            if(indexOper == 0)
            {
                throw new AriphmeticParseException("Некорректный формат входной строки: отсутсвтует операция");
            }


            //слева
            string leftOperand = new string(input.Take(indexOper).ToArray());
            string rightOperand = new string(input.Skip(indexOper + 1).Take(input.Length - indexOper).ToArray());

            double left;
            double right;

            if(!double.TryParse(leftOperand, out left)  || !double.TryParse(rightOperand, out right))
            {
                throw new AriphmeticParseException("Некорректный формат входной строки: неверные операнды");
            }

            double result = 0;

            switch (operation)
            {
                case '-': result = left - right;
                    break;
                case '+':
                    result = left + right;
                    break;
                case '*':
                    result = left * right;
                    break;
                case '/':
                    if(right == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    result = left / right;
                    break;
            }
            
            return result;
        }

        private static bool isOperation(char c) 
        {
            return c switch
            {
                '+' or '-' or '*' or '/' => true,
                _ => false
            };
        }

    }
}
