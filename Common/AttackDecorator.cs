using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AttackDecorator : CardDecorator
    {
        public AttackDecorator(Card card, string name, int attack) : base(card, name, attack, 0)
        {
        }
    }
}
