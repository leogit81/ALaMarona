using System.Web.Http;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Core.Controller;
using ALaMarona.Core.Services;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Persona")]
    public class PersonaController : GenericController<Persona, long, PersonaDTO>
    {
        public PersonaController(IGenericService<Persona, long> genericService) : base(genericService)
        {
        }
    }
}
