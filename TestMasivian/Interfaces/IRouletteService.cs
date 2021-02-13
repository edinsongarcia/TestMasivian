using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasivian.Models;

namespace TestMasivian.Interfaces
{
    public class IRouletteService
    {
        public Roulette CreateRoullete();
        public bool OpenRoulete(int id);
        public Roulette GetRoulette(int id);
        public IList<Roulette> GetListRouletteWithState();
        public Roulette CloseRoulette(int id);
    }
}
