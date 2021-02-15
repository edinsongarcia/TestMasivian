using System;
using System.Collections.Generic;
using TestMasivian.Models;

namespace TestMasivian.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T GetById(long id);
        T Update(T entity);
        IList<T> ListAll();
        Tuple<int,string> GetResultsRoulette();


    }
}
