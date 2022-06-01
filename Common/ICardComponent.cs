using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface ICardComponent
    {
        void Add(ICardComponent component);

        ICardComponent Get(int index);

        bool Remove(ICardComponent component);

        string Display();
    }
}
