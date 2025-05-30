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
    public class RolesRepository
    {
        private readonly VdiIntranetContext _context;
        public RolesRepository(VdiIntranetContext context)
        {
            _context = context;
        }

        //Get all roles
        public IEnumerable<Roles> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        //Get all roles async
        public async Task<List<Roles>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        //Get role by id async
        public async Task<Roles?> GetRoleByIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RolId == id);
        }

        // Get roles by user id async
        public async Task<List<Roles>> GetRolesByUserIdAsync(int userId)
        {
            return await _context.Roles
                .Where(r => r.Usuarios.Any(u => u.UsuarioId == userId))
                .ToListAsync();
        }

        //Create role async
        public async Task<Roles> CreateRoleAsync(Roles role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }
        //Delete role async
        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return false;
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
        //Update role async
        public async Task<Roles> UpdateRoleAsync(Roles role)
        {
            var existing = await _context.Roles.FindAsync(role.RolId);
            if (existing == null)
                return null!;

            existing.NombreRol = role.NombreRol;

            _context.Roles.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

    }
}
