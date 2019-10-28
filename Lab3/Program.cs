// Дан массив целых чисел М (м1, м2, .., м9).
// Найти количество и сумму тех mi, которые делятся на 5 и не делятся на 7.

using System;
using System.Text;
using System.Threading;
using static System.Console;
using static System.ConsoleColor;

namespace LaboratoryWork3
{
    class Program
    {
        ///<summary>
        /// Метод для получения выбора массива.
        /// До тех пор, пока не будет дан чёткий выбор.
        /// </summary>
        private static string GetForcedChoice(string exceptionMessage)
        {
            string inputString;

            while (true)
            {
                inputString = ReadLine().ToLower();
                
                switch (inputString)
                {
                    case "рандомный":
                        return inputString;

                    case "вводимый":
                        return inputString;

                    default:
                        ForegroundColor = DarkMagenta;

                        if (inputString.StartsWith('р') || inputString.StartsWith('h'))
                        {
                            WriteLine("\nВы наверно имели в виду \"Рандомный\"?\n");
                            ResetColor();

                            if (ReadLine().ToLower() == "да")
                                return "рандомный";
                        }
                        else if (inputString.StartsWith('в') || inputString.StartsWith('d'))
                        {
                            WriteLine("\nВы наверно имели в виду \"Вводимый\"?\n");
                            ResetColor();

                            if (ReadLine().ToLower() == "да")
                                return "вводимый";
                        }

                        ForegroundColor = Red;
                        WriteLine("\a\t" + exceptionMessage + "\n");
                        ResetColor();
                        break;
                }
            }
        }

        /// <summary>
        /// Метод для парсинга string в int.
        /// До тех пор, пока вводимая строка не распарсится.
        /// </summary>
        private static int GetForcedParse(string exceptionMessage, int exceptionMessageShowTime = 1250)
        {
            string inputString;
            int resultInt;

            while (true)
            {
                if (int.TryParse(inputString = GetLimitedString(11), out resultInt))
                {
                    WriteLine();
                    return resultInt;
                }

                ClearString(inputString);

                ForegroundColor = Red;
                Write("\a" + exceptionMessage);
                Thread.Sleep(exceptionMessageShowTime);
                ResetColor();

                ClearString(exceptionMessage);
            }
                
        }

        /// <summary>
        /// Метод для ограничения длинны вводимой строки.
        /// Так же реализует функции клавиш: Enter и Backspace.
        /// </summary>
        private static string GetLimitedString(int limitOfChars)
        {
            var resultStringBuilder = new StringBuilder(limitOfChars);

            while (resultStringBuilder.Length < limitOfChars)
            {
                ConsoleKeyInfo keyPress = ReadKey();

                switch (keyPress.Key)
                {
                    case ConsoleKey.Enter:
                        return resultStringBuilder.ToString();

                    case ConsoleKey.Backspace:
                        if (string.IsNullOrEmpty(resultStringBuilder.ToString()))
                            break;
                        resultStringBuilder.Remove(resultStringBuilder.Length - 1, 1);

                        // Можно заменить на: Write('\b');
                        SetCursorPosition(resultStringBuilder.Length, CursorTop);
                        Write(' ');
                        SetCursorPosition(resultStringBuilder.Length, CursorTop);
                        break;

                    default:
                        resultStringBuilder.Append(keyPress.KeyChar);
                        break;
                }
            }

            return resultStringBuilder.ToString();
        }

        /// <summary>
        /// Метод для стирания строки.
        /// </summary>
        private static void ClearString(string stringToClear)
        {
            // Можно заменить на: Write(new string('\b', stringToClear.Length));
            SetCursorPosition(0, CursorTop);
            Write(new string(' ', stringToClear.Length));
            SetCursorPosition(0, CursorTop);
        }

        static void Main(string[] args)
        {
            ForegroundColor = Blue;
            WriteLine("Какой вид массива выбрать?\n\"Рандомный\" или \"Вводимый?\"\n");
            ResetColor();

            string arrayChoice = GetForcedChoice("Выберете между \"рандомный\" и \"вводимый\"!");

            var startArray = new int[9];
            int countArrayElements = 0;
            int sumArrayElements = 0;

            switch (arrayChoice)
            {
                case "рандомный":
                    WriteLine();

                    var rand = new Random();

                    for (var i = 0; i < 9; i++)
                    {
                        startArray[i] = rand.Next(-100, 101);
                        WriteLine(startArray[i]);
                        Thread.Sleep(250);
                    }
                    break;

                case "вводимый":
                    ForegroundColor = Blue;
                    WriteLine("\nВведите элементы массива\n");
                    ResetColor();

                    // Ввод элементов массива.
                    for (var i = 0; i < 9; i++)
                    {
                        startArray[i] = GetForcedParse("Ошибка ввода!");
                    }
                    break;
            }

            // Подсчёт количества и суммы элементов, походящих условию задачи.
            foreach (var i in startArray)
                if (i % 5 == 0 && i % 7 != 0)
                {
                    countArrayElements++;
                    sumArrayElements += i;
                }

            ForegroundColor = Green;
            WriteLine($"\nКоличество: {countArrayElements}\tСумма: {sumArrayElements}");

            ResetColor();
            ReadKey(true);
        }
    }
}
