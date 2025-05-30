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
    public class NotificacionesRepository
    {

        private readonly VdiIntranetContext _context;
        public NotificacionesRepository(VdiIntranetContext context)
        {
            _context = context;
        }

        //Get all notificaciones
        public IEnumerable<Notificaciones> GetAllNotificaciones()
        {
            var notificaciones = _context.Notificaciones
                .Include(n => n.Usuario)
                .ToList();
            return notificaciones;
        }
        //Get all notificaciones async
        public async Task<List<Notificaciones>> GetAllNotificacionesAsync()
        {
            return await _context.Notificaciones
                .Include(n => n.Usuario)
                .ToListAsync();
        }
        //get notificacion by id async
        public async Task<Notificaciones?> GetNotificacionByIdAsync(int id)
        {
            var notificacion = await _context.Notificaciones
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(n => n.NotificacionId == id);
            return notificacion;
        }
        //create notificacion async
        public async Task<Notificaciones> CreateNotificacionAsync(Notificaciones notificacion)
        {
            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();
            return notificacion;
        }
        //delete notificacion async
        public async Task<bool> DeleteNotificacionAsync(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion == null)
            {
                return false;
            }
            _context.Notificaciones.Remove(notificacion);
            await _context.SaveChangesAsync();
            return true;
        }
        //update notificacion async
        public async Task<Notificaciones> UpdateNotificacionAsync(Notificaciones notificacion)
        {
            _context.Notificaciones.Update(notificacion);
            await _context.SaveChangesAsync();
            return notificacion;
        }
    }
}
