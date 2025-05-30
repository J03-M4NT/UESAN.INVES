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
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public async Task<IEnumerable<RolesDTO>> GetAllRolesAsync()
        {
            var roles = await _rolesRepository.GetAllRolesAsync();
            return roles.Select(r => new RolesDTO
            {
                RolId = r.RolId,
                NombreRol = r.NombreRol
            });
        }

        public async Task<RolesDTO?> GetRoleByIdAsync(int id)
        {
            var role = await _rolesRepository.GetRoleByIdAsync(id);
            if (role == null)
                return null;

            return new RolesDTO
            {
                RolId = role.RolId,
                NombreRol = role.NombreRol
            };
        }

        public async Task<IEnumerable<RolesDTO>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _rolesRepository.GetRolesByUserIdAsync(userId);
            return roles.Select(r => new RolesDTO
            {
                RolId = r.RolId,
                NombreRol = r.NombreRol
            });
        }

        public async Task<RolesDTO> CreateRoleAsync(RolesCreateDTO dto)
        {
            var newRole = new Roles
            {
                NombreRol = dto.NombreRol
            };

            var created = await _rolesRepository.CreateRoleAsync(newRole);
            return new RolesDTO
            {
                RolId = created.RolId,
                NombreRol = created.NombreRol
            };
        }

        public async Task<RolesDTO?> UpdateRoleAsync(RolesUpdateDTO dto)
        {
            var role = new Roles
            {
                RolId = dto.RolId,
                NombreRol = dto.NombreRol
            };

            var updated = await _rolesRepository.UpdateRoleAsync(role);
            if (updated == null)
                return null;

            return new RolesDTO
            {
                RolId = updated.RolId,
                NombreRol = updated.NombreRol
            };
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _rolesRepository.DeleteRoleAsync(id);
        }
    }
}
