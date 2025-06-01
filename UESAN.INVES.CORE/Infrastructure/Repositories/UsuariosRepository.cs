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
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly VdiIntranetContext _context;
        public UsuariosRepository(VdiIntranetContext context)
        {
            _context = context;
        }


        //Get all usuarios
        public IEnumerable<Usuarios> GetAllUsuarios()
        {
            return _context.Usuarios.ToList();
        }
        //Get all usuarios async
        public async Task<List<Usuarios>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        //Get usuario by id async
        public async Task<Usuarios?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == id);
        }
        //Get usuario by email async
        public async Task<Usuarios?> GetUsuarioByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == email);
        }
        //Get usuario by username async
        public async Task<Usuarios?> GetUsuarioByUsernameAsync(string username)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Nombre == username);
        }

        //Get usuarios by role id async
        public async Task<List<Usuarios>> GetUsuariosByRoleIdAsync(int roleId)
        {
            return await _context.Usuarios
                .Where(u => u.RolId == roleId)
                .ToListAsync();
        }

        //Create usuario async
        public async Task<Usuarios> CreateUsuarioAsync(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        //Delete usuario async
        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        //Update usuario async
        public async Task<Usuarios> UpdateUsuarioAsync(Usuarios usuario)
        {
            var existing = await _context.Usuarios.FindAsync(usuario.UsuarioId);
            if (existing == null)
                return null!;

            existing.Nombre = usuario.Nombre;
            existing.Apellido = usuario.Apellido;
            existing.Correo = usuario.Correo;
            existing.Contraseña = usuario.Contraseña;
            existing.RolId = usuario.RolId;
            existing.Estado = usuario.Estado;

            _context.Usuarios.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
