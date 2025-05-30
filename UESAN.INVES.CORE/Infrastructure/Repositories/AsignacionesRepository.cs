using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.INVES.CORE.Core.Entities;
using UESAN.INVES.CORE.Core.Interfaces;
using UESAN.INVES.CORE.Infrastructure.Data;

namespace UESAN.INVES.CORE.Infrastructure.Repositories
{
    public class AsignacionesRepository : IAsignacionesRepository
    {
        private readonly VdiIntranetContext _context;
        public AsignacionesRepository(VdiIntranetContext context)
        {
            _context = context;
        }

        //Get all asignaciones
        public IEnumerable<Asignaciones> GetAllAsignaciones()
        {
            var asignaciones = _context.Asignaciones
                .Include(a => a.Usuario)
                .Include(a => a.Publicacion)
                .ToList();
            return asignaciones;
        }

        //Get all asignaciones async
        public async Task<List<Asignaciones>> GetAllAsignacionesAsync()
        {
            return await _context.Asignaciones
                .Include(a => a.Usuario)
                .Include(a => a.Publicacion)
                .ToListAsync();
        }
        //get asignacion by id async
        public async Task<Asignaciones?> GetAsignacionByIdAsync(int id)
        {
            var asignacion = await _context.Asignaciones
                .Include(a => a.Usuario)
                .Include(a => a.Publicacion)
                .FirstOrDefaultAsync(a => a.AsignacionId == id);
            return asignacion;
        }
        //create asignacion async
        public async Task<Asignaciones> CreateAsignacionAsync(Asignaciones asignacion)
        {
            _context.Asignaciones.Add(asignacion);
            await _context.SaveChangesAsync();
            return asignacion;
        }
        //delete asignacion async
        public async Task<bool> DeleteAsignacionAsync(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return false;
            }
            _context.Asignaciones.Remove(asignacion);
            await _context.SaveChangesAsync();
            return true;

        }

        //update asignacion async
        public async Task<Asignaciones?> UpdateAsignacionAsync(Asignaciones asignacion)
        {
            var existingAsignacion = await _context.Asignaciones.FindAsync(asignacion.AsignacionId);
            if (existingAsignacion == null)
            {
                return null;
            }
            existingAsignacion.UsuarioId = asignacion.UsuarioId;
            existingAsignacion.PublicacionId = asignacion.PublicacionId;
            existingAsignacion.Estado = asignacion.Estado;
            existingAsignacion.FechaAsignacion = asignacion.FechaAsignacion;
            _context.Asignaciones.Update(existingAsignacion);
            await _context.SaveChangesAsync();
            return existingAsignacion;
        }



    }

}
