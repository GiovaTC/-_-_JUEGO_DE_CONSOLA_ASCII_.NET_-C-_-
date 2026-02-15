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
        static void DrawGame()
        {
            Console.Clear();

            for (int y = 0;  y < height;  y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == player.X && y == player.Y)
                        Console.Write("@");
                    else
                        Console.Write("."); 
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nESC to EXIT"); 
        }
        static void UpdatePlayer(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (player.X > 0) player.X--;
                    break;
                case ConsoleKey.RightArrow:
                    if (player.X < width - 1) player.X++;
                    break;
                case ConsoleKey.UpArrow:
                    if (player.Y > 0) player.Y--;
                    break;
                case ConsoleKey.DownArrow:
                    if (player.Y < height - 1) player.Y++;
                    break;
            }
        }
    }
}      
