using Eg.Core;
using System.Collections.Generic;

namespace ALaMarona.Domain.Generic
{
    public interface IRestrictedUpdateBusiness<T, TId, TUReq>
        where T : Entity<TId>
        where TId : struct
        where TUReq : IUpdateRequest<TId>
    {
        IList<T> GetAll();
        T GetById(TId id);
        T Save(T entity);
        void Update(TUReq updateRequest);
        void Delete(TId id);
    }
}
