using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Card : ICardComponent
    {
        // Change to add decorators
        //public string Name { get; set; }

        //public int Attack { get; set; }

        //public int Defense { get; set; }

        protected string _name;

        protected int _attack;

        protected int _defense;

        public Card(string name, int attack, int defense)
        {
            this._name = name;
            this._attack = attack;
            this._defense = defense;
        }


        // is virtual to be able to be overwritten by the decorator. 
        public virtual string Name
        {
            get
            {
                return _name;
            }
        }

        public virtual int Attack
        {
            get
            {
                return _attack;
            }
        }

        public virtual int Defense
        {
            get
            {
                return _defense;
            }
        }

        public void Add(ICardComponent component)
        {
            throw new InvalidOperationException("Can't call this method on a Card");
        }

        public string Display()
        {
            return $"{_name}: {_attack} / {_defense}";
        }

        public ICardComponent Get(int index)
        {
            throw new InvalidOperationException("Can't call this method on a Card");
        }

        public bool Remove(ICardComponent component)
        {
            throw new InvalidOperationException("Can't call this method on a Card");
        }
    }
}
