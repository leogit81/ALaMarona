using ALaMarona.Core.Controller;
using ALaMarona.Domain.DTOs;
using ALaMarona.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ALaMaronaWebApi.Controllers
{
    [RoutePrefix("api/Stock")]
    public class StockController : GenericController<Stock, long, StockDTO, long>
    {
    }
}
