using System;
using System.Collections.Generic;
using System.Linq;
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
            var results =  _betRepository.GetResultsRoulette();
            var listBets = _betRepository.ListAll().Where(bet => bet.RouletteId == idRoulette).ToList();
            foreach (var item in listBets)
            {
                item.AmountWon = item.Number == results.Item1 ? item.Amount * 5 : 0;
            }

            return listBets;
        }

        public IList<Bet> GetBets()
        {

            return _betRepository.ListAll();
        }
        public bool AddBet(Bet bet)
        {
            var roulette = _rouletteRepository.GetById(bet.RouletteId);
            if (roulette != null && roulette.IsOpen && bet.Amount > 0 && bet.Amount <= 10000 && bet.Number >= 0 && bet.Number <= 36)
            {
                bet.BetDate = DateTime.UtcNow.ToString("o");
                _betRepository.Add(bet);

                return true;
            }
            else

                return false;
        }

        public Tuple<int, string> GetResults()
        {
            throw new NotImplementedException();
        }
    }
}
