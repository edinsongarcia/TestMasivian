using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasivian.Interfaces;
using TestMasivian.Models;

namespace TestMasivian.Services
{
    public class RouletteService : IRouletteService
    {
        private readonly IRepository<Roulette> _rouletteRepository;
        public RouletteService(IRepository<Roulette> rouletteRepository, IRepository<Bet> betRepository)
        {
            _rouletteRepository = rouletteRepository;
        }
        public IList<Roulette> GetRoulettes()
        {
            return _rouletteRepository.ListAll();
        }
        public Roulette CloseRoulette(long id)
        {
            Roulette roulette = _rouletteRepository.GetById(id);
            roulette.IsOpen = false;
            return _rouletteRepository.Update(roulette);
        }
        public Roulette CreateRoullete()
        {
            Roulette roulette = new Roulette();

            return _rouletteRepository.Add(roulette);
        }

        public Roulette GetRoulette(long id)
        {
            return _rouletteRepository.GetById(id);
        }
        public bool OpenRoulete(long id)
        {
            Roulette roulette = _rouletteRepository.GetById(id);
            if (roulette != null && roulette.IsOpen)

                return false;
            else if (roulette != null)
            {
                roulette.IsOpen = true;
                _rouletteRepository.Update(roulette);

                return true;
            }
            else

                return false;
        }
    }
}
