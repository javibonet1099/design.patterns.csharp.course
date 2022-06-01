using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDIDemo
{
    public class ClassA : IInterfaceA
    {
        public void doA()
        {
            Console.WriteLine("doA");
        }
    }
}
