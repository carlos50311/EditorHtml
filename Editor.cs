using System.Text;

namespace EditorTextoHtml
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Modo Editor");
            Console.WriteLine("------------");
            Start();
        }

        static void Start()
        {
            var file = new StringBuilder();
            Console.WriteLine("Digite seu texto abaixo (pressione ESC para sair):");

            do
            {
                string? line = Console.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    file.AppendLine(line);
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("\n--------------------------");
            Console.WriteLine("Deseja salvar o arquivo? (s/n)");

            string? input;
            do
            {
                input = Console.ReadLine()?.ToLower();
                if (input == "s")
                {
                    Salvar(file.ToString());
                    break;
                }
                else if (input == "n")
                {
                    Console.WriteLine("O arquivo não será salvo.");
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Digite 's' para salvar ou 'n' para descartar.");
                }
            } while (true);
        }

        static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine("Escolha um nome para o arquivo (com extensão, ex.: arquivo.txt):");

            string? path;
            do
            {
                path = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(path))
                {
                    try
                    {
                        using (var file = new StreamWriter(path))
                        {
                            file.Write(texto);
                        }
                        Console.WriteLine($"Arquivo salvo com sucesso em: {Path.GetFullPath(path)}");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao salvar o arquivo: {ex.Message}");
                        Console.WriteLine("Tente novamente com um nome ou caminho válido.");
                    }
                }
                else
                {
                    Console.WriteLine("O nome do arquivo não pode estar vazio. Tente novamente.");
                }
            } while (true);
        }
    }
}
