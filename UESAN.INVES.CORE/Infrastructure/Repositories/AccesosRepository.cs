using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.INVES.CORE.Core.Entities;
using UESAN.INVES.CORE.Infrastructure.Data;

namespace UESAN.INVES.CORE.Infrastructure.Repositories
{
    public class AccesosRepository
    {
        private readonly VdiIntranetContext _context;
        public AccesosRepository(VdiIntranetContext context)
        {
            _context = context;
        }

        //Get all access
        public IEnumerable<Accesos>GetAllAccesos()
        {
            var accesos = _context.Accesos.Where(a => a.FechaHoraAcceso != null)
                                          .Include(a => a.Usuario)
                                          .ToList();
            return accesos;
        }


        //Get all access records
        public async Task<List<Accesos>> GetAllAccesosAsync()
        {
            return await _context.Accesos.ToListAsync();
        }
        // Get access by id async
        public async Task<Accesos?> GetAccesoByIdAsync(int id)
        {
            var acceso = await _context.Accesos
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.AccesoId == id);

            return acceso;
        }

        //create access async
        public async Task<Accesos> CreateAccesoAsync(Accesos acceso)
        {
            _context.Accesos.Add(acceso);
            await _context.SaveChangesAsync();
            return acceso;
        }

        //delete access async
        public async Task<bool> DeleteAccesosAsync(int id)
        {
            var acceso = await _context.Accesos.FindAsync(id);
            if (acceso == null)
            {
                return false;
            }

            _context.Accesos.Remove(acceso);
            await _context.SaveChangesAsync();
            return true;
        }


        //update access async
        public async Task<bool> UpdateAccesoAsync(Accesos acceso)
        {
            var existingAcceso = await _context.Accesos.FindAsync(acceso.AccesoId);
            if (existingAcceso == null)
            {
                return false; // Access not found
            }
            existingAcceso.UsuarioId = acceso.UsuarioId;
            existingAcceso.FechaHoraAcceso = acceso.FechaHoraAcceso;
            _context.Accesos.Update(existingAcceso);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
