using ManejoInventario_AngularTS_.NET_CORE.Server.Models;
using ManejoInventario_AngularTS_.NET_CORE.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Controllers
{
    [Route("/api/tarea/")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareaController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        // GET: TareasController
        [HttpGet]
        public ActionResult<List<Tarea>> GetTareas()
        {
            List<Tarea> tarea = _tareaService.GetAll();
            return Ok(tarea);
        }

        // GET: TareasController/Details/5
        [HttpGet("{id}")]
        public ActionResult GetTareaById(int id)
        {
            Tarea tarea = _tareaService.GetById(id);
            return Ok(tarea);
        }

        //// GET: TareasController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TareasController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TareasController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TareasController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TareasController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TareasController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
