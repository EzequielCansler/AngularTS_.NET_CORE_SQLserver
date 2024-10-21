using ManejoInventario_AngularTS_.NET_CORE.Server.Models;
using ManejoInventario_AngularTS_.NET_CORE.Server.Repositories;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Services
{
    public interface IPrioridadService
    {
        List<Prioridad> GetAllPrioridades();
    }
    public class PrioridadService : IPrioridadService
    {
        private readonly IPrioridadRepository _prioRepository;

        public PrioridadService(IPrioridadRepository prioRepository)
        {
            _prioRepository = prioRepository;
        }
        public List<Prioridad> GetAllPrioridades()
        {
            return _prioRepository.GetAllPrioridades();
        }
    }
}
