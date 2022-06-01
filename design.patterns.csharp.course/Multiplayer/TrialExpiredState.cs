using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Multiplayer
{
    public class TrialExpiredState : IState
    {
        private readonly SubscriptionManager _manager;

        public TrialExpiredState(SubscriptionManager manager)
        {
            this._manager = manager;
        }
        public void Expire()
        {
            throw new InvalidOperationException("Cannot expired an expired subscription");
        }

        public void Pay()
        {
            Console.WriteLine("Paid Membership");
            _manager.CurrentState = new PaidState(_manager);
        }
    }
}
