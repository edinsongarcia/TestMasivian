using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasivian.Interfaces;
using TestMasivian.Models;

namespace TestMasivian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        public readonly IRouletteService _rouletteService;
        public readonly IBetService _betService;
        public RouletteController(IRouletteService rouletteService, IBetService betService)
        {
            _rouletteService = rouletteService;
            _betService = betService;
        }

        [HttpGet("GetRoulettes")]
        public List<Roulette> GetRoulettes()
        {
            return _rouletteService.GetRoulettes().ToList();
        }

        [HttpGet("CreateRoulette")]
        public ActionResult CreateRoulette()
        {
            Roulette rouletteinstance = _rouletteService.CreateRoullete();

            return Ok(rouletteinstance.Id);
        }
    }
}
