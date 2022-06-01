using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Multiplayer
{
    public interface IState
    {
        void Expire();

        void Pay();
    }
}
