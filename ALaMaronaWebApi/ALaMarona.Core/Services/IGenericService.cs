using Eg.Core.DTOs;
using System.Collections.Generic;

namespace ALaMarona.Core.Services
{
    public interface IGenericService<TDTO, TDTOId> where TDTO : GenericDTO<TDTOId>
    {
        IEnumerable<TDTO> Get();
        TDTO Get(TDTOId id);
        void Save(TDTO entityDto);
        void Update(TDTO entityDto);
        void Delete(TDTOId id);
    }
}
