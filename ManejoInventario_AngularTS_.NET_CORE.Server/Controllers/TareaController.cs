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

        
        [HttpGet]
        public ActionResult<List<Tarea>> GetTareas()
        {
            List<Tarea> tarea = _tareaService.GetAll();
            return Ok(tarea);
        }

        
        [HttpGet("{id}")]
        public ActionResult GetTareaById(int id)
        {
            Tarea tarea = _tareaService.GetById(id);
            return Ok(tarea);
        }

       
        [HttpPost]
        public ActionResult CreateOrUpdate([FromBody] Tarea tarea)
        {
            try
            {
                // Si el Id es nulo o 0, se trata de una nueva tarea
                if (tarea.Id == 0 || tarea.Id == null)
                {
                    // Crear nueva tarea
                    _tareaService.AddOrUpdate(tarea, null);
                }
                else
                {
                    // Actualizar tarea existente
                    _tareaService.AddOrUpdate(tarea, tarea.Id);
                }

                return Ok(new { success = true, message = "Tarea guardada exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

    }
}
