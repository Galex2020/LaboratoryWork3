// Дан массив целых чисел М (м1, м2, .., м9).
// Найти количество и сумму тех mi, которые делятся на 5 и не делятся на 7.

using System;
using System.Text;
using System.Threading;
using static System.Console;

namespace LaboratoryWork3
{
    class Program
    {
        // Метод для парсинга string в int.
        // До тех пор, пока вводимая строка не распарсится.
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

                ForegroundColor = ConsoleColor.Red;
                Write("\a" + exceptionMessage);
                Thread.Sleep(exceptionMessageShowTime);
                ResetColor();

                ClearString(exceptionMessage);
            }
                
        }

        // Метод для ограничения длинны вводимой строки.
        // Так же реализует функции клавиш: Enter и Backspace.
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

        // Метод для стирания строки.
        // Можно заменить на: Write(new string('\b', stringToClear.Length));
        private static void ClearString(string stringToClear)
        {
            SetCursorPosition(0, CursorTop);
            Write(new string(' ', stringToClear.Length));
            SetCursorPosition(0, CursorTop);
        }

        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("Введите элементы массива\n");
            ResetColor();

            var inputArray = new int[9];
            int countArrayElements = 0;
            int sumArrayElements = 0;

            // Ввод элементов массива.
            for (var i = 0; i < 9; i++)
            {
                inputArray[i] = GetForcedParse("Ошибка ввода!");

                // Подсчёт количества и суммы элементов, походящих условию задачи.
                if (inputArray[i] % 5 == 0 && inputArray[i] % 7 != 0)
                {
                    countArrayElements++;
                    sumArrayElements += inputArray[i];
                }
            }

            ForegroundColor = ConsoleColor.Green;
            WriteLine($"\nКоличество: {countArrayElements}\tСумма: {sumArrayElements}");

            ResetColor();
            ReadKey(true);
        }
    }
}
