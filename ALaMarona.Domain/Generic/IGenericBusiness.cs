using System.Collections.Generic;

namespace ALaMarona.Domain.Generic
{
    public interface IGenericBusiness<T, TId>
    {
        IList<T> GetAll();
        T GetById(TId id);
        T Save(T entity);
        void Update(T entity);
        void Delete(TId id);
    }
}
