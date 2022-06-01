using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course
{
    public class Sword : IWeapon
    {
        private int _damage;
        private int _armorDamage;

        public int Damage => _damage;
        public int ArmorDamage => _armorDamage;

        public int Damaage => throw new NotImplementedException();

        public Sword(int damage, int armorDamage)
        {
            this._damage = damage;
            this._armorDamage = armorDamage;
        }

        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.Armor -= ArmorDamage;
        }
    }
}
