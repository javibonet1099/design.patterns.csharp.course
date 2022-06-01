using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.BattleFields
{
    public class VolcanoBattlefield : BattlefieldTemplate
    {
        public override string DescribeClimate()
        {
            return "There's fog and dust everywhere. The heat melts the armor";
        }

        public override string DescribeEffects()
        {
            return "There are flames jumping from underneath";
        }

        public override string DescribeGround()
        {
            return "The ground is rocky and unstable";
        }
    }
}
