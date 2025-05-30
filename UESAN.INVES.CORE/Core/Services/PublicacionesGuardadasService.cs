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
    public class PublicacionesGuardadasService : IPublicacionesGuardadasService
    {
        private readonly IPublicacionesGuardadasRepository _publicacionesGuardadasRepository;

        public PublicacionesGuardadasService(IPublicacionesGuardadasRepository publicacionesGuardadasRepository)
        {
            _publicacionesGuardadasRepository = publicacionesGuardadasRepository;
        }

        public async Task<IEnumerable<PublicacionesGuardadasDTO>> GetAllAsync()
        {
            var guardadas = await _publicacionesGuardadasRepository.GetAllPublicacionesGuardadasAsync();
            return guardadas.Select(pg => new PublicacionesGuardadasDTO
            {
                Id = pg.Id,
                UsuarioId = pg.UsuarioId,
                PublicacionId = pg.PublicacionId,
                FechaGuardado = pg.FechaGuardado
            });
        }

        public async Task<PublicacionesGuardadasDTO?> GetByIdAsync(int id)
        {
            var guardada = await _publicacionesGuardadasRepository.GetPublicacionGuardadaByIdAsync(id);
            if (guardada == null)
                return null;

            return new PublicacionesGuardadasDTO
            {
                Id = guardada.Id,
                UsuarioId = guardada.UsuarioId,
                PublicacionId = guardada.PublicacionId,
                FechaGuardado = guardada.FechaGuardado
            };
        }

        public async Task<IEnumerable<PublicacionesGuardadasDTO>> GetByUserIdAsync(int userId)
        {
            var guardadas = await _publicacionesGuardadasRepository.GetPublicacionesGuardadasByUserIdAsync(userId);
            return guardadas.Select(pg => new PublicacionesGuardadasDTO
            {
                Id = pg.Id,
                UsuarioId = pg.UsuarioId,
                PublicacionId = pg.PublicacionId,
                FechaGuardado = pg.FechaGuardado
            });
        }

        public async Task<PublicacionesGuardadasDTO?> CreateAsync(PublicacionesGuardadasCreateDTO dto)
        {
            var nueva = new PublicacionesGuardadas
            {
                UsuarioId = dto.UsuarioId,
                PublicacionId = dto.PublicacionId,
                FechaGuardado = dto.FechaGuardado ?? DateTime.Now
            };

            var creada = await _publicacionesGuardadasRepository.CreateAsync(nueva);
            if (creada == null) return null;

            return new PublicacionesGuardadasDTO
            {
                Id = creada.Id,
                UsuarioId = creada.UsuarioId,
                PublicacionId = creada.PublicacionId,
                FechaGuardado = creada.FechaGuardado
            };
        }

        public async Task<bool> UpdateAsync(PublicacionesGuardadasUpdateDTO dto)
        {
            var actualizada = new PublicacionesGuardadas
            {
                Id = dto.Id,
                UsuarioId = dto.UsuarioId,
                PublicacionId = dto.PublicacionId,
                FechaGuardado = dto.FechaGuardado
            };

            return await _publicacionesGuardadasRepository.UpdateAsync(actualizada);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _publicacionesGuardadasRepository.DeletePublicacionGuardadaAsync(id);
        }

        public async Task<bool> IsGuardadaAsync(int publicacionId, int userId)
        {
            return await _publicacionesGuardadasRepository.IsPublicacionGuardadaByUserAsync(publicacionId, userId);
        }
    }
}
