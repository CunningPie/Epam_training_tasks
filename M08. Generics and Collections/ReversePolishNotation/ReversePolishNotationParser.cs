using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    public class ReversePolishNotationParser
    {
        private static Stack<double> _stack = new Stack<double>();

        private static void CalculateOperation(string operation)
        {
            if (_stack.Count < 2)
            {
                throw new ArgumentException(nameof(_stack), "Invalid amount of numbers in stack!");
            }

            double operandA = _stack.Pop();
            double operandB = _stack.Pop();

            switch (operation)
            {
                case "+":
                    _stack.Push(operandB + operandA);
                    break;
                case "-":
                    _stack.Push(operandB - operandA);
                    break;
                case "*":
                    _stack.Push(operandB * operandA);
                    break;
                case "/":
                    _stack.Push(operandB / operandA);
                    break;
                default:
                    throw new ArgumentException("Invalid operation!");
            }
        }

        private static double CalculateExpression(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            string[] exprElements = expression.Split(' ').Where(x => x != "").ToArray();

            if (exprElements.Length == 0)
            {
                return 0;
            }

            foreach (var element in exprElements)
            {
                switch (element)
                {
                    case "+":
                    case "-":
                    case "/":
                    case "*":
                        CalculateOperation(element);
                        break;
                    default:
                        try
                        {
                            _stack.Push(double.Parse(element));
                        }
                        catch (FormatException ex)
                        {
                            throw ex;
                        }
                        catch (OverflowException ex)
                        {
                            throw ex;
                        }
                        catch (ArgumentNullException ex)
                        {
                            throw ex;
                        }
                        break;
                }
            }

            if (_stack.Count == 1)
            {
                return _stack.Pop();
            }
            else
            {
                throw new ArgumentException(nameof(expression), "Invalid expression!");
            }
        }

        /// <summary>
        /// Вычисляет выражение записанное в формате обратной польской записи.
        /// </summary>
        /// <param name="expression">Строка в формате обратной польской записи.</param>
        public static double Calculate(string expression)
        {
            try
            {
                return CalculateExpression(expression);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _stack.Clear();
            }
        }
    }
}
