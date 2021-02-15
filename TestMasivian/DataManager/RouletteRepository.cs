using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Roulette GetById(long id)
        {
            return ListAll().FirstOrDefault(roulettes => roulettes.Id == id);
        }

        public Roulette Add(Roulette roulette)
        {
            IDatabase db = _connectionMultiplexer.GetDatabase();
            RedisKey key = new RedisKey("ListRoulette");
            IList<Roulette> roulettes = ListAll();
            if (roulettes == null)
            {
                roulette.Id = 0;
                roulettes = new List<Roulette>() { roulette };
            }
            else
            {
                roulette.Id = roulettes.Last().Id + 1;
                roulettes.Add(roulette);
            }
            db.StringSet(key, JsonConvert.SerializeObject(roulettes));

            return roulette;
        }

        public IList<Roulette> ListAll()
        {
            IDatabase db = _connectionMultiplexer.GetDatabase();
            RedisKey key = new RedisKey("ListRoulette");
            string listJson = db.StringGet(key);

            return listJson != null ? JsonConvert.DeserializeObject<IList<Roulette>>(listJson) : null;
        }

        public Roulette Update(Roulette entity)
        {
            IList<Roulette> roulettes = ListAll();
            IDatabase db = _connectionMultiplexer.GetDatabase();
            RedisKey key = new RedisKey("ListRoulette");
            roulettes[roulettes.IndexOf(roulettes.FirstOrDefault(roulettes => roulettes.Id == entity.Id))].IsOpen = entity.IsOpen;
            db.StringSet(key, JsonConvert.SerializeObject(roulettes));

            return entity;
        }

        public Tuple<int, string> GetResultsRoulette()
        {
            throw new NotImplementedException();
        }
    }
}