using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.INVES.CORE.Infrastructure.Data;

namespace UESAN.INVES.CORE.Infrastructure.Repositories
{
    public class CategoriasRepository
    {
        public class AsignacionesRepository
        {
            private readonly VdiIntranetContext _context;
            public AsignacionesRepository(VdiIntranetContext context)
            {
                _context = context;
            }

            //Get all categorias
            public IEnumerable<Categorias> GetAllCategorias()
            {
                var categorias = _context.Categorias
                    .Include(c => c.Publicaciones)
                    .ToList();
                return categorias;
            }

            //Get all categorias async
            public async Task<List<Categorias>> GetAllCategoriasAsync()
            {
                return await _context.Categorias
                    .Include(c => c.Publicaciones)
                    .ToListAsync();
            }
            //get categoria by id async
            public async Task<Categorias?> GetCategoriaByIdAsync(int id)
            {
                var categoria = await _context.Categorias
                    .Include(c => c.Publicaciones)
                    .FirstOrDefaultAsync(c => c.CategoriaId == id);
                return categoria;
            }
            //create categoria async
            public async Task<Categorias> CreateCategoriaAsync(Categorias categoria)
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
            //delete categoria async
            public async Task<bool> DeleteCategoriaAsync(int id)
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    return false;
                }
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return true;
            }
            // Update categoria async
            public async Task<Categorias?> UpdateCategoriaAsync(Categorias categoria)
            {
                var existingCategoria = await _context.Categorias.FindAsync(categoria.CategoriaId);
                if (existingCategoria == null)
                {
                    return null;
                }
                existingCategoria.NombreCategoria = categoria.NombreCategoria;
                // Update other properties as needed
                _context.Categorias.Update(existingCategoria);
                await _context.SaveChangesAsync();
                return existingCategoria;
            }



        }
    }
}