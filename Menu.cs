namespace EditorTextoHtml
{
    public static class Menu
    {
        private const int ScreenWidth = 30;
        private const int ScreenHeight = 10;

        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen();

            // Valida a entrada do usuário antes de continuar
            if (TryGetUserOption(out short option))
            {
                HandleMenuOption(option);
            }
            else
            {
                DisplayError("Entrada inválida. Tente novamente.");
                Show();
            }
        }

        private static void DrawScreen()
        {
            DrawBorder();
            DrawContentArea();
            DrawBorder();
            WriteOptions();
        }

        private static void DrawBorder()
        {
            Console.Write("+");
            Console.Write(new string('-', ScreenWidth));
            Console.WriteLine("+");
        }

        private static void DrawContentArea()
        {
            for (int lines = 0; lines < ScreenHeight; lines++)
            {
                Console.Write("|");
                Console.Write(new string(' ', ScreenWidth));
                Console.WriteLine("|");
            }
        }

        private static void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine(new string('=', ScreenWidth - 6));
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Selecione uma opção abaixo:");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");
        }

        private static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1:
                    Editor.Show();
                    break;

                case 2:
                    Console.Write("Digite o caminho do arquivo: ");
                    string? filePath = Console.ReadLine();

                    if (TryLoadFile(filePath, out string fileContent))
                    {
                        Viewer.Show(fileContent);
                    }
                    else
                    {
                        DisplayError("Erro ao abrir o arquivo. Verifique o caminho e tente novamente.");
                        Console.ReadKey();
                        Show();
                    }
                    break;

                case 0:
                    ExitApplication();
                    break;

                default:
                    DisplayError("Opção inválida. Tente novamente.");
                    Show();
                    break;
            }
        }

        private static bool TryGetUserOption(out short option)
        {
            var input = Console.ReadLine();
            return short.TryParse(input, out option);
        }

        private static bool TryLoadFile(string? path, out string content)
        {
            content = string.Empty;

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return false;

            try
            {
                content = File.ReadAllText(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void DisplayError(string message)
        {
            Console.SetCursorPosition(3, ScreenHeight + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void ExitApplication()
        {
            Console.Clear();
            Console.WriteLine("Saindo do programa. Obrigado por usar o Editor HTML!");
            Environment.Exit(0);
        }
    }
}
