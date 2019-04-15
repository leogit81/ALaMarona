using ALaMarona.Domain.Entities;
using AutoMapper;

namespace ALaMaronaManager.Mapper
{
    public class ALaMaronaManagerProfile: Profile
    {
        public ALaMaronaManagerProfile()
        {
            CreateMap<Cliente, GridClient>()
                .ForMember(target => target.Codigo, opt => opt.MapFrom(x => x.Codigo))
                .ForMember(target => target.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(target => target.Nombre, opt => opt.Ignore())
                .ForMember(target => target.Direccion, opt => opt.Ignore())
                .ForMember(target => target.EMail, opt => opt.MapFrom(x => x.EMail))
                .AfterMap((source, target, ctx) =>
                {
                    if (source.Domicilio != null)
                    {
                        target.Direccion = source.Domicilio.Calle + " " + source.Domicilio.Altura
                    + " (" + source.Domicilio.CodigoPostal + ") " + source.Domicilio.Localidad?.Nombre
                    + ", " + source.Domicilio.Provincia?.Nombre + ", " + source.Domicilio.Pais?.Nombre;
                    }

                    if (source.Nombre != null)
                    {
                        target.Nombre = source.Nombre.Apellido + ", " + source.Nombre.Primero + " " + source.Nombre.Segundo;
                    }
                });
        }
    }
}
