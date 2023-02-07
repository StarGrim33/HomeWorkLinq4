using System.Xml.Linq;

namespace HomeWorkLinq4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new();
            user.Run();
        }
    }
    
    class Database
    {
        private List<Player> _players = new();

        public Database()
        {
            AddPlayers();
        }

        public void AddPlayers()
        {
            _players = new List<Player>()
            {
                new Player("StarGrim", 80, 10),
                new Player("Kivi", 80, 9),
                new Player("Stars", 25, 2),
                new Player("Manul", 35, 3),
                new Player("Tverq", 70, 6),
                new Player("Yui", 75, 9),
                new Player("Papai", 10, 1),
                new Player("Dereck", 60, 6),
                new Player("Grom", 45, 5),
                new Player("Alex", 40, 4),
            };
        }

        public void TopByLevel()
        {
            int index = 1;
            int count = 3;
            var sortedByLevel = _players.OrderByDescending(player => player.Level).Take(count).ToList();

            foreach(Player player in sortedByLevel)
            {
                Console.WriteLine($"{index}.{player.Name}, уровень: {player.Level}");
                index++;
            }

            Console.ReadKey();
        }

        public void TopByStrength()
        {
            int index = 1;
            int count = 3;
            var sortedByLevel = _players.OrderByDescending(player => player.Strength).Take(count).ToList();

            foreach (Player player in sortedByLevel)
            {
                Console.WriteLine($"{index}.{player.Name}, сила: {player.Strength}");
                index++;
            }

            Console.ReadKey();
        }
    }

    class Player
    {
        public Player(string name, int level, int strength)
        {
            Name = name;
            Level = level;
            Strength = strength;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strength { get; private set; }
    }

    class User
    {
        private Database _database = new();

        public void Run()
        {
            const string CommandShowTopThreePlayersByLevel = "1";
            const string CommandShowTopThreePlayerByStrength = "2";
            const string CommandExit = "3";

            bool isProgramOn = true;

            while (isProgramOn)
            {
                Console.Clear();
                Console.WriteLine($"{CommandShowTopThreePlayersByLevel}-Показать топ 3 по уровню");
                Console.WriteLine($"{CommandShowTopThreePlayerByStrength}-Показать топ 3 по силе");
                Console.WriteLine($"{CommandExit}-Выйти");

                string userInput = Console.ReadLine()!;

                switch (userInput)
                {
                    case CommandShowTopThreePlayersByLevel:
                        _database.TopByLevel();
                        break;

                    case CommandShowTopThreePlayerByStrength:
                        _database.TopByStrength();
                        break;

                    case CommandExit:
                        isProgramOn = false;
                        break;

                    default:
                        Console.WriteLine("Нужно ввести цифру пункта меню");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}