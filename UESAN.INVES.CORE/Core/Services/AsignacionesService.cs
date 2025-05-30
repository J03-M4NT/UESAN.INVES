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
    public class AsignacionesService : IAsignacionesService
    {
        private readonly IAsignacionesRepository _asignacionesRepository;

        public AsignacionesService(IAsignacionesRepository asignacionesRepository)
        {
            _asignacionesRepository = asignacionesRepository;
        }

        public async Task<IEnumerable<AsignacionesDTO>> GetAllAsignacionesAsync()
        {
            var asignaciones = await _asignacionesRepository.GetAllAsignacionesAsync();
            return asignaciones.Select(a => new AsignacionesDTO
            {
                AsignacionId = a.AsignacionId,
                UsuarioId = a.UsuarioId,
                PublicacionId = a.PublicacionId,
                Estado = a.Estado,
                FechaAsignacion = a.FechaAsignacion
            });
        }


        public async Task<AsignacionesDTO?> GetAsignacionByIdAsync(int id)
        {
            var asignacion = await _asignacionesRepository.GetAsignacionByIdAsync(id);
            if (asignacion == null) return null;
            return new AsignacionesDTO
            {
                AsignacionId = asignacion.AsignacionId,
                UsuarioId = asignacion.UsuarioId,
                PublicacionId = asignacion.PublicacionId,
                Estado = asignacion.Estado,
                FechaAsignacion = asignacion.FechaAsignacion
            };
        }

        public async Task<AsignacionesDTO> CreateAsignacionAsync(AsignacionesCreateDTO asignacionCreateDto)
        {
            var asignacion = new Asignaciones
            {
                UsuarioId = asignacionCreateDto.UsuarioId,
                PublicacionId = asignacionCreateDto.PublicacionId,
                Estado = asignacionCreateDto.Estado,
                FechaAsignacion = asignacionCreateDto.FechaAsignacion
            };
            var createdAsignacion = await _asignacionesRepository.CreateAsignacionAsync(asignacion);
            return new AsignacionesDTO
            {
                AsignacionId = createdAsignacion.AsignacionId,
                UsuarioId = createdAsignacion.UsuarioId,
                PublicacionId = createdAsignacion.PublicacionId,
                Estado = createdAsignacion.Estado,
                FechaAsignacion = createdAsignacion.FechaAsignacion
            };
        }

        public async Task<bool> DeleteAsignacionAsync(int id)
        {
            return await _asignacionesRepository.DeleteAsignacionAsync(id);
        }

        public async Task<AsignacionesDTO?> UpdateAsignacionAsync(AsignacionesUpdateDTO asignacionUpdateDto)
        {
            var asignacion = new Asignaciones
            {
                AsignacionId = asignacionUpdateDto.AsignacionId,
                Estado = asignacionUpdateDto.Estado,
                FechaAsignacion = asignacionUpdateDto.FechaAsignacion
            };
            var updatedAsignacion = await _asignacionesRepository.UpdateAsignacionAsync(asignacion);
            if (updatedAsignacion == null) return null;
            return new AsignacionesDTO
            {
                AsignacionId = updatedAsignacion.AsignacionId,
                UsuarioId = updatedAsignacion.UsuarioId,
                PublicacionId = updatedAsignacion.PublicacionId,
                Estado = updatedAsignacion.Estado,
                FechaAsignacion = updatedAsignacion.FechaAsignacion
            };
        }


    }
}
