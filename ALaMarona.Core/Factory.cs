using ALaMarona.Core;
using ALaMarona.Domain.Entities;
using AutoMapper;
using ALaMarona.Domain.DTOs;
using System;
using System.Linq;

namespace ALaMarona.Core
{
    public class Factory : IFactory
    {
        private static readonly Factory _factory = new Factory();

        private Factory()
        {

        }

        public static Factory Instance
        {
            get
            {
                return _factory;
            }
        }

        private DateTime convertFecha(string fechaNacimiento)
        {
            DateTime fec;
            if (DateTime.TryParse(fechaNacimiento, out fec))
            {
                return fec;
            }

            throw new ALaMaronaException(string.Format("No se pudo mapear el DTO hacia la entidad porque el argumento {0} tenía el valor inválido {1}", nameof(fechaNacimiento), fechaNacimiento));
        }

        public void ConfigureMapping()
        {
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<Producto, ProductoDTO>().ReverseMap();
        //        cfg.CreateMap<Stock, StockDTO>().ReverseMap();
        //        cfg.CreateMap<MovimientoStock, MovimientoStockDTO>().ReverseMap();
        //        cfg.CreateMap<Color, ColorDTO>().ReverseMap();
        //    });
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<Direccion, DireccionDTO>().ReverseMap();
        //        cfg.CreateMap<Localidad, LocalidadDTO>().ReverseMap();
        //        cfg.CreateMap<Provincia, ProvinciaDTO>().ReverseMap();
        //        cfg.CreateMap<Pais, PaisDTO>().ReverseMap();
        //    });
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Producto, ProductoDTO>().ReverseMap();
                cfg.CreateMap<Stock, StockDTO>();
                cfg.CreateMap<StockDTO, Stock>()
                .AfterMap((sDto, s) => sDto.Movimientos.ToList()
                    .ForEach(m => s.AgregarMovimiento(Mapper.Map<MovimientoStock>(m))));
                cfg.CreateMap<MovimientoStock, MovimientoStockDTO>().ReverseMap();
                cfg.CreateMap<Color, ColorDTO>().ReverseMap();

                cfg.CreateMap<Direccion, DireccionDTO>().ReverseMap();
                cfg.CreateMap<Localidad, LocalidadDTO>().ReverseMap();
                cfg.CreateMap<Provincia, ProvinciaDTO>().ReverseMap();
                cfg.CreateMap<Pais, PaisDTO>().ReverseMap();

                cfg.CreateMap<Persona, PersonaDTO>()
                .ForMember("FechaNacimiento", t => t.MapFrom(s => s.FechaNacimiento.ToString(System.Globalization.CultureInfo.InvariantCulture)))
                .ForMember("TipoDocumento", t => t.MapFrom(s => s.Documento.Tipo))
                .ForMember("NumeroDocumento", t => t.MapFrom(s => s.Documento.Numero))
                .ForMember("EstadoCivil", t => t.MapFrom(s => s.EstadoCivil.Descripcion))
                .ForMember("PrimerNombre", t => t.MapFrom(s => s.Nombre.Primero))
                .ForMember("SegundoNombre", t => t.MapFrom(s => s.Nombre.Segundo))
                .ForMember("Apellido", t => t.MapFrom(s => s.Nombre.Apellido))
                .ForMember("Alias", t => t.MapFrom(s => s.Nombre.Alias));

                cfg.CreateMap<PersonaDTO, Persona>()
                .ForMember("FechaNacimiento", t => t.MapFrom(s => convertFecha(s.FechaNacimiento)))
                .ForMember("Documento", t => t.MapFrom(s => new Documento()
                {
                    Numero = s.NumeroDocumento,
                    Tipo = s.TipoDocumento
                }))
                .ForMember("EstadoCivil", t => t.MapFrom(s => new EstadoCivil()
                {
                    Descripcion = s.EstadoCivil
                }))
                .ForMember("Nombre", t => t.MapFrom(s => new Nombre()
                {
                    Primero = s.PrimerNombre,
                    Segundo = s.SegundoNombre,
                    Apellido = s.Apellido,
                    Alias = s.Alias
                }));
            });
        }
    }
}
