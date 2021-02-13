using Newtonsoft.Json;
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
            IDatabase db = _connectionMultiplexer.GetDatabase();
            RedisKey key = new RedisKey("ListRoulette");
            IList<Roulette> roulettes = ListAll();
            if (roulettes == null)
            {
                entity.Id = 0;
                roulettes = new List<Roulette>() { entity };
            }
            else
            {
                entity.Id = roulettes.Last().Id + 1;
                roulettes.Add(entity);
            }
            db.StringSet(key, JsonConvert.SerializeObject(roulettes));

            return entity;
        }

        public Roulette GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IList<Roulette> ListAll()
        {
            try
            {
                IDatabase db = _connectionMultiplexer.GetDatabase();
                RedisKey key = new RedisKey("ListRoulette");
                string listJson = db.StringGet(key);

                return listJson != null ? JsonConvert.DeserializeObject<IList<Roulette>>(listJson) : null;
            }
            catch (Exception e)
            {
                var err = e;
                throw;
            }
        }

        public Roulette Update(Roulette entity)
        {
            throw new NotImplementedException();
        }
    }
}
