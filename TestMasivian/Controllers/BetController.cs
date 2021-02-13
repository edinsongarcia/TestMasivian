using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestMasivian.Interfaces;

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
    }
}
