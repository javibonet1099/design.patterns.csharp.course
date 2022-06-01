using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course
{
    class IceStaff : IWeapon
    {
        private int _damage;
        private int _paralyzedFor;

        public int Damage => _damage;
        public int ParalyzeFor => _paralyzedFor;

        public int Damaage => throw new NotImplementedException();

        public IceStaff(int damage, int armorDamage)
        {
            this._damage = damage;
            this._paralyzedFor = armorDamage;
        }

        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.Armor -= ParalyzeFor;
        }
    }
}
