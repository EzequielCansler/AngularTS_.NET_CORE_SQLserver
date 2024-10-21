using ManejoInventario_AngularTS_.NET_CORE.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Repositories
{
    public interface IPrioridadRepository
    {
        List<Prioridad> GetAllPrioridades();

    }
    public class PrioridadReporitory: IPrioridadRepository
    {
        private readonly DB _context;

        public PrioridadReporitory(DB context)
        {
            _context = context;
        }
        public List<Prioridad> GetAllPrioridades()
        {
            return _context.Prioridad.ToList();
        }
    }
}
