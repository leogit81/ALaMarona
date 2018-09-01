using ALaMarona.Core.Generic.Controller;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;
using System.Web.Http;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Persona")]
    public class PersonaController : GenericController<Persona, long, PersonaDTO>
    {
        public PersonaController(IGenericBusiness<Persona, long> genericBusiness) : base(genericBusiness)
        {
        }
    }
}
