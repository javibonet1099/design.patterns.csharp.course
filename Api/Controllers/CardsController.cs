using Api.Services;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Cards")]
    public class CardsController : ControllerBase
    {
        private ICardsService _cardsService;

        public CardsController(ICardsService cardsService)
        {
            this._cardsService = cardsService;
        }

        [HttpGet("")]
        public IEnumerable<Card> GetAll()
        {
            return this._cardsService.FetchCards();
        }
    }
}
