# -_-_JUEGO_DE_CONSOLA_ASCII_.NET_-C-_- :.
# 🎮 JUEGO DE CONSOLA ASCII – .NET (C#):

<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/315c65a5-2199-4d4a-b165-1b5234b9f352" />  

Juego de consola estilo **ASCII / terminal**, con **menú interactivo**, inspirado en los clásicos juegos retro en modo texto.
Este proyecto es un **juego completo en .NET (C# – Console App)**, listo para ejecutarse en **Visual Studio 2022** o **JetBrains Rider**.

---

## ✅ Características:

- Pantalla ASCII de inicio  
- Menú navegable con teclado  
- Juego funcional  
- Secciones de ayuda y créditos  
- Código limpio y modular  
- Arquitectura clara y extensible  

---

## 🧱 Tipo de juego:

- Consola  
- ASCII Art  
- Interacción por teclado  
- Estilo retro  

---

## 📁 Estructura del proyecto:
```
AsciiTerminalGame/
│
├── Program.cs
├── Game.cs
├── Menu.cs
├── Screens.cs
└── Player.cs
```
---

## 1️⃣ Program.cs (Punto de entrada):

```csharp
using System;

namespace AsciiTerminalGame
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

2️⃣ Menu.cs (Menú principal)
using System;

namespace AsciiTerminalGame
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
                Console.WriteLine(option == 2 ? ">> Show Credits <<" : "   Show Credits");
                Console.ResetColor();

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow) option = (option + 2) % 3;
                if (key == ConsoleKey.DownArrow) option = (option + 1) % 3;

            } while (key != ConsoleKey.Enter);

            switch (option)
            {
                case 0: Game.Start(); break;
                case 1: Screens.ShowHelp(); break;
                case 2: Screens.ShowCredits(); break;
            }
        }
    }
}

3️⃣ Screens.cs (Pantallas ASCII)
using System;

namespace AsciiTerminalGame
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

        public static void ShowHelp()
        {
            Console.Clear();
            Console.WriteLine("HELP");
            Console.WriteLine("------------------------");
            Console.WriteLine("Use arrow keys to move");
            Console.WriteLine("Avoid obstacles");
            Console.WriteLine("Press ESC to exit game");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
            Menu.ShowMainMenu();
        }

        public static void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("CREDITS");
            Console.WriteLine("------------------------");
            Console.WriteLine("ASCII Terminal Game");
            Console.WriteLine("Developed in C# .NET");
            Console.WriteLine("Author: Your Name");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
            Menu.ShowMainMenu();
        }
    }
}

4️⃣ Player.cs (Jugador)
namespace AsciiTerminalGame
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

5️⃣ Game.cs (Juego principal)
using System;

namespace AsciiTerminalGame
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

            for (int y = 0; y < height; y++)
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

            Console.WriteLine("\nESC to exit");
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

▶️ Cómo ejecutar
Abrir Visual Studio 2022 o JetBrains Rider
Crear un proyecto Console App (.NET)
Copiar los archivos en el proyecto
Ejecutar con Ctrl + F5

🚀 Posibles mejoras
Puntaje y niveles
Enemigos ASCII
Colisiones
Sonido (Console.Beep)

Guardar récords en base de datos (Oracle / SQL Server)

Modo multijugador local / .
