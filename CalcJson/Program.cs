Calculator calculator = new Calculator();

while (true)
{
    Console.WriteLine("Калькулятор:");
    Console.WriteLine("1. Сложение");
    Console.WriteLine("2. Вычитание");
    Console.WriteLine("3. Умножение");
    Console.WriteLine("4. Деление");
    Console.WriteLine("5. Просмотреть историю операций");
    Console.WriteLine("6. Выйти");
    Console.Write("Выберите действие: ");

    int choice;
    if (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
        continue;
    }

    switch (choice)
    {
        case 1:
            Console.Write("Введите первое число: ");
            double a = ReadDoubleInput();
            Console.Write("Введите второе число: ");
            double b = ReadDoubleInput();
            double sum = calculator.Add(a, b);
            Console.WriteLine($"Результат: {sum}");
            break;

        case 2:
            Console.Write("Введите первое число: ");
            double c = ReadDoubleInput();
            Console.Write("Введите второе число: ");
            double d = ReadDoubleInput();
            double difference = calculator.Subtract(c, d);
            Console.WriteLine($"Результат: {difference}");
            break;

        case 3:
            Console.Write("Введите первое число: ");
            double e = ReadDoubleInput();
            Console.Write("Введите второе число: ");
            double f = ReadDoubleInput();
            double product = calculator.Multiply(e, f);
            Console.WriteLine($"Результат: {product}");
            break;

        case 4:
            Console.Write("Введите делимое: ");
            double dividend = ReadDoubleInput();
            Console.Write("Введите делитель: ");
            double divisor = ReadDoubleInput();
            try
            {
                double quotient = calculator.Divide(dividend, divisor);
                Console.WriteLine($"Результат: {quotient}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case 5:
            List<string> history = calculator.LoadHistoryFromJson();
            Console.WriteLine("История операций:");
            foreach (string operation in history)
            {
                Console.WriteLine(operation);
            }
            break;

        case 6:
            Console.WriteLine("Программа завершена.");
            return;

        default:
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            break;
    }
}

    static double ReadDoubleInput()
{
    double number;
    while (!double.TryParse(Console.ReadLine(), out number))
    {
        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
    }
    return number;
}