using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course
{
    public interface IWeapon
    {
        public int Damage { get; }
        
        /// <summary>
        /// When user uses a weapon over the enemy.
        /// </summary>
        /// <param name="enemy">the enemy</param>
        void Use(IEnemy enemy);
    }
}
