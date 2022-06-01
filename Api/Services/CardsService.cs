using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class CardsService : ICardsService
    {
        public IEnumerable<Card> FetchCards()
        {
            return new List<Card>()
            {
                // Changed when we change the way of working
                // thanks to the decorator
                //new Card()
                //{
                //    Attack = 90,
                //    Defense = 80,
                //    Name = "Ultimate Shadow Wraith"
                //},
                //new Card()
                //{
                //    Attack = 64,
                //    Defense = 91,
                //    Name = "Puppet of Doom"
                //},
                //new Card()
                //{
                //    Attack = 77,
                //    Defense = 61,
                //    Name = "Lost Soul"
                //},
                //new Card()
                //{
                //    Attack = 55,
                //    Defense = 57,
                //    Name = "Plague Druid"
                //},
                //new Card()
                //{
                //    Attack = 90,
                //    Defense = 95,
                //    Name = "Rage Dragon"
                //}

                new Card("Ultimate Shadow Wraith", 90, 80),
                new Card("Puppet of Doom", 64, 91),
                new Card("Lost Soul", 77, 61),
                new Card("Plague Druid", 55, 57),
                new Card("Rage Dragon", 90, 95)
            };
        }
    }
}