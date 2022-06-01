using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // we create this CardDeck is to create a gallery to display
    // all the cards the user in our case console window.
    public class CardDeck : ICardComponent
    {
        private List<ICardComponent> _components = new List<ICardComponent>();

        public void Add(ICardComponent component)
        {
            _components.Add(component);
        }

        public string Display()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var component in _components)
            {
                builder.Append(component.Display() + "\r\n");    
            }

            return builder.ToString();
        }

        public bool Remove(ICardComponent component)
        {
            return _components.Remove(component);
        }

        ICardComponent ICardComponent.Get(int index)
        {
            return _components[index];
        }
    }
}
