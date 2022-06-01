using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDIDemo
{
    public class ClassB : IInterfaceB
    {
        private readonly IInterfaceA _interfaceA;

        public ClassB(IInterfaceA interfaceA)
        {
            this._interfaceA = interfaceA;
        }
        public void doB()
        {
            this._interfaceA.doA();
            Console.WriteLine("Do B");
        }
    }
}
