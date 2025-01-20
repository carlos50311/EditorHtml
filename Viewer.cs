using System.Text.RegularExpressions;

namespace EditorTextoHtml
{
    public class Viewer
    {
        public static void Show(string file)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Modo Visualização");
            Console.WriteLine("------------");

            // Carrega o conteúdo do arquivo
            if (File.Exists(file))
            {
                string text = File.ReadAllText(file);
                Replace(text); // Processa o texto
            }
            else
            {
                Console.WriteLine("Erro: O arquivo especificado não foi encontrado.");
            }

            Console.WriteLine("------------");
            Console.ReadKey();
            Menu.Show();
        }

        public static void Replace(string text)
        {
            // Define o padrão para encontrar tags <strong>
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>", RegexOptions.IgnoreCase);

            // Divide o texto em palavras
            var words = text.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    // Extrai o conteúdo da tag <strong>
                    var match = strong.Match(words[i]);
                    if (match.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(match.Groups[1].Value); // Exibe o texto dentro da tag <strong>
                        Console.Write(" ");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }

            Console.WriteLine(); // Linha extra para melhor visualização
        }
    }
}
