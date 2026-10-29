using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IInMemoryStorage<T> where T : IdObject
    {

        void Save(T entity);
        void Delete(T entity);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}
