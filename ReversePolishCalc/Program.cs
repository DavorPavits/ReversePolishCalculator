using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Exercise_2_1_2
{
    public static class ReversePolishCalculator
    {
        public static int Compute(string input)
        {
            int number = 0;
            var stack  = new Stack<int>();

            if(string.IsNullOrEmpty(input))
            {
                return number;
            }

            foreach (var token in input.Split())
            {
                if(int.TryParse(token, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    switch (token)
                    {
                        case "+":
                            CheckBinaryOperation(stack, token);
                            stack.Push (stack.Pop() + stack.Pop());
                            break;
                        case "*":
                            CheckBinaryOperation(stack, token);
                            number = stack.Pop();
                            stack.Push(stack.Pop() * stack.Pop());
                            break;
                    }
                }
            }
            return stack.Pop();
        }

        private static void CheckBinaryOperation(Stack<int> stack, string oper)
        {
            if(stack.Count < 2)
            {
                throw new ArgumentException("Missing operands for binary operation" + oper);
            }
        }

        private static void CheckUnaryOperation(Stack<int> stack, string oper)
        {
            if (stack.Count < 1)
            {
                throw new ArgumentException("Missing operands for unary operation" + oper);
            }
        }
    }

}
