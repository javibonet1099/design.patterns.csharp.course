using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Strategies
{
    //define the structure of the strategie
    //it means define every algorithms that belogn  to this  
    public interface IDamageIndicator
    {
        void NotifyAboutDamage(int health, int damage);
    }
}
