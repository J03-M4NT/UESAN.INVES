using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.INVES.CORE.Core.DTOs;
using UESAN.INVES.CORE.Core.Entities;
using UESAN.INVES.CORE.Core.Interfaces;
using UESAN.INVES.CORE.Infrastructure.Shared;

namespace UESAN.INVES.CORE.Core.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly JwtServices _jwtServices;

        public UsuariosService(IUsuariosRepository usuariosRepository, IRolesRepository rolesRepository, JwtServices jwtServices)
        {
            _usuariosRepository = usuariosRepository;
            _rolesRepository = rolesRepository;
            _jwtServices = jwtServices;
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
                Estado = u.Estado
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
                Estado = usuario.Estado
            };
        }


        public async Task<int> CreateUsuarioAsync(UsuariosCreateDTO dto)
        {
            var usuario = new Usuarios
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                Contraseña = dto.Contraseña, // Consider hashing the password
                RolId = dto.RolId,
                Estado = dto.Estado
            };

            var createdUsuario = await _usuariosRepository.CreateUsuarioAsync(usuario);
            return createdUsuario.UsuarioId; // Ensure the repository returns the created entity, and extract its ID.
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            return await _usuariosRepository.DeleteUsuarioAsync(id);
        }

        public async Task<bool> UpdateUsuarioAsync(UsuariosUpdateDTO dto)
        {
            var usuario = await _usuariosRepository.GetUsuarioByIdAsync(dto.UsuarioId);
            if (usuario == null) return false;
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Correo = dto.Correo;
            usuario.RolId = dto.RolId;
            usuario.Estado = dto.Estado;
            await _usuariosRepository.UpdateUsuarioAsync(usuario);
            return true;
        }

        public async Task<SignInResponseDTO> SignInAsync(SignInDTO signInDto)
        {
            var usuario = await _usuariosRepository.GetUsuarioByEmailAsync(signInDto.Correo);
            if (usuario == null || usuario.Contraseña != signInDto.Contraseña)
                return null!;

            // Asegúrate de incluir el rol completo si no está cargado
            var rol = await _rolesRepository.GetByIdAsync(usuario.RolId);
            usuario.Rol = rol!;

            var token = _jwtServices.GenerateToken(usuario);

            return new SignInResponseDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre ?? "",
                Apellido = usuario.Apellido ?? "",
                Correo = usuario.Correo,
                RolId = usuario.RolId,
                NombreRol = rol?.NombreRol ?? "Desconocido",
                Estado = usuario.Estado ?? false,
                Token = token
            };
        }


    }
}
