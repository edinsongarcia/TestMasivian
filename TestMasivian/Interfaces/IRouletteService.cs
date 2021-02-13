using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasivian.Models;

namespace TestMasivian.Interfaces
{
    public interface IRouletteService
    {
        public Roulette CreateRoullete();
        public bool OpenRoulete(long id);
        public Roulette GetRoulette(long id);
        public IList<Roulette> GetRoulettes();
        public Roulette CloseRoulette(long id);
    }
}
