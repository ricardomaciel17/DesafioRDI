using DesafioRDI.Models;
using DesafioRDI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioRDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : Controller
    {
        [HttpPost]
        public CardResponse CreateCard(CardModel card)
        {
            using (CardContext db = new CardContext())
            {
                card.RegistrationDate = DateTime.UtcNow;
                db.Add(card);
                db.SaveChanges();
            }
            CardResponse response = new CardResponse() { CardId = card.CardId, 
                                                         RegistrationDate = card.RegistrationDate, 
                                                         Token = TokenGenerator.Generator(card.CardNumber, card.CVV) 
                                                       };

            return response;
        }

    }
    public class CardResponse
    {
        public DateTime RegistrationDate { get; set; }
        public long Token { get; set; }
        public int CardId { get; set; }
    }
}
