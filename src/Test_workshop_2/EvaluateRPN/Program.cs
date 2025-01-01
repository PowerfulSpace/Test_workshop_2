
string expression = "3 4 + 5 *"; // Пример выражения в RPN
double result = EvaluateRPN(expression);
Console.WriteLine($"Результат: {result}");



Console.ReadLine();



double EvaluateRPN(string expression)
{
    Queue<char> @operator = new Queue<char>();
    Queue<int> operand = new Queue<int>();

    for (int i = 0; i < expression.Length; i++)
    {
        if (expression[i] == ' ')
        {
            continue;
        }
        if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
        {
            @operator.Enqueue(expression[i]);
        }
        else
        {
            operand.Enqueue(int.Parse((expression[i].ToString())));
        }
    }

    int result = operand.Dequeue();

    while (operand.Count > 0)
    {
        switch (@operator.Dequeue())
        {
            case '+':
                result += operand.Dequeue();
                break;
            case '-':
                result -= operand.Dequeue();
                break;
            case '*':
                result *= operand.Dequeue();
                break;
            default:
                result /= operand.Dequeue();
                break;
        }
    }


    return result;
}