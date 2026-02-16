using AsciiTerminalGame;
using System;

namespace ascii_terminal_game
{
    public static class Menu
    {
        public static void ShowMainMenu()
        {
            int option = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Screens.DrawTitle();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(option == 0 ? ">> Play Game <<" : "   Play Game");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(option == 1 ? ">> Help <<" : "   Help");
                Console.WriteLine(option == 2 ? ">> Show credits <<" : "   Show credits");
                Console.ResetColor();

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow) option = (option + 2) % 3;
                if (key == ConsoleKey.DownArrow) option = (option + 1) % 3;

            } while (key != ConsoleKey.Enter);

            switch (option)
            {
                case 0:
                    Game.Start();
                    break;
                case 1:
                    Screens.ShowHelp();
                    break;
                case 2:
                    Screens.ShowCredits();
                    break;
            }   
        }
    }
}
