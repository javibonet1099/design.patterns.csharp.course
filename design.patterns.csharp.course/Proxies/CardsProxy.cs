using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace design.patterns.csharp.course.Proxies
{
    public class CardsProxy
    {
        private readonly HttpClient _http;

        private IEnumerable<Card> _cards;

        public CardsProxy()
        {
            this._http = new HttpClient();
        }

        public async Task<IEnumerable<Card>> GetCards() 
        {
            if (_cards != null)
            {
                return _cards;
            }
            else
            {
                await FetchCards();
                return _cards;
            }
        }

        private async Task FetchCards()
        {
            var cardsJson = await _http.GetStringAsync("http://localhost:9913/api/cards");
            _cards = JsonConvert.DeserializeObject<IEnumerable<Card>>(cardsJson).ToArray();
        }
    }
}
