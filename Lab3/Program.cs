using System;
using System.Text;
using System.Threading;
using static System.Console;

namespace LaboratoryWork3
{
    class Program
    {
        private static int ForceParse(string exMessage)
        {
            string inputString;
            int resultInt;

            while (true)
            {
                if (int.TryParse(inputString = StringLimiter(11), out resultInt))
                {
                    WriteLine();
                    return resultInt;
                }

                StringCleaner(inputString);

                ForegroundColor = ConsoleColor.Red;
                Write("\a" + exMessage);
                Thread.Sleep(1250);
                ResetColor();

                StringCleaner(exMessage);
            }
                
        }

        private static string StringLimiter(int limit)
        {
            var resultSB = new StringBuilder(limit);

            while (resultSB.Length < limit)
            {
                var keyPress = ReadKey();

                switch (keyPress.Key)
                {
                    case ConsoleKey.Enter:
                        return resultSB.ToString();

                    case ConsoleKey.Backspace:
                        if (resultSB.Length == 0)
                            break;
                        resultSB.Remove(resultSB.Length - 1, 1);
                        SetCursorPosition(resultSB.Length, CursorTop);
                        Write(' ');
                        SetCursorPosition(resultSB.Length, CursorTop);
                        break;

                    default:
                        resultSB.Append(keyPress.KeyChar);
                        break;
                }
            }

            return resultSB.ToString();
        }

        private static void StringCleaner(string stringToClear)
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

            for (var i = 0; i < 9; i++)
            {
                inputArray[i] = ForceParse("Ошибка ввода!");

                if (inputArray[i] % 5 == 0 && inputArray[i] % 7 != 0)
                {
                    countArrayElements++;
                    sumArrayElements += inputArray[i];
                }
            }

            ForegroundColor = ConsoleColor.Green;
            WriteLine($"\nКоличество: {countArrayElements}\tСумма: {sumArrayElements}");

            ResetColor();
            ReadKey();
        }
    }
}
