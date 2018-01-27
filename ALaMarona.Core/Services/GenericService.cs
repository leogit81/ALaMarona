using AutoMapper;
using Eg.Core;
using Eg.Core.Data;
using Eg.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ALaMarona.Core.Services
{
    public class GenericService<T, TId, TDTO, TDTOId> : IGenericService<TDTO, TDTOId> where T: Entity<TId> where TDTO : GenericDTO<TDTOId>
    {
        protected IRepository<T, TId> repository;
        //protected IMapper mapper;

        public GenericService(IRepository<T, TId> repo)
        {
            repository = repo;
        }

        public void Delete(TDTOId id)
        {
            var entity = repository.FirstOrDefault(e => e.Id.Equals(id));
            repository.Remove(entity);
        }

        public IEnumerable<TDTO> Get()
        {
            return repository.Select(p => Mapper.Map<TDTO>(p));
        }

        public TDTO Get(TDTOId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return Mapper.Map<TDTO>(repository.FirstOrDefault(x => id.Equals(x.Id)));
        }

        public void Save(TDTO entityDto)
        {
            repository.Add(Mapper.Map<T>(entityDto));
        }

        public void Update(TDTO entityDto)
        {
            var entity = repository.FirstOrDefault(e => e.Id.Equals(entityDto.Id));

            if (entity == null)
            {
                throw new ArgumentException("No se encontró la entidad que se quería actualizar");
            }

            Mapper.Map(entityDto, entity);

            repository.Update(entity);
        }
    }
}
