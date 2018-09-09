using ALaMarona.Core.Helpers;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using AutoMapper;
using System.Linq;

namespace ALaMarona.Core.AMapper
{
    public static class MappersConfigurator
    {
        public static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Producto, ProductoDTO>().ReverseMap();

                cfg.CreateMap<MovimientoStock, MovimientoStockDTO>()
                .ForMember(target => target.IdProducto, opt => opt.MapFrom(x => x.Producto.Id))
                .ForMember(target => target.Fecha, opt => opt.MapFrom(x => x.Fecha.ToLocalTime()))
                .ReverseMap().ForMember(dest => dest.Producto, opt => opt.MapFrom(x => new Producto() { Id = x.IdProducto }))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(x => DateTimeHelper.ParseDate(x.Fecha)));

                cfg.CreateMap<Pedido, PedidoDTO>()
                .ForMember(target => target.Fecha, opt => opt.MapFrom(x => x.Fecha.ToLocalTime()))
                .ReverseMap()
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(x => DateTimeHelper.ParseDate(x.Fecha)));

                cfg.CreateMap<DetallePedido, DetallePedidoDTO>().ReverseMap();

                cfg.CreateMap<Color, ColorDTO>().ReverseMap();

                cfg.CreateMap<Direccion, DireccionDTO>().ReverseMap();
                cfg.CreateMap<Localidad, LocalidadDTO>()
                .ForMember(target => target.IdProvincia, opt => opt.MapFrom(x => x.Provincia.Id))
                .ReverseMap();
                cfg.CreateMap<Provincia, ProvinciaDTO>()
                .ForMember(target => target.IdPais, opt => opt.MapFrom(x => x.Pais.Id))
                .ForMember(target => target.IdLocalidades, opt => opt.MapFrom(x => x.Localidades.Select(y => y.Id)))
                .ReverseMap();
                cfg.CreateMap<Pais, PaisDTO>()
                .ForMember(target => target.IdProvincias, opt => opt.MapFrom(x => x.Provincias.Select(y => y.Id)))
                .ReverseMap();

                cfg.CreateMap<Persona, PersonaDTO>()
                .ForMember(s => s.FechaNacimiento, t => t.MapFrom(s => s.FechaNacimiento.ToLocalTime()))
                .ForMember(s => s.TipoDocumento, t => t.MapFrom(s => s.Documento.Tipo))
                .ForMember(s => s.NumeroDocumento, t => t.MapFrom(s => s.Documento.Numero))
                .ForMember(s => s.EstadoCivil, t => t.MapFrom(s => s.EstadoCivil))
                .ForMember(s => s.PrimerNombre, t => t.MapFrom(s => s.Nombre.Primero))
                .ForMember(s => s.SegundoNombre, t => t.MapFrom(s => s.Nombre.Segundo))
                .ForMember(s => s.Apellido, t => t.MapFrom(s => s.Nombre.Apellido))
                .ForMember(s => s.Alias, t => t.MapFrom(s => s.Nombre.Alias))
                .Include<Cliente, ClienteDTO>();

                cfg.CreateMap<PersonaDTO, Persona>()
                .ForMember(s => s.FechaNacimiento, t => t.MapFrom(s => DateTimeHelper.ParseDate(s.FechaNacimiento)))
                .ForMember(s => s.Documento, t => t.MapFrom(s => new Documento()
                {
                    Numero = s.NumeroDocumento,
                    Tipo = s.TipoDocumento
                }))
                .ForMember(s => s.EstadoCivil, t => t.MapFrom(x => x.EstadoCivil))
                .ForMember(s => s.Nombre, t => t.MapFrom(s => new Nombre()
                {
                    Primero = s.PrimerNombre,
                    Segundo = s.SegundoNombre,
                    Apellido = s.Apellido,
                    Alias = s.Alias
                }))
                .Include<ClienteDTO, Cliente>();

                cfg.CreateMap<Cliente, ClienteDTO>().ReverseMap();
            });
        }
    }
}