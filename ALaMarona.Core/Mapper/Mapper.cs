using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.Entities;

namespace ALaMarona.Core.AMapper
{
    public static class AMapper
    {
        public static Direccion MapDireccion(this CreateDireccionRequest direccionRequest)
        {
            return new Direccion()
            {
                Altura = direccionRequest.Altura,
                Calle = direccionRequest.Calle,
                CodigoPostal = direccionRequest.CodigoPostal,
                Piso = direccionRequest.Piso,
                Departamento = direccionRequest.Departamento,
                IdLocalidad = direccionRequest.IdLocalidad,
                IdProvincia = direccionRequest.IdProvincia,
                IdPais = direccionRequest.IdPais
            };
        }

        public static Nombre MapNombre(this CreatePersonaRequest request)
        {
            return new Nombre()
            {
                Primero = request.PrimerNombre,
                Segundo = request.SegundoNombre,
                Apellido = request.Apellido,
                Alias = request.Alias
            };
        }
    }
}
