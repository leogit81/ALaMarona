using ALaMaronaDTOs;
using ALaMaronaDTOs.Request;
using System.Collections.Generic;

namespace ALaMaronaServiceRESTClient
{
    public interface IALaMaronaServiceRESTClient
    {
        IList<ClienteDto> GetClientes(SearchClientRequestDto request);
    }
}
