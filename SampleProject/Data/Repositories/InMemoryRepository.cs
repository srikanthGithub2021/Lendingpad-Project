using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class InMemoryRepository<T>: IRepository<T> where T : IdObject
    {
        protected readonly IInMemoryStorage<T> Storage;

        public InMemoryRepository(IInMemoryStorage<T> storage)
        {
            Storage = storage;
        }
        public void Save(T entity)
        {
            Storage.Save(entity);
        }

        public void Delete(T entity)
        {
            Storage.Delete(entity);
        }

        public T Get(Guid id)
        {
            return Storage.Get(id);
        }
    }
}
