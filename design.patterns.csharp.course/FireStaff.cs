using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course
{
    class FireStaff : IWeapon
    {
        private int _damage;
        private int _fireDamage;

        public int Damage => _damage;
        public int FireDamage => _fireDamage;

        public int Damaage => throw new NotImplementedException();

        public FireStaff(int damage, int armorDamage)
        {
            this._damage = damage;
            this._fireDamage = armorDamage;
        }

        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.Armor -= FireDamage;
        }
    }
}
