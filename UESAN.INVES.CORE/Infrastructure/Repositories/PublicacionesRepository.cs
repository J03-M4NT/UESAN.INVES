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
    public class PublicacionesRepository : IPublicacionesRepository
    {
        private readonly VdiIntranetContext _context;
        public PublicacionesRepository(VdiIntranetContext context)
        {
            _context = context;
        }

        //Get all publicaciones
        public IEnumerable<Publicaciones> GetAllPublicaciones()
        {
            var publicaciones = _context.Publicaciones
                .Include(p => p.Categoria)
                .ToList();
            return publicaciones;
        }
        // Get all publicaciones async
        public async Task<List<Publicaciones>> GetAllPublicacionesAsync()
        {
            return await _context.Publicaciones
                .Include(p => p.Categoria)
                .ToListAsync();
        }
        // Get publicacion by id async
        public async Task<Publicaciones?> GetPublicacionByIdAsync(int id)
        {
            var publicacion = await _context.Publicaciones
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.PublicacionId == id);
            return publicacion;
        }

        // Get publicaciones by user id async
        public async Task<List<Publicaciones>> GetPublicacionesByUserIdAsync(int userId)
        {
            return await _context.Asignaciones
                .Include(a => a.Publicacion)
                .Where(a => a.UsuarioId == userId)
                .Select(a => a.Publicacion!)
                .Where(p => p != null)
                .Distinct()
                .ToListAsync();
        }
        // Get publicaciones by category id async
        public async Task<List<Publicaciones>> GetPublicacionesByCategoryIdAsync(int categoryId)
        {
            return await _context.Publicaciones
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaId == categoryId)
                .ToListAsync();
        }

        // Create publicacion async
        public async Task<Publicaciones> CreatePublicacionAsync(Publicaciones publicacion)
        {
            _context.Publicaciones.Add(publicacion);
            await _context.SaveChangesAsync();
            return publicacion;
        }
        // Delete publicacion async
        public async Task<bool> DeletePublicacionAsync(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);
            if (publicacion == null)
            {
                return false;
            }
            _context.Publicaciones.Remove(publicacion);
            await _context.SaveChangesAsync();
            return true;
        }
        // Update publicacion async
        public async Task<Publicaciones?> UpdatePublicacionAsync(Publicaciones publicacion)
        {
            var existing = await _context.Publicaciones.FindAsync(publicacion.PublicacionId);
            if (existing == null)
                return null;

            existing.Nombre = publicacion.Nombre;
            existing.CategoriaId = publicacion.CategoriaId;
            existing.Issn = publicacion.Issn;
            existing.Issn2 = publicacion.Issn2;
            existing.Issn3 = publicacion.Issn3;
            existing.Puntaje = publicacion.Puntaje;
            existing.IncentivoUsd = publicacion.IncentivoUsd;
            existing.FechaPublicacion = publicacion.FechaPublicacion;
            existing.Estado = publicacion.Estado;

            _context.Publicaciones.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

    }
}
