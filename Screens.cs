using System;

namespace ascii_terminal_game
{
    public static class Screens
    {
        public static void DrawTitle()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║  ███████╗███████╗██████╗ ███╗   ███╗ ║");
            Console.WriteLine("║  ██╔════╝██╔════╝██╔══██╗████╗ ████║ ║");
            Console.WriteLine("║  █████╗  █████╗  ██████╔╝██╔████╔██║ ║");
            Console.WriteLine("║  ██╔══╝  ██╔══╝  ██╔══██╗██║╚██╔╝██║ ║");
            Console.WriteLine("║  ██║     ███████╗██║  ██║██║ ╚═╝ ██║ ║");
            Console.WriteLine("║  ╚═╝     ╚══════╝╚═╝  ╚═╝╚═╝         ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        internal static void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("CREDITS");
            Console.WriteLine("------------------------");
            Console.WriteLine("ASCII Terminal Game");
            Console.WriteLine("Developed in c# .NET");
            Console.WriteLine("Author: your Name");
            Console.WriteLine("\npress any key to return... ");
            Console.ReadKey();
            Menu.ShowMainMenu();
        }   

        public static void ShowHelp()
        {
            Console.Clear();
            Console.WriteLine("HELP");
            Console.WriteLine("------------------------");
            Console.WriteLine("Use arrow keys to move");
            Console.WriteLine("avoid obstacles");
            Console.WriteLine("Press ESC to EXIT game");
            Console.WriteLine("\npress any key to return ...");
            Console.ReadKey();
            Menu.ShowMainMenu();
        }
    }
}
