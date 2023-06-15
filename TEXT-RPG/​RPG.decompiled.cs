using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
[module: RefSafetyRules(11)]
namespace Microsoft.CodeAnalysis
{
    [CompilerGenerated]
    [Embedded]
    internal sealed class EmbeddedAttribute : Attribute
    {
    }
}
namespace System.Runtime.CompilerServices
{
    [CompilerGenerated]
    [Embedded]
    [AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
    internal sealed class RefSafetyRulesAttribute : Attribute
    {
        public readonly int Version;

        public RefSafetyRulesAttribute(int P_0)
        {
            Version = P_0;
        }
    }
}
namespace TextRPG
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Добро пожаловать в текстовую RPG-игру!");
            Player player = new Player("Герой", 100, 10);
            List<Enemy> list = new List<Enemy>();
            list.Add(new Enemy("Гоблин", 50, 5));
            list.Add(new Enemy("Тролль", 60, 8));
            list.Add(new Enemy("Огр", 70, 10));
            List<Enemy> list2 = list;
            Console.WriteLine("Вы оказались в начальной локации.");
            Console.WriteLine("Вокруг вас есть несколько пещер.");
            Console.WriteLine("Выберите пещеру, чтобы войти:");
            int num = 0;
            while (num < list2.Count)
            {
                Console.WriteLine(string.Format("{0}. Пещера {1}", num + 1, num + 1));
                num++;
            }
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result < 1 || result > list2.Count)
            {
                Console.WriteLine("Неправильный выбор. Попробуйте снова.");
            }
            Enemy enemy = list2[result - 1];
            Console.WriteLine(string.Concat("Вы встретили ", enemy.Name, "! Начинается битва!"));
            Battle(player, enemy);
            Console.ReadLine();
        }

        private static void Battle(Player player, Enemy enemy)
        {
            while (player.IsAlive && enemy.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Format("{0}: Здоровье - {1}, Атака - {2}", player.Name, player.Health, player.Attack));
                Console.WriteLine(string.Format("{0}: Здоровье - {1}, Атака - {2}", enemy.Name, enemy.Health, enemy.Attack));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Атаковать");
                Console.WriteLine("2. Бежать");
                string text = Console.ReadLine();
                if (text == "1")
                {
                    AttackPlayer(player, enemy);
                    if (enemy.IsAlive)
                    {
                        AttackEnemy(player, enemy);
                    }
                    continue;
                }
                if (text == "2")
                {
                    Console.WriteLine("Вы сбежали от врага!");
                    break;
                }
                Console.WriteLine("Неправильный выбор. Попробуйте снова.");
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

        private static void AttackPlayer(Player player, Enemy enemy)
        {
            int num = new Random().Next(enemy.Attack - 2, enemy.Attack + 2);
            player.TakeDamage(num);
            Console.WriteLine(string.Format("{0} атаковал {1} и нанес {2} урона!", enemy.Name, player.Name, num));
        }

        private static void AttackEnemy(Player player, Enemy enemy)
        {
            int num = new Random().Next(player.Attack - 2, player.Attack + 2);
            enemy.TakeDamage(num);
            Console.WriteLine(string.Format("{0} атаковал {1} и нанес {2} урона!", player.Name, enemy.Name, num));
        }
    }
    internal class Player
    {
        [CompilerGenerated]
        private readonly string <Name>k__BackingField;

        [CompilerGenerated]
        private int <Health>k__BackingField;

        [CompilerGenerated]
        private readonly int <Attack>k__BackingField;

        public string Name
        {
            [CompilerGenerated]
            get
            {
                return <Name>k__BackingField;
            }
        }

        public int Health
        {
            [CompilerGenerated]
            get
            {
                return <Health>k__BackingField;
            }
            [CompilerGenerated]
            private set
            {
                <Health>k__BackingField = value;
            }
        }

        public int Attack
        {
            [CompilerGenerated]
            get
            {
                return <Attack>k__BackingField;
            }
        }

        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public Player(string name, int health, int attack)
        {
            <Name>k__BackingField = name;
            Health = health;
            <Attack>k__BackingField = attack;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }
    internal class Enemy
    {
        [CompilerGenerated]
        private readonly string <Name>k__BackingField;

        [CompilerGenerated]
        private int <Health>k__BackingField;

        [CompilerGenerated]
        private readonly int <Attack>k__BackingField;

        public string Name
        {
            [CompilerGenerated]
            get
            {
                return <Name>k__BackingField;
            }
        }

        public int Health
        {
            [CompilerGenerated]
            get
            {
                return <Health>k__BackingField;
            }
            [CompilerGenerated]
            private set
            {
                <Health>k__BackingField = value;
            }
        }

        public int Attack
        {
            [CompilerGenerated]
            get
            {
                return <Attack>k__BackingField;
            }
        }

        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public Enemy(string name, int health, int attack)
        {
            <Name>k__BackingField = name;
            Health = health;
            <Attack>k__BackingField = attack;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }
}
