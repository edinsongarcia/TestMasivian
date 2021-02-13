using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasivian.Interfaces;
using TestMasivian.Models;

namespace TestMasivian.Services
{
    public class BetService : IBetService
    {
        private readonly IRepository<Roulette> _rouletteRepository;
        private readonly IRepository<Bet> _betRepository;
       
        public BetService(IRepository<Bet> betRepository, IRepository<Roulette> rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
            _betRepository = betRepository;

        }
        public IList<Bet> GetBetsByRouletteId(long idRoulette)
        {
            return _betRepository.ListAll().Where(bet => bet.RouletteId == idRoulette).ToList();
        }
        public bool MakeBet(Bet bet)
        {
            var roulette = _rouletteRepository.GetById(bet.RouletteId);
            if (roulette != null && roulette.IsOpen && bet.Amount > 0 && bet.Amount <= 10000 && bet.Number >= 0 && bet.Number <= 36)
            {
                bet.BetDate = DateTime.UtcNow;
                _betRepository.Add(bet);

                return true;
            }
            else

                return false;
        }
    }
}
