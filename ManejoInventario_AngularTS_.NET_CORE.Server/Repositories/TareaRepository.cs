using ManejoInventario_AngularTS_.NET_CORE.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Repositories
{
    public interface ITareaRepository
    {
        List<Tarea> GetAll();
        Tarea GetById(int id);
        void AddOrUpdate(Tarea tarea, int? id);
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
            Tarea tarea = _context.Tarea.FirstOrDefault(x => x.Id == id)
                          ?? throw new Exception("Tarea no encontrada");

            return tarea;
        }

        public void AddOrUpdate(Tarea tarea, int? id)
        {
            if (tarea == null)
            {
                throw new ArgumentNullException(nameof(tarea), "La tarea no puede ser nula");
            }

            if (id == null) 
            {
                _context.Tarea.Add(tarea);
            }
            else 
            {
                Tarea tareaExistente = _context.Tarea.FirstOrDefault(x => x.Id == id);
                if (tareaExistente == null)
                {
                    throw new KeyNotFoundException($"No se encontró ninguna tarea con este id {id}");
                }
              
                tareaExistente.Titulo = tarea.Titulo;
                tareaExistente.Descripcion = tarea.Descripcion;
                tareaExistente.Prioridad = tarea.Prioridad;

                _context.Tarea.Update(tareaExistente); 
            }
            _context.SaveChanges(); 
        }
    }
}
