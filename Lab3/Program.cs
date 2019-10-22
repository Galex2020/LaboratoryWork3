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
        // Метод для получения выбора массива.
        // До тех пор, пока не будет дан чёткий выбор.
        private static string GetForcedChoice(string exceptionMessage)
        {
            string inputString;
            char firstChar;

            while (true)
            {
                inputString = ReadLine().ToLower();
                firstChar = inputString[0];

                switch (inputString)
                {
                    case "рандомный":
                        return inputString;

                    case "вводимый":
                        return inputString;

                    default:
                        ForegroundColor = Blue;

                        switch (firstChar)
                        {
                            case 'р':
                                WriteLine("\nВы наверно имели в виду \"Рандомный\"?\n");
                                ResetColor();

                                if (ReadLine().ToLower() == "да")
                                    return "рандомный";
                                break;

                            case 'в':
                                WriteLine("\nВы наверно имели в виду \"Вводимый\"?\n");
                                ResetColor();

                                if (ReadLine().ToLower() == "да")
                                    return "вводимый";
                                break;
                        }

                        ForegroundColor = Red;
                        WriteLine("\a\t" + exceptionMessage + "\n");
                        ResetColor();
                        break;
                }
            }
        }
        
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

                ForegroundColor = Red;
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
            ForegroundColor = Blue;
            WriteLine("Какой вид массива выбрать?\n\"Рандомный\" или \"Вводимый?\"\n");
            ResetColor();

            string arrayChoice = GetForcedChoice("Выберете между \"рандомный\" и \"вводимый\"!");

            int countArrayElements = 0;
            int sumArrayElements = 0;

            switch (arrayChoice)
            {
                case "рандомный":
                    var rand = new Random();
                    int rows = rand.Next(0, 101);

                    var randomArray = new int[rows];

                    for (var i = 0; i < rows; i++)
                    {
                        randomArray[i] = rand.Next(0, 101);

                        // Подсчёт количества и суммы элементов, походящих условию задачи.
                        if (randomArray[i] % 5 == 0 && randomArray[i] % 7 != 0)
                        {
                            countArrayElements++;
                            sumArrayElements += randomArray[i];
                        }
                    }
                    break;

                case "вводимый":
                    ForegroundColor = Blue;
                    WriteLine("\nВведите элементы массива\n");
                    ResetColor();

                    var inputArray = new int[9];

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
                    break;
            }
            
            ForegroundColor = Green;
            WriteLine($"\nКоличество: {countArrayElements}\tСумма: {sumArrayElements}");

            ResetColor();
            ReadKey(true);
        }
    }
}
