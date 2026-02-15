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
            throw new NotImplementedException();
        }

        internal static void ShowHelp()
        {
            throw new NotImplementedException();
        }
    }
}
