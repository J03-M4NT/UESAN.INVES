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
    public class PublicacionesGuardadasRepository : IPublicacionesGuardadasRepository
    {
        private readonly VdiIntranetContext _context;
        public PublicacionesGuardadasRepository(VdiIntranetContext context)
        {
            _context = context;
        }

        //Get all publicaciones guardadas
        public IEnumerable<PublicacionesGuardadas> GetAllPublicacionesGuardadas()
        {
            var publicacionesGuardadas = _context.PublicacionesGuardadas
                .Include(pg => pg.Publicacion)
                .Include(pg => pg.Usuario)
                .ToList();
            return publicacionesGuardadas;
        }

        //Get all publicaciones guardadas async
        public async Task<List<PublicacionesGuardadas>> GetAllPublicacionesGuardadasAsync()
        {
            return await _context.PublicacionesGuardadas
                .Include(pg => pg.Publicacion)
                .Include(pg => pg.Usuario)
                .ToListAsync();
        }
        //Get publicaciones guardadas by user id async
        public async Task<List<PublicacionesGuardadas>> GetPublicacionesGuardadasByUserIdAsync(int userId)
        {
            return await _context.PublicacionesGuardadas
                .Include(pg => pg.Publicacion)
                .Where(pg => pg.UsuarioId == userId)
                .ToListAsync();
        }

        //Get publicaciones guardadas by id async
        public async Task<PublicacionesGuardadas?> GetPublicacionGuardadaByIdAsync(int id)
        {
            var publicacionGuardada = await _context.PublicacionesGuardadas
                .Include(pg => pg.Publicacion)
                .Include(pg => pg.Usuario)
                .FirstOrDefaultAsync(pg => pg.Id == id);
            return publicacionGuardada;
        }

        //Check if publicacion is already saved by user
        public async Task<bool> IsPublicacionGuardadaByUserAsync(int publicacionId, int userId)
        {
            return await _context.PublicacionesGuardadas
                .AnyAsync(pg => pg.PublicacionId == publicacionId && pg.UsuarioId == userId);

        }

        //Create publicacion guardada async
        public async Task<PublicacionesGuardadas?> CreateAsync(PublicacionesGuardadas nueva)
        {
            bool exists = await IsPublicacionGuardadaByUserAsync(nueva.PublicacionId ?? 0, nueva.UsuarioId ?? 0);
            if (exists)
                return null;

            _context.PublicacionesGuardadas.Add(nueva);
            await _context.SaveChangesAsync();
            return nueva;
        }
        //Delete publicacion guardada async
        public async Task<bool> DeletePublicacionGuardadaAsync(int id)
        {
            var publicacionGuardada = await _context.PublicacionesGuardadas.FindAsync(id);
            if (publicacionGuardada == null)
            {
                return false;
            }
            _context.PublicacionesGuardadas.Remove(publicacionGuardada);
            await _context.SaveChangesAsync();
            return true;
        }


        //update publicacion guardada async
        public async Task<bool> UpdateAsync(PublicacionesGuardadas actualizada)
        {
            var existing = await _context.PublicacionesGuardadas.FindAsync(actualizada.Id);
            if (existing == null)
                return false;

            existing.PublicacionId = actualizada.PublicacionId;
            existing.UsuarioId = actualizada.UsuarioId;
            existing.FechaGuardado = actualizada.FechaGuardado;

            _context.PublicacionesGuardadas.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
