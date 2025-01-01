
string expression = "3 4 + 5 *"; // Пример выражения в RPN
double result = EvaluateRPN(expression);
Console.WriteLine($"Результат: {result}");



Console.ReadLine();



double EvaluateRPN(string expression)
{
    Stack<double> stack = new Stack<double>();
    string[] tokens = expression.Split(' '); // Разделяем выражение на токены

    foreach (string token in tokens)
    {
        if (double.TryParse(token, out double number))
        {
            stack.Push(number); // Если это число, добавляем его в стек
        }
        else
        {
            // Если это оператор, извлекаем два операнда и выполняем операцию
            double b = stack.Pop();
            double a = stack.Pop();

            switch (token)
            {
                case "+":
                    stack.Push(a + b);
                    break;
                case "-":
                    stack.Push(a - b);
                    break;
                case "*":
                    stack.Push(a * b);
                    break;
                case "/":
                    stack.Push(a / b);
                    break;
                default:
                    throw new InvalidOperationException($"Неизвестный оператор: {token}");
            }
        }
    }

    return stack.Pop(); // Последний элемент в стеке — это результат
}