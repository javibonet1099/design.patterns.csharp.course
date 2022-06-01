using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Multiplayer
{
    public class PaidState : IState
    {
        private readonly SubscriptionManager _manager;

        public PaidState(SubscriptionManager manager)
        {
            this._manager = manager;
        }
        public void Expire()
        {
            throw new InvalidOperationException("Cannot expire a paid membership");
        }

        public void Pay()
        {
            throw new InvalidOperationException("Cannot pay an already paid service");
        }
    }
}
