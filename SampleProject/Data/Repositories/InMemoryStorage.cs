using BusinessEntities;
using Common;
using Raven.Abstractions.Data;
using Raven.Client.Indexes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public  class InMemoryStorage<T>: IInMemoryStorage<T> where T : IdObject
    {
        private readonly ConcurrentDictionary<Guid, T> _store = new ConcurrentDictionary<Guid, T>();
        public void Save(T entity)
        {
            _store[entity.Id]=entity;
        }

        public void Delete(T entity)
        {
            _store.TryRemove(entity.Id,out _);
        }

        public T Get(Guid id)
        {
            _store.TryGetValue(id, out var entity);
            return entity;
        }

       public IEnumerable<T> GetAll()
        {
            return _store.Values;
        }
    }
}
