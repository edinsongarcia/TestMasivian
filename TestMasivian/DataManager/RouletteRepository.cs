using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasivian.Interfaces;
using TestMasivian.Models;

namespace TestMasivian.DataManager
{
    public class RouletteRepository : IRepository<Roulette>
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public RouletteRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public Roulette Add(Roulette entity)
        {
            throw new NotImplementedException();
        }

        public Roulette GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Roulette> ListAll()
        {
            throw new NotImplementedException();
        }

        public Roulette Update(Roulette entity)
        {
            throw new NotImplementedException();
        }
    }
}
