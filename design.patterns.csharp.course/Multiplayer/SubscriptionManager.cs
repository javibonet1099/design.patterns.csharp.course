using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Multiplayer
{
    public class SubscriptionManager
    {
        public IState CurrentState;

        public SubscriptionManager()
        {
            CurrentState = new OnTrialState(this);
        }

        public void Expire()
        {
            CurrentState.Expire();
        }

        public void Pay()
        {
            CurrentState.Pay();
        }
    }
}
