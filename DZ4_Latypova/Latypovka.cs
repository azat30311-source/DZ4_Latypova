

namespace DZ4_Latypova
{ 
    class Latypovka
    {
        #region Вспомогательные методы

        /// <summary>
        /// Безопасный ввод целого числа.
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
                Console.WriteLine("Ошибка: введите корректное целое число.");
                Console.Write(message);
            }
        }

        /// <summary>
        /// Обмен значений двух элементов массива по ссылке.
        /// </summary>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Задача 2. Вычисляет сумму (return), произведение (ref) и среднее арифметическое (out) массива.
        /// </summary>
        private static int CalculateArrayMetrics(ref int product, out double average, params int[] numbers)
        {
            int sum = 0;
            product = 1;

            if (numbers == null || numbers.Length == 0)
            {
                average = 0;
                product = 0;
                return 0;
            }

            foreach (int num in numbers)
            {
                sum += num;
                product *= num;
            }

            average = (double)sum / numbers.Length;
            return sum;
        }

        /// <summary>
        /// Задача 3. Выводит графическое изображение цифры от 0 до 9 символом #.
        /// </summary>
        private static void PrintDigitArt(int digit)
        {
            string[] art = digit switch
            {
                0 => new[] { " ### ", "#   #", "#   #", "#   #", " ### " },
                1 => new[] { "  #  ", " ##  ", "  #  ", "  #  ", " ### " },
                2 => new[] { " ### ", "    #", " ### ", "#    ", " ### " },
                3 => new[] { " ### ", "    #", " ### ", "    #", " ### " },
                4 => new[] { "#   #", "#   #", " ### ", "    #", "    #" },
                5 => new[] { " ### ", "#    ", " ### ", "    #", " ### " },
                6 => new[] { " ### ", "#    ", " ### ", "#   #", " ### " },
                7 => new[] { " ### ", "    #", "   # ", "  #  ", "  #  " },
                8 => new[] { " ### ", "#   #", " ### ", "#   #", " ### " },
                9 => new[] { " ### ", "#   #", " ### ", "    #", " ### " },
                _ => new string[0]
            };

            foreach (string line in art)
            {
                Console.WriteLine(line);
            }
        }

        #endregion

        #region Точка входа и выполнение задач

        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();

            Console.ReadKey();
        }

        private static void Task1()
        {
            Console.WriteLine("\t Задача 1: Массив из 20 случайных чисел и обмен элементов \t");
            int[] array = new int[20];
            Random rnd = new Random();

            Console.WriteLine("Массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 100);
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine("\n");

            int val1 = ReadInt("Введите первое число из массива: ");
            int val2 = ReadInt("Введите второе число из массива: ");

            int index1 = Array.IndexOf(array, val1);
            int index2 = Array.IndexOf(array, val2);

            if (index1 != -1 && index2 != -1)
            {
                Swap(ref array[index1], ref array[index2]);
                Console.WriteLine("Получившийся массив:");
                foreach (int num in array)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Ошибка: числа или число отсутсвуют в массиве\n");
            }
        }

        private static void Task2()
        {
            Console.WriteLine("\t Задача 2: Работа с params, ref и out \t");
            int product = 1;
            int sum = CalculateArrayMetrics(ref product, out double average, 1, 2, 3, 4, 5);

            Console.WriteLine("Переданный массив: 1, 2, 3, 4, 5");
            Console.WriteLine($"Сумма элементов (возврат): {sum}");
            Console.WriteLine($"Произведение элементов (ref): {product}");
            Console.WriteLine($"Среднее арифметическое (out): {average}\n");
        }

        private static void Task3()
        {
            Console.WriteLine("\t Задача 3 \t");
            Console.WriteLine("Введите цифру от 0 до 9 (для выхода введите 'exit' или 'закрыть'):");

            try
            {
                while (true)
                {
                    Console.Write("\nВвод: ");
                    string input = Console.ReadLine()?.Trim().ToLower();

                    if (input == "exit" || input == "закрыть")
                    {
                        Console.WriteLine("Завершение задачи 3.\n");
                        break;
                    }

                    if (!int.TryParse(input, out int digit))
                    {
                        throw new FormatException("Введена не цифра!");
                    }

                    if (digit >= 0 && digit <= 9)
                    {
                        PrintDigitArt(digit);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("Ошибка! Число должно быть в диапазоне от 0 до 9.");
                        Thread.Sleep(3000);
                        Console.ResetColor();
                        Console.Clear();
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"\n Исключение: {ex.Message} \n");
            }
        }

        private static void Task4()
        {
            Console.WriteLine("\t Задача 4: Структура Дед и подсчет фингалов \t");

            Ded[] deds = new Ded[5];
            deds[0] = new Ded { Name = "Дед Иван", Level = GrumpLevel.High, Phrases = new[] { "Ш общительная!", "Гады!" }, Bruises = 0 };
            deds[1] = new Ded { Name = "Дед Степан", Level = GrumpLevel.Low, Phrases = new[] { "Молодежь нынче не та" }, Bruises = 0 };
            deds[2] = new Ded { Name = "Дед Петр", Level = GrumpLevel.Medium, Phrases = new[] { "Гады!", "Эх, страны нет" }, Bruises = 0 };
            deds[3] = new Ded { Name = "Дед Василий", Level = GrumpLevel.High, Phrases = new[] { "Ш общительная!", "Гады!", "Разворовали все!" }, Bruises = 0 };
            deds[4] = new Ded { Name = "Дед Николай", Level = GrumpLevel.Low, Phrases = new[] { "Погода хорошая" }, Bruises = 0 };

            string[] badWords = { "Ш общительная!", "Гады!" };

            foreach (Ded ded in deds)
            {
                int newBruises = ded.CheckCurses(badWords);
                Console.WriteLine($"{ded.Name} (Ворчливость: {ded.Level}) получил {newBruises} фингалов. Всего фингалов: {ded.Bruises}");
            }
            Console.WriteLine();
        }

        #endregion 
    }
}
