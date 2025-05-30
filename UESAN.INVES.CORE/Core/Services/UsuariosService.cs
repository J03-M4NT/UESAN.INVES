using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Entities;
using UESAN.INVES.CORE.Core.Interfaces;

namespace UESAN.INVES.CORE.Core.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<IEnumerable<UsuariosDTO>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuariosRepository.GetAllUsuariosAsync();
            return usuarios.Select(u => new UsuariosDTO
            {
                UsuarioId = u.UsuarioId,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                RolId = u.RolId,
                Estado = u.Estado,
                FechaRegistro = u.FechaRegistro
            });
        }

        public async Task<UsuariosDTO?> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuariosRepository.GetUsuarioByIdAsync(id);
            if (usuario == null) return null;

            return new UsuariosDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                RolId = usuario.RolId,
                Estado = usuario.Estado,
                FechaRegistro = usuario.FechaRegistro
            };
        }

        public async Task<UsuariosDTO?> GetUsuarioByEmailAsync(string email)
        {
            var usuario = await _usuariosRepository.GetUsuarioByEmailAsync(email);
            if (usuario == null) return null;

            return new UsuariosDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                RolId = usuario.RolId,
                Estado = usuario.Estado,
                FechaRegistro = usuario.FechaRegistro
            };
        }

        public async Task<UsuariosDTO?> GetUsuarioByUsernameAsync(string username)
        {
            var usuario = await _usuariosRepository.GetUsuarioByUsernameAsync(username);
            if (usuario == null) return null;

            return new UsuariosDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                RolId = usuario.RolId,
                Estado = usuario.Estado,
                FechaRegistro = usuario.FechaRegistro
            };
        }

        public async Task<IEnumerable<UsuariosDTO>> GetUsuariosByRoleIdAsync(int roleId)
        {
            var usuarios = await _usuariosRepository.GetUsuariosByRoleIdAsync(roleId);
            return usuarios.Select(u => new UsuariosDTO
            {
                UsuarioId = u.UsuarioId,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                RolId = u.RolId,
                Estado = u.Estado,
                FechaRegistro = u.FechaRegistro
            });
        }

        public async Task<UsuariosDTO> CreateUsuarioAsync(UsuariosCreateDTO dto)
        {
            var nuevo = new Usuarios
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                RolId = dto.RolId,
                Estado = true,
                FechaRegistro = DateTime.UtcNow,
                Contraseña = "123456" // <- Aquí podrías poner una contraseña por defecto encriptada o manejarlo con lógica externa
            };

            var creado = await _usuariosRepository.CreateUsuarioAsync(nuevo);

            return new UsuariosDTO
            {
                UsuarioId = creado.UsuarioId,
                Nombre = creado.Nombre,
                Apellido = creado.Apellido,
                Correo = creado.Correo,
                RolId = creado.RolId,
                Estado = creado.Estado,
                FechaRegistro = creado.FechaRegistro
            };
        }

        public async Task<UsuariosDTO?> UpdateUsuarioAsync(UsuariosUpdateDTO dto)
        {
            var usuario = new Usuarios
            {
                UsuarioId = dto.UsuarioId,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                RolId = dto.RolId,
                Estado = dto.Estado
            };

            var actualizado = await _usuariosRepository.UpdateUsuarioAsync(usuario);
            if (actualizado == null) return null;

            return new UsuariosDTO
            {
                UsuarioId = actualizado.UsuarioId,
                Nombre = actualizado.Nombre,
                Apellido = actualizado.Apellido,
                Correo = actualizado.Correo,
                RolId = actualizado.RolId,
                Estado = actualizado.Estado,
                FechaRegistro = actualizado.FechaRegistro
            };
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            return await _usuariosRepository.DeleteUsuarioAsync(id);
        }
    }
}
