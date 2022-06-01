using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Events
{
    public class HealthChangedEventArgs : EventArgs
    {
        public int Health { get; private set; }

        public int Damage { get; private set; }

        public HealthChangedEventArgs(int health)
        {
            Health = health;
        }
    }
}
