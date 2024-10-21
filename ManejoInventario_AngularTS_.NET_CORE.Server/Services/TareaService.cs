using ManejoInventario_AngularTS_.NET_CORE.Server.Models;
using ManejoInventario_AngularTS_.NET_CORE.Server.Repositories;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Services
{
    public interface ITareaService
    {
        List<Tarea> GetAll();
        Tarea GetById(int id);
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
            Console.WriteLine($"Tareas obtenidas: {tareas.Count}"); // Verificar cuántas tareas hay
            return tareas;
        }
        public Tarea GetById(int id)
        {
            return _tareaRepository.GetById(id);
        }
    }
    
}
