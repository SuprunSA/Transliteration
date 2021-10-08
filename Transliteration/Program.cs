using static System.Console;
using System.Text;

namespace Transliteration
{
    class Program
    {
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
            ReadText();
            Translit();
        }

        static void Translit()
        {
            StringBuilder sb = new StringBuilder(input);
            for (int i = 0; i < trRule.GetUpperBound(0); i++)
            {
                sb.Replace(trRule[i, 0], trRule[i, 1]);
                sb.Replace(trRule[i, 0].ToString().ToUpper(), trRule[i, 1].ToString().ToUpper());
            }
            sb.Replace(firmSign[0], firmSign[1]);
            sb.Replace(firmSign[0].ToUpper(), firmSign[1]);
            WriteLine(sb);
        }

        static string ReadText()
        {
            WriteLine("Введите текст для транслитерации: ");
            input = ReadLine();
            return input;
        }
    }
}
