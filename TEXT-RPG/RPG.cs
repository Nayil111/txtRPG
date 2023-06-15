using System;
using System.Collections.Generic;

namespace TextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Добро пожаловать в текстовую RPG-игру!");

            Player player = new Player("Герой", 100, 10);
            List<Enemy> enemies = new List<Enemy>
            {
                new Enemy("Гоблин", 50, 5),
                new Enemy("Тролль", 60, 8),
                new Enemy("Огр", 70, 10)
            };

            Console.WriteLine("Вы оказались в начальной локации.");
            Console.WriteLine("Вокруг вас есть несколько пещер.");
            Console.WriteLine("Выберите пещеру, чтобы войти:");

            for (int i = 0; i < enemies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Пещера {i + 1}");
            }

            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > enemies.Count)
            {
                Console.WriteLine("Неправильный выбор. Попробуйте снова.");
            }

            Enemy enemy = enemies[input - 1];
            Console.WriteLine($"Вы встретили {enemy.Name}! Начинается битва!");

            Battle(player, enemy);

            Console.ReadLine();
        }

        static void Battle(Player player, Enemy enemy)
        {
            while (player.IsAlive && enemy.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{player.Name}: Здоровье - {player.Health}, Атака - {player.Attack}");
                Console.WriteLine($"{enemy.Name}: Здоровье - {enemy.Health}, Атака - {enemy.Attack}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Атаковать");
                Console.WriteLine("2. Бежать");

                string action = Console.ReadLine();
                if (action == "1")
                {
                    AttackPlayer(player, enemy);
                    if (enemy.IsAlive)
                        AttackEnemy(player, enemy);
                }
                else if (action == "2")
                {
                    Console.WriteLine("Вы сбежали от врага!");
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            if (!player.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы проиграли. Игра окончена.");
            }
            else if (!enemy.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вы победили врага. Поздравляю!");
            }
        }

        static void AttackPlayer(Player player, Enemy enemy)
        {
            int damage = new Random().Next(enemy.Attack - 2, enemy.Attack + 2);
            player.TakeDamage(damage);
            Console.WriteLine($"{enemy.Name} атаковал {player.Name} и нанес {damage} урона!");
        }

        static void AttackEnemy(Player player, Enemy enemy)
        {
            int damage = new Random().Next(player.Attack - 2, player.Attack + 2);
            enemy.TakeDamage(damage);
            Console.WriteLine($"{player.Name} атаковал {enemy.Name} и нанес {damage} урона!");
        }
    }

    class Player
    {
        public string Name { get; }
        public int Health { get; private set; }
        public int Attack { get; }

        public bool IsAlive { get { return Health > 0; } }

        public Player(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            Attack = attack;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }
    }

    class Enemy
    {
        public string Name { get; }
        public int Health { get; private set; }
        public int Attack { get; }

        public bool IsAlive { get { return Health > 0; } }

        public Enemy(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            Attack = attack;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }
    }
}
