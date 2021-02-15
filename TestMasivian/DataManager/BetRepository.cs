using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
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
            IDatabase db = _connectionMultiplexer.GetDatabase();
            RedisKey key = new RedisKey("ListBet");
            IList<Bet> roulettes = ListAll();
            if (roulettes == null)
            {
                entity.Id = 0;
                roulettes = new List<Bet>() { entity };
            }
            else
            {
                entity.Id = roulettes.Last().Id + 1;
                roulettes.Add(entity);
            }
            db.StringSet(key, JsonConvert.SerializeObject(roulettes));

            return entity;
        }

        public Bet GetById(long id)
        {
            return ListAll().FirstOrDefault(roulettes => roulettes.Id == id);
        }

        public IList<Bet> ListAll()
        {
            IDatabase db = _connectionMultiplexer.GetDatabase();
            RedisKey key = new RedisKey("ListBet");
            string listJson = db.StringGet(key);

            return listJson != null ? JsonConvert.DeserializeObject<IList<Bet>>(listJson) : null;
        }

        public Bet Update(Bet entity)
        {
            throw new NotImplementedException();
        }
    }
}