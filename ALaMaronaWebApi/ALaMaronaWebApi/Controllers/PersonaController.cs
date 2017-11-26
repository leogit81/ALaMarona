using System.Web.Http;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using ALaMarona.Core.Controller;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Persona")]
    public class PersonaController : GenericController<Persona, long, PersonaDTO, long>
    {
    }
}
