using System.Collections.Generic;
using TestMasivian.Models;

namespace TestMasivian.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T GetById(int id);
        T Update(T entity);
        IList<T> ListAll();

    }
}
