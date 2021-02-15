using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using TestMasivian.Interfaces;
using TestMasivian.Models;

namespace TestMasivian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        public readonly IBetService _betService;
        public BetController(IBetService betService)
        {
            _betService = betService;
        }
        [HttpPost("AddBet")]
        public ActionResult AddBet([FromBody] Bet bet)
        {
            StringValues idUser;
            Request.Headers.TryGetValue("IdUser", out idUser);
            if (idUser != string.Empty)
                if (_betService.AddBet(bet))

                    return Ok("Apuesta realizada correctamente");
                else

                    return Ok("No se realizo la apuesta");
            else

                return Ok("El usuario no se encuentra registrado");
        }
        [HttpGet("GetBets")]
        public List<Bet> GetBets()
        {
            return _betService.GetBets().ToList();
        }
    }
}
