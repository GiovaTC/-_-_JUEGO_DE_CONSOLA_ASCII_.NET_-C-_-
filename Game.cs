using ascii_terminal_game;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AsciiTerminalGame
{
    public static class Game
    {
        static int width = 40;
        static int height = 20;

        static Player player;
        static List<Enemy> enemies;
        static int score;
        static bool running;
        static Random rnd = new Random();

        public static void Start()
        {
            Console.CursorVisible = false;
            Console.Clear();

            player = new Player(width / 2, height - 2);
            enemies = new List<Enemy>();
            score = 0;
            running = true;

            DateTime lastEnemy = DateTime.Now;
            DateTime lastScore = DateTime.Now;

            while (running)
            {
                HandleInput();
                UpdateEnemies();
                CheckCollisions();
                Draw();

                if ((DateTime.Now - lastEnemy).TotalMilliseconds > 800)
                {
                    enemies.Add(new Enemy(rnd.Next(0, width), 0));
                    lastEnemy = DateTime.Now;
                }

                if ((DateTime.Now - lastScore).TotalMilliseconds > 1000)
                {
                    score += 10;
                    lastScore = DateTime.Now;
                }

                Thread.Sleep(60);
            }

            Screens.GameOver(score);
        }

        static void HandleInput()
        {
            if (!Console.KeyAvailable) return;

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.LeftArrow && player.X > 0)
                player.X--;

            if (key == ConsoleKey.RightArrow && player.X < width - 1)
                player.X++;

            if (key == ConsoleKey.Escape)
                running = false;
        }

        static void UpdateEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Y++;

                if (enemies[i].Y >= height)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }
        }

        static void CheckCollisions()
        {
            foreach (var e in enemies)
            {
                if (e.X == player.X && e.Y == player.Y)
                {
                    running = false;
                    return;
                }
            }
        }

        static void Draw()
        {
            Console.SetCursorPosition(0, 0);

            // HUD
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" SCORE: {score} ");
            Console.ResetColor();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (player.X == x && player.Y == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@");
                    }
                    else if (enemies.Exists(e => e.X == x && e.Y == y))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            Console.ResetColor();
            Console.WriteLine("ESC to exit");
        }
    }
}