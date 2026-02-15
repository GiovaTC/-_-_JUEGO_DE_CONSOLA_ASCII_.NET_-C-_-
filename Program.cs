using System;

namespace ascii_terminal_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TERMINAL ASCII GAME";  
            Console.CursorVisible = false;

            Menu.ShowMainMenu();
        }
    }
}
