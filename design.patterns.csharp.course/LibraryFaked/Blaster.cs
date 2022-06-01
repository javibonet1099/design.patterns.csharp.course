using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.LibraryFaked
{
    /// <summary>
    /// Fake class to work with adapter properly.
    /// </summary>
    public class Blaster : ISpaceWeapon
    {
        private int _impactDamage;
        private int _laserDamage;
        private int _missChance;

        public int ImpactDamage { get => _impactDamage; }
        public int LaserDamage { get => _laserDamage; }
        public int MissChance { get => _missChance; }

        public Blaster(int impactDamage, int laserDamage, int missChance)
        {
            this._impactDamage = impactDamage;
            this._laserDamage = laserDamage;
            this._missChance = missChance;
        }

        public int Shoot()
        {
            return ImpactDamage + LaserDamage + MissChance;
        }
    }
}
