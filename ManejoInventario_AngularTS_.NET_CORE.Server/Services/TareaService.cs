using ManejoInventario_AngularTS_.NET_CORE.Server.Models;
using ManejoInventario_AngularTS_.NET_CORE.Server.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Services
{
    public interface ITareaService
    {
        List<Tarea> GetAll();
        Tarea GetById(int Id);
        void AddOrUpdate(Tarea tarea, int? id);

    }
    public class TareaService: ITareaService
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaService(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        public List<Tarea> GetAll()
        {
            var tareas = _tareaRepository.GetAll();
            
            return tareas;
        }
      

        public Tarea GetById(int Id)
        {
            return _tareaRepository.GetById(Id);
        }

        public void AddOrUpdate(Tarea tarea,int? id)
        {
           _tareaRepository.AddOrUpdate(tarea,id);
        }

    }
    
}
