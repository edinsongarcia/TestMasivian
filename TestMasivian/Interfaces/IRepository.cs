using System.Collections.Generic;
using TestMasivian.Models;

namespace TestMasivian.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IList<T> ListAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
