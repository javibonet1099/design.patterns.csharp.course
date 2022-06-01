using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Commands
{
    public class CardEnemyBattleCommand : ICommand
    {
        private readonly Card _card;
        private readonly IEnemy _enemy;

        public CardEnemyBattleCommand(Card card, IEnemy enemy)
        {
            this._card = card;
            this._enemy = enemy;
        }
        public void Execute()
        {
            this._enemy.Health -= _card.Attack;
        }
    }
}
