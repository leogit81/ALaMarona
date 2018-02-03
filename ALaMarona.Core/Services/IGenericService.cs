using Eg.Core;
using System.Collections.Generic;

namespace ALaMarona.Core.Services
{
    public interface IGenericService<T, TId> where T : Entity<TId>
    {
        IEnumerable<T> Get();
        T Get(TId id);
        void Save(T entityDto);
        void Update(T entityDto);
        void Delete(TId id);
    }
}
