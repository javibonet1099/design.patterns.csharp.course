
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course
{
    public interface IEnemy
    {
        public int Health { get; set; }
        public int level { get; }

        #region Added when loose coupling 
        public int OvertimeDamage { get; set; }

        public int Armor { get; set; }

        public bool Paralyzed { get; set; }

        public int ParalizeFor { get; set; }
        #endregion

        //void Attack(PrimaryPlayer player);

        //Change when we use strategy pattern
        int Attack(PrimaryPlayer player);

        void Defend(PrimaryPlayer player);
    }
}
