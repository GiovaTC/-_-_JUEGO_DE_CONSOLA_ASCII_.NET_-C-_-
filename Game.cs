using System;

namespace ascii_terminal_game
{
    public static class Game
    {
        static int width = 40;
        static int height = 20;
        static Player player;
        public static void Start()
        {
            player = new Player(width / 2, height / 2);

            Console.Clear();
            ConsoleKey key;

            do
            {
                DrawGame();
                key = Console.ReadKey(true).Key;
                UpdatePlayer(key);

            } while (key != ConsoleKey.Escape);

            Menu.ShowMainMenu();
        }
        private static void DrawGame()
        {
            throw new NotImplementedException();
        }
        private static void UpdatePlayer(ConsoleKey key)
        {
            throw new NotImplementedException();
        }
    }
}   
