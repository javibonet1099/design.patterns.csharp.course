using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course
{
    public class Zombie : IEnemy
    {
        private int _health;

        private readonly int _level;
        public int Health { get => _health; set => _health = value; }
        public int level => _level;
        public int OvertimeDamage { get; set; }
        public int Armor { get; set; }
        public bool Paralyzed { get; set; }
        public int ParalizeFor { get; set; }

        public Zombie(int health, int level, int armor)
        {
            _health = health;
            _level = level;
            Armor = armor;
        }

        public int Attack(PrimaryPlayer player)
        {
            Console.WriteLine($"Zombie attacking {player.Name}");

            return 10;
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine($"Zombie defending {player.Name}");
        }
    }
}
