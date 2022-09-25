using Microsoft.AspNetCore.Mvc;
using PeselApp.Models;

namespace PeselApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeselController : ControllerBase
    {
        [HttpGet("{pesel}")]
        public ActionResult<PeselResponse> GetCalculatedAge(string pesel)
        {
            pesel = Validator.validatePesel(pesel);
            if (pesel.Any(char.IsLetter))
                return BadRequest(pesel) ;

            int year = Int32.Parse(pesel.Substring(0, 2));
            int age = (DateTime.Now.Year - year) % 100;
            double valueOfPromotion = PeselService.CalculatePromotions(pesel);


            return StatusCode(200, new PeselResponse(age, valueOfPromotion));
        }

        [HttpGet("{name}/{surname}/{pesel}")]
        public ActionResult<string> GetWishes(string name, string surname, string pesel)
        {
            string valid = Validator.validateName(name, surname);
            if (valid != "")
                return BadRequest(valid);

            pesel = Validator.validatePesel(pesel);

            if (pesel.Any(char.IsLetter))
                return BadRequest(pesel);

            int gender = Int32.Parse(pesel.Substring(9, 1));

            if (gender % 2 == 0)
                return StatusCode(200, $"Klientko {name} {surname}! Życzymy Ci sto lat!");
            else
                return StatusCode(200, $"Kliencie {name} {surname}! Życzymy Ci sto lat!");   
        }
    }
}
