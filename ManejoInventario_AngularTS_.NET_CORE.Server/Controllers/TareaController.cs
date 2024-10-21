using ManejoInventario_AngularTS_.NET_CORE.Server.Models;
using ManejoInventario_AngularTS_.NET_CORE.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Controllers
{
    [Route("api/tarea")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareaController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        // GET: Tareas
        [HttpGet]
        public ActionResult<List<Tarea>> GetTareas()
        {
            List<Tarea> tarea = _tareaService.GetAll();
            return Ok(tarea);
        }

        // GET: Tareas/id
        [HttpGet("{id}")]
        public ActionResult GetTareaById(int id)
        {
            Tarea tarea = _tareaService.GetById(id);
            return Ok(tarea);
        }

        // POST: Tareas/CreateOrUpdate
        [HttpPost("{id?}")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate([FromBody] Tarea tarea, int? id)
        {
            try
            {
                _tareaService.AddOrUpdate(tarea,id);
                return Ok(new { success = true, message = "Tarea guardad exitosamente" });
            }
            catch (Exception ex) 
            { 
                return BadRequest(new {success = false, message = ex.Message});
            }
        }

    }
}
