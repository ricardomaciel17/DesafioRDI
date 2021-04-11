using DesafioRDI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioRDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : Controller
    {
        [HttpGet]

        public bool GetCardInfo(int cardId, int CustomerId, long token, int CVV)
        {
            CardModel Card = null;
            using (CardContext db = new CardContext())
            {
                Card = db.cards.Where(b => b.CardId == cardId && b.CustomerId == CustomerId).FirstOrDefault();
            }
            if (Card == default(CardModel))
            {
                return false;
            }
            var TimeUsed = DateTime.UtcNow - Card.RegistrationDate;
            if (TimeUsed.Minutes > 30)
            {
                return false;
            }
            Console.WriteLine(Card.CardNumber);

            long dbToken = Services.TokenGenerator.Generator(Card.CardNumber, CVV);

            if (token != dbToken)
            {
                return false;
            }
            return true;
        }
    }
}
