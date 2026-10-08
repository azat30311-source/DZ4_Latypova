namespace Tumakov
{
    class Tumakov
    {
        #region Вспомогательные методы

        /// <summary>
        /// Безопасный ввод целого числа из консоли.
        /// </summary>
        private static int ReadInt(string message)
        {
            Console.Write(message);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка. Введите корректное цело число.");
                Console.Write(message);
            }
        }

        /// <summary>
        /// Упражнение 5.1. Возвращает наибольшее из двух целых чисел.
        /// </summary>
        private static int GetMax(int a, int b)
        {
            return a > b ? a : b;
        }

        /// <summary>
        /// Упражнение 5.2. Меняет местами значения двух параметров по ссылке.
        /// </summary>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Упражнение 5.3. Вычисляет факториал с проверкой переполнения (checked).
        /// </summary>
        private static bool TryCalculateFactorial(int n, out int result)
        {
            result = 1;
            if (n < 0)
            {
                return false;
            }

            try
            {
                checked
                {
                    for (int i = 2; i <= n; i++)
                    {
                        result *= i;
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                result = 0;
                return false;
            }
        }

        /// <summary>
        /// Упражнение 5.4. Рекурсивный метод вычисления факториала числа.
        /// </summary>
        private static int CalculateFactorialRecursive(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * CalculateFactorialRecursive(n - 1);
        }

        /// <summary>
        /// Домашнее задание 5.1. Вычисляет НОД двух натуральных чисел по алгоритму Евклида.
        /// </summary>
        private static int GetGcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Домашнее задание 5.1. Перегрузка метода для вычисления НОД трех натуральных чисел.
        /// </summary>
        private static int GetGcd(int a, int b, int c)
        {
            return GetGcd(GetGcd(a, b), c);
        }

        /// <summary>
        /// Домашнее задание 5.2. Рекурсивный метод для вычисления n-го числа ряда Фибоначчи.
        /// </summary>
        private static int GetFibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1 || n == 2) return 1;
            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }

        #endregion

        #region Точка входа и выполнение задач

        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();

            Console.ReadKey();
        }

        private static void Task1()
        {
            Console.WriteLine("\t Упражнение 5.1 \t");
            int num1 = ReadInt("Введите первое число: ");
            int num2 = ReadInt("Введите второе число: ");
            Console.WriteLine($"Наибольшее число: {GetMax(num1, num2)}\n");
        }

        private static void Task2()
        {
            Console.WriteLine("\t Упражнение 5.2 \t");
            int a = ReadInt("Введите первое число: ");
            int b = ReadInt("Введите второе число: ");
            Console.WriteLine($"До обмена: a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"После обмена: a = {a}, b = {b}\n");
        }

        private static void Task3()
        {
            Console.WriteLine("\t Упражнение 5.3 \t");
            int n = ReadInt("Введите число для вычисления факториала(в идеале не больше 19): ");
            if (TryCalculateFactorial(n, out int result))
            {
                Console.WriteLine($"Факториал {n}! = {result}\n");
            }
            else
            {
                Console.WriteLine("Ошибка:число вышло за пределы лимита или вы ввели неккоректное число, введите положительное число\n");
            }
        }

        private static void Task4()
        {
            Console.WriteLine("\t Упражнение 5.4 \t");
            int n = ReadInt("Введите число: ");
            Console.WriteLine($"Рекурсивный факториал {n}! = {CalculateFactorialRecursive(n)}\n");
        }

        private static void Task5()
        {
            Console.WriteLine("\t Домашнее задание 5.1 \t");
            int a = ReadInt("Введите первое натуральное число: ");
            int b = ReadInt("Введите второе натуральное число: ");
            int c = ReadInt("Введите третье натуральное число: ");

            Console.WriteLine($"НОД({a}, {b}) = {GetGcd(a, b)}");
            Console.WriteLine($"НОД({a}, {b}, {c}) = {GetGcd(a, b, c)}\n");
        }

        private static void Task6()
        {
            Console.WriteLine("\t Домашнее задание 5.2 \t");
            int n = ReadInt("Введите номер n для ряда Фибоначчи(в идеале не больше 50): ");
            Console.WriteLine($"{n}-е число Фибоначчи = {GetFibonacci(n)}\n");
        }

        #endregion
    }
}
