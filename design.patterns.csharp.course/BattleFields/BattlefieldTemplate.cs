using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.BattleFields
{
    public abstract class BattlefieldTemplate
    {
        public string DescribeSky()
        {
            return "The Battlefield sky is blue";
        }

        public abstract string DescribeGround();
        public abstract string DescribeClimate();

        public abstract string DescribeEffects();

        public string Describe()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(DescribeSky());
            builder.Append("\r\n");
            builder.Append(DescribeClimate());
            builder.Append("\r\n");
            builder.Append(DescribeEffects());
            builder.Append("\r\n");
            builder.Append(DescribeGround());
            builder.Append("\r\n");

            return builder.ToString();
        }
    }
}
