using ALaMarona.Core.Business;
using ALaMarona.Domain.Generic;
using Eg.Core;
using Eg.Core.Data;

namespace ALaMarona.Core.Generic
{
    public abstract class RestrictedUpdateBusiness<T, TId, TUReq> : GenericBusiness<T, TId>, IRestrictedUpdateBusiness<T, TId, TUReq>
        where T : Entity<TId>
        where TId: struct
        where TUReq : IUpdateRequest<TId>
    {
        public RestrictedUpdateBusiness(IRepository<T, TId> repo) : base(repo)
        {
        }

        public virtual void Update(TUReq updateRequest)
        {
            var entity = MapUpdateRequestToEntity(updateRequest);
            base.Update(entity);
        }

        public override void Update(T entity)
        {
            return;
        }

        protected abstract T MapUpdateRequestToEntity(TUReq updateRequest);
    }
}
