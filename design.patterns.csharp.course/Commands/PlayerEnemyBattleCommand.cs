using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Commands
{
    public class PlayerEnemyBattleCommand : ICommand
    {
        private PrimaryPlayer _player;

        private IEnemy _enemy;

        public PlayerEnemyBattleCommand(PrimaryPlayer player, IEnemy enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        public void Execute()
        {
            PlayerAttacks();

            if (_enemy.Health >= 0)
            {
                EnemyAttacks();
            }
        }

        private void EnemyAttacks()
        {
            _player.Weapon.Use(_enemy);
        }

        private void PlayerAttacks()
        {
            int damage = _enemy.Attack(_player);
            _player.Hit(damage);
        }
    }
}
