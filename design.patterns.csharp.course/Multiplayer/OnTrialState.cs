using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Multiplayer
{
    public class OnTrialState : IState
    {
        private readonly SubscriptionManager _manager;

        public OnTrialState(SubscriptionManager manager)
        {
            _manager = manager;
        }

        public void Expire()
        {
            Console.WriteLine("Trial expired");
            _manager.CurrentState = new TrialExpiredState(_manager);
        }

        public void Pay()
        {
            Console.WriteLine("Trial expired");
            _manager.CurrentState = new PaidState(_manager);
        }
    }
}
