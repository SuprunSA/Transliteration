using static System.Console;
using System.Text;
using System;

namespace Transliteration
{
    class Program
    {
        public static int currTranslitIndex = 0;
        static string input = "";

        static char[,] trRule = { { 'б', 'b'}, 
            { 'в', 'v' }, 
            { 'г', 'g' },
            { 'д', 'd' },
            { 'з', 'z' },
            { 'и', 'i' },
            { 'й', 'j' },
            { 'к', 'k' },
            { 'л', 'l' },
            { 'м', 'm' },
            { 'н', 'n' },
            { 'п', 'p' },
            { 'р', 'r' },
            { 'с', 's' },
            { 'т', 't' },
            { 'у', 'u' },
            { 'ф', 'f' },
            { 'х', 'h' },
            { 'ц', 'c' },
            { 'ч', 'č' },
            { 'ш', 'š' },
            { 'щ', 'ŝ' },
            { 'ы', 'y' },
            { 'ь', '`' },
            { 'э', 'è' },
            { 'ю', 'ȗ' },
            { 'я', 'ȃ' }
        };
        static string[] firmSign = { "ъ", "``" };

        static void Main(string[] args)
        {
            DoTranslit();
        }

        static void DoTranslit()
        {
            do
            {
                FindIndex(currTranslitIndex);
                WriteLine("Нажмите любую клавишу, чтобы продолжить, или нажмите для выхода Esc ");
            } while (ReadKey().Key != ConsoleKey.Escape);
        }
        static void Translit(int index)
        {
            WriteLine();
            StringBuilder sb = new StringBuilder(input);
            sb.Replace(firmSign[index], firmSign[Math.Abs(index - 1)]);
            sb.Replace(firmSign[index].ToUpper(), firmSign[Math.Abs(index - 1)]);
            for (int i = 0; i < trRule.GetUpperBound(0) + 1; i++)
            {
                sb.Replace(trRule[i, index], trRule[i, Math.Abs(index - 1)]);
                sb.Replace(trRule[i, index].ToString().ToUpper(), trRule[i, Math.Abs(index - 1)].ToString().ToUpper());
            }
            WriteLine(sb);
        }

        static string ReadText()
        {
            WriteLine("Введите текст для транслитерации: ");
            input = ReadLine();
            return input;
        }

        static int FindIndex(int index)
        {
            Clear();
            WriteLine("Введите F1 для транслитерации кириллицы в латинницу или F2 для транслитерации латинницы в кириллицу ");
            var key = ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.F1:
                    index = 0;
                    Clear();
                    ReadText();
                    Translit(currTranslitIndex);
                    break;
                default:
                    index = 1;
                    Clear();
                    ReadText();
                    Translit(currTranslitIndex);
                    break;
            }
            return index;
        }
    }
}
