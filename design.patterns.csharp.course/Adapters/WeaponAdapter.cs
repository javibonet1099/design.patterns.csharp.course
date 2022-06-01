using design.patterns.csharp.course.LibraryFaked;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Adapters
{
    /// <summary>
    /// Must implement the interface we want to convert
    /// </summary>
    public class WeaponAdapter : IWeapon
    {
        private ISpaceWeapon _spaceWeapon;

        public WeaponAdapter(ISpaceWeapon spaceWeapon)
        {
            this._spaceWeapon = spaceWeapon;
        }
        public int Damage => _spaceWeapon.ImpactDamage + _spaceWeapon.LaserDamage;

        public void Use(IEnemy enemy)
        {
            enemy.Health -= _spaceWeapon.Shoot();
        }
    }
}
