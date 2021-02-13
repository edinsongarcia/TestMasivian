using StackExchange.Redis;
using System;
using System.Collections.Generic;
using TestMasivian.Interfaces;
using TestMasivian.Models;

namespace TestMasivian.DataManager
{
    public class BetRepository : IRepository<Bet>
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public BetRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public Bet Add(Bet entity)
        {

            throw new NotImplementedException();
        }

        public Bet GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IList<Bet> ListAll()
        {
            throw new NotImplementedException();
        }

        public Bet Update(Bet entity)
        {
            throw new NotImplementedException();
        }
    }
}
