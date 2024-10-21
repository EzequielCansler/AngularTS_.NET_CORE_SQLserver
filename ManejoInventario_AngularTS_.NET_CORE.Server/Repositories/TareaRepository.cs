using ManejoInventario_AngularTS_.NET_CORE.Server.Models;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Repositories
{
    public interface ITareaRepository
    {
        List<Tarea> GetAll();
        Tarea GetById(int id);

    }
    public class TareaRepository : ITareaRepository
    {
        private readonly DB _context;

        public TareaRepository(DB context)
        {
            _context = context;
        }

        public List<Tarea> GetAll()
        {
            return _context.Tarea.ToList();
        }

        public Tarea GetById(int id)
        {
            Tarea tarea = _context.Tarea.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Tarea no encontrada");

            return tarea;
        }
    }
}
