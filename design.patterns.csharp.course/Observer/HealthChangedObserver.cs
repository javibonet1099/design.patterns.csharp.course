using design.patterns.csharp.course.Events;
using design.patterns.csharp.course.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Observer
{
    public class HealthChangedObserver
    {
        private IDamageIndicator _strategy;

        public HealthChangedObserver(IDamageIndicator strategy)
        {
            _strategy = strategy;
        }
        public void WatchPlayerHealth(PrimaryPlayer player)
        {
            player.RegisterObserver(Handler);
        } 

        private void Handler(object sender, HealthChangedEventArgs args)
        {
            int damage = args.Damage;
            int health = args.Health;

            _strategy.NotifyAboutDamage(health, damage);
        }
    }
}
