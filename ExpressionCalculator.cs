using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Variant20
{
    /// <summary>
    /// Класс для вычисления арифметических выражений
    /// Поддерживает операции +, -, *, /, ^ и скобки
    /// </summary>
    public static class ExpressionCalculator
    {
        /// <summary>
        /// Вычисляет значение арифметического выражения
        /// </summary>
        /// <param name="expression">Строка с выражением</param>
        /// <returns>Результат вычисления</returns>
        /// <exception cref="ArgumentException">Выбрасывается при ошибках в выражении</exception>
        /// <exception cref="DivideByZeroException">Выбрасывается при делении на ноль</exception>
        public static double Calculate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("Выражение не может быть пустым.");

            // Удаляем все пробелы
            expression = expression.Replace(" ", "");

            // Проверка на недопустимые символы
            if (!IsValidExpression(expression))
                throw new ArgumentException("Выражение содержит недопустимые символы.");

            // Проверка на несбалансированные скобки
            if (!AreParenthesesBalanced(expression))
                throw new ArgumentException("Несбалансированные скобки в выражении.");

            try
            {
                // Преобразуем выражение в список токенов и вычисляем
                var tokens = Tokenize(expression);
                var rpn = ConvertToRPN(tokens);
                return EvaluateRPN(rpn);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is DivideByZeroException)
                    throw;
                throw new ArgumentException($"Ошибка в выражении: {ex.Message}");
            }
        }

        /// <summary>
        /// Проверяет, содержит ли выражение только допустимые символы
        /// </summary>
        private static bool IsValidExpression(string expr)
        {
            return Regex.IsMatch(expr, @"^[0-9+\-*/^().]+$");
        }

        /// <summary>
        /// Проверяет баланс скобок в выражении
        /// </summary>
        private static bool AreParenthesesBalanced(string expr)
        {
            int balance = 0;
            foreach (char c in expr)
            {
                if (c == '(') balance++;
                if (c == ')') balance--;
                if (balance < 0) return false;
            }
            return balance == 0;
        }

        /// <summary>
        /// Разбивает выражение на токены (числа и операторы)
        /// </summary>
        private static List<string> Tokenize(string expr)
        {
            var tokens = new List<string>();
            int i = 0;
            int length = expr.Length;

            while (i < length)
            {
                char current = expr[i];

                // Если число (цифра или точка или знак в начале)
                if (char.IsDigit(current) || current == '.' ||
                    (current == '-' && (i == 0 || expr[i - 1] == '(' || IsOperator(expr[i - 1]))) ||
                    (current == '+' && (i == 0 || expr[i - 1] == '(' || IsOperator(expr[i - 1]))))
                {
                    string number = ParseNumber(expr, ref i);
                    tokens.Add(number);
                }
                else if (IsOperator(current) || current == '(' || current == ')')
                {
                    tokens.Add(current.ToString());
                    i++;
                }
                else
                {
                    throw new ArgumentException($"Недопустимый символ: {current}");
                }
            }

            return tokens;
        }

        /// <summary>
        /// Парсит число из выражения, начиная с позиции i
        /// </summary>
        private static string ParseNumber(string expr, ref int i)
        {
            int start = i;
            bool hasDecimalPoint = false;

            // Если первый символ - знак
            if (expr[i] == '-' || expr[i] == '+')
            {
                i++;
            }

            while (i < expr.Length && (char.IsDigit(expr[i]) || expr[i] == '.'))
            {
                if (expr[i] == '.')
                {
                    if (hasDecimalPoint)
                        throw new ArgumentException("Число содержит более одной десятичной точки.");
                    hasDecimalPoint = true;
                }
                i++;
            }

            return expr.Substring(start, i - start);
        }

        /// <summary>
        /// Проверяет, является ли символ оператором
        /// </summary>
        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
        }

        /// <summary>
        /// Преобразует список токенов в обратную польскую нотацию (алгоритм сортировочной станции)
        /// </summary>
        private static List<string> ConvertToRPN(List<string> tokens)
        {
            var output = new List<string>();
            var stack = new Stack<string>();

            var precedence = new Dictionary<string, int>
            {
                {"+", 1},
                {"-", 1},
                {"*", 2},
                {"/", 2},
                {"^", 3}
            };

            foreach (var token in tokens)
            {
                // Если токен - число
                if (double.TryParse(token, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out _))
                {
                    output.Add(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        output.Add(stack.Pop());
                    }
                    if (stack.Count == 0)
                        throw new ArgumentException("Несбалансированные скобки.");
                    stack.Pop(); // Удаляем "("
                }
                else if (IsOperator(token[0]))
                {
                    while (stack.Count > 0 && stack.Peek() != "(" &&
                           precedence[stack.Peek()] >= precedence[token] && token != "^")
                    {
                        // Для правоассоциативного оператора ^ обрабатываем по-особому
                        if (token == "^" && precedence[stack.Peek()] > precedence[token])
                            break;
                        output.Add(stack.Pop());
                    }
                    stack.Push(token);
                }
            }

            while (stack.Count > 0)
            {
                if (stack.Peek() == "(")
                    throw new ArgumentException("Несбалансированные скобки.");
                output.Add(stack.Pop());
            }

            return output;
        }

        /// <summary>
        /// Вычисляет значение выражения в обратной польской нотации
        /// </summary>
        private static double EvaluateRPN(List<string> rpn)
        {
            var stack = new Stack<double>();
            var culture = System.Globalization.CultureInfo.InvariantCulture;

            foreach (var token in rpn)
            {
                if (double.TryParse(token, System.Globalization.NumberStyles.Any, culture, out double number))
                {
                    stack.Push(number);
                }
                else if (IsOperator(token[0]) && token.Length == 1)
                {
                    if (stack.Count < 2)
                        throw new ArgumentException("Недостаточно операндов для операции.");

                    double b = stack.Pop();
                    double a = stack.Pop();

                    switch (token)
                    {
                        case "+": stack.Push(a + b); break;
                        case "-": stack.Push(a - b); break;
                        case "*": stack.Push(a * b); break;
                        case "/":
                            if (Math.Abs(b) < 1e-10)
                                throw new DivideByZeroException("Деление на ноль.");
                            stack.Push(a / b); break;
                        case "^": stack.Push(Math.Pow(a, b)); break;
                    }
                }
            }

            if (stack.Count != 1)
                throw new ArgumentException("Некорректное выражение.");

            return stack.Pop();
        }
    }
}