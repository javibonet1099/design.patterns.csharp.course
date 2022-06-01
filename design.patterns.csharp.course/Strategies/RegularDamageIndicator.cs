using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Strategies
{
    public class RegularDamageIndicator : IDamageIndicator
    {
        public void NotifyAboutDamage(int health, int damage)
        {
            if (health <= 20)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Player took {damage} damage points, " +
                    $"{health} HP remaining");
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
    }
}
