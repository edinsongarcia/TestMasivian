using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasivian.Models;

namespace TestMasivian.Interfaces
{
    public interface IBetService
    {
        public bool MakeBet(Bet bet);
        public IList<Bet> GetBetsByRouletteId(long idRoulette);

    }
}
