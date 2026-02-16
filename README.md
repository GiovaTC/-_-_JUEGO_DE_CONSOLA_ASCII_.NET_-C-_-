# -_-_JUEGO_DE_CONSOLA_ASCII_.NET_-C-_- :.
# 🎮 JUEGO DE CONSOLA ASCII – .NET (C#):

<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/315c65a5-2199-4d4a-b165-1b5234b9f352" />    

<img width="1280" height="1079" alt="image" src="https://github.com/user-attachments/assets/60327161-e4f1-418e-b0fd-1e9a44839c56" />    

<img width="2551" height="1079" alt="image" src="https://github.com/user-attachments/assets/8e847d84-dcd4-4c93-b35f-208344954b53" />        

<img width="1283" height="1079" alt="image" src="https://github.com/user-attachments/assets/dfe7e10f-367e-4922-a0d6-7a9612d13ca6" />        

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

Modo multijugador local .
--- ---
## PARTE 2
# 🚀 MEJORAS PROPUESTAS – JUEGO ASCII EN CONSOLA (.NET C#)

Documento técnico con **mejoras implementadas**, **nueva lógica de juego** y **código completo**, listo para integrarse en tu proyecto **AsciiTerminalGame**.

---

## ✅ MEJORAS PROPUESTAS (RESUMEN)

✔ Pantalla más centrada  
✔ Movimiento fluido (loop con timer)  
✔ Enemigos dinámicos (`X`)  
✔ Puntaje por supervivencia  
✔ Detección de colisiones  
✔ Estado **Game Over**  
✔ Uso de colores  
✔ HUD (Score / estado del juego)  

---

## 🎮 NUEVA LÓGICA DEL JUEGO

### 📌 Concepto

- El jugador (`@`) se mueve horizontalmente  
- Los enemigos (`X`) caen desde la parte superior  
- Cada segundo sobreviviendo → **+10 puntos**  
- Si un enemigo toca al jugador → **GAME OVER**  

---

## 🧱 NUEVA ESTRUCTURA DEL PROYECTO


AsciiTerminalGame/
│
├── Program.cs
├── Game.cs
├── Player.cs
├── Enemy.cs
├── Menu.cs
└── Screens.cs


---

## 1️⃣ Enemy.cs (NUEVO)

```csharp
namespace AsciiTerminalGame
{
    public class Enemy
    {
        public int X;
        public int Y;

        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
2️⃣ Game.cs (MEJORADO)

⚠️ Reemplaza completamente tu archivo Game.cs por este

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
3️⃣ Screens.cs – GAME OVER

👉 Agrega este método a tu clase Screens

public static void GameOver(int score)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine(" ██████╗  █████╗ ███╗   ███╗███████╗");
    Console.WriteLine("██╔════╝ ██╔══██╗████╗ ████║██╔════╝");
    Console.WriteLine("██║  ███╗███████║██╔████╔██║█████╗  ");
    Console.WriteLine("██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ");
    Console.WriteLine("╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗");
    Console.WriteLine(" ╚═════╝ ╚═╝  ╚═╝╚═╝         ╚══════╝");

    Console.ResetColor();
    Console.WriteLine($"\nFINAL SCORE: {score}");
    Console.WriteLine("\nPress any key to return...");
    Console.ReadKey();

    Menu.ShowMainMenu();
}
🧠 RESULTADO FINAL

Ahora el juego incluye:

✔ Loop real de juego
✔ Enemigos dinámicos
✔ Colisiones reales
✔ Sistema de puntaje
✔ HUD visible
✔ Pantalla Game Over
✔ Movimiento fluido

👉 Esto ya no es un demo: es un juego completo y evaluable.

🔥 SIGUIENTES MEJORAS (OPCIONALES)

Si deseas evolucionarlo aún más:

1️⃣ Niveles de dificultad
2️⃣ Sistema de vidas
3️⃣ Power-ups
4️⃣ Guardar récord (archivo / Oracle / SQL Server)
5️⃣ Sonidos (Console.Beep())
6️⃣ Modo historia ASCII
7️⃣ Documentarlo como proyecto universitario formal

📌 Si quieres, puedo entregarte el proyecto completo documentado (UML + README académico + diagrama de flujo).

podrias ajustar esta estructura :. ## 🧱 NUEVA ESTRUCTURA DEL PROYECTO:

   
AsciiTerminalGame/
│
├── Program.cs
├── Game.cs
├── Player.cs
├── Enemy.cs
├── Menu.cs
└── Screens.cs


---

Claro 👍
Aquí tienes la estructura ajustada y correctamente formateada en Markdown, sin bloques anidados ni errores de renderizado.

🧱 NUEVA ESTRUCTURA DEL PROYECTO
AsciiTerminalGame/
│
├── Program.cs     // Punto de entrada de la aplicación
├── Game.cs        // Lógica principal del juego (loop, colisiones, score)
├── Player.cs      // Entidad jugador (@)
├── Enemy.cs       // Entidad enemigo (X)
├── Menu.cs        // Menú principal y navegación
└── Screens.cs     // Pantallas ASCII (Título, Ayuda, Créditos, Game Over)
✅ Notas de buenas prácticas

La estructura es plana y clara, ideal para proyectos de consola.

Cada archivo cumple una sola responsabilidad (SRP).

Fácil de escalar si luego agregas:

Hud.cs

Level.cs

ScoreService.cs

Persistencia (archivo / BD)
