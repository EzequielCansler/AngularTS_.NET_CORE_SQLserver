using ManejoInventario_AngularTS_.NET_CORE.Server.Models;
using ManejoInventario_AngularTS_.NET_CORE.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Controllers
{
    [Route("api/prioridad")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {
        private readonly IPrioridadService _prioService;

        public PrioridadController(IPrioridadService prioService)
        {
            _prioService = prioService;
        }

        // GET: PrioridadController
        [HttpGet]
        public ActionResult<List<Prioridad>> GetPrioridades()
        {
            List<Prioridad> prioridad = _prioService.GetAllPrioridades();
            return Ok(prioridad);
        }
    }
}
