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
    public class AccesosService : IAccesosService
    {
        private readonly IAccesosRepository _accesosRepository;

        public AccesosService(IAccesosRepository accesosRepository)
        {
            _accesosRepository = accesosRepository;
        }

        public async Task<IEnumerable<AccesosDTO>> GetAllAccesosAsync()
        {
            var accesos = await _accesosRepository.GetAllAccesosAsync();
            return accesos.Select(a => new AccesosDTO
            {
                AccesoId = a.AccesoId,
                UsuarioId = a.UsuarioId,
                FechaHoraAcceso = a.FechaHoraAcceso
            });
        }

        public async Task<AccesosDTO?> GetAccesoByIdAsync(int id)
        {
            var acceso = await _accesosRepository.GetAccesoByIdAsync(id);
            if (acceso == null) return null;
            return new AccesosDTO
            {
                AccesoId = acceso.AccesoId,
                UsuarioId = acceso.UsuarioId,
                FechaHoraAcceso = acceso.FechaHoraAcceso
            };
        }

        public async Task<IEnumerable<AccesosUsuarioDTO>> GetAccesosByUsuarioAsync(int usuarioId)
        {
            var accesos = await _accesosRepository.GetAllAccesosAsync();
            return accesos.Where(a => a.UsuarioId == usuarioId).Select(a => new AccesosUsuarioDTO
            {
                AccesoId = a.AccesoId,
                UsuarioNombre = a.Usuario?.Nombre, // Assuming Usuario is an entity with Nombre property
                FechaHoraAcceso = a.FechaHoraAcceso
            });
        }
        public async Task<IEnumerable<AccesosFechaDTO>> GetAccesosByFechaAsync(DateTime fecha)
        {
            var accesos = await _accesosRepository.GetAllAccesosAsync();
            return accesos.Where(a => a.FechaHoraAcceso.HasValue && a.FechaHoraAcceso.Value.Date == fecha.Date).Select(a => new AccesosFechaDTO
            {
                UsuarioId = a.UsuarioId,
                UsuarioNombre = a.Usuario?.Nombre, // Assuming Usuario is an entity with Nombre property
                FechaHoraAcceso = a.FechaHoraAcceso
            });
        }

        public async Task<AccesosDTO> CreateAccesoAsync(AccesosCreateDTO accesoCreateDto)
        {
            var acceso = new Accesos
            {
                UsuarioId = accesoCreateDto.UsuarioId,
                FechaHoraAcceso = accesoCreateDto.FechaHoraAcceso
            };
            var createdAcceso = await _accesosRepository.CreateAccesoAsync(acceso);
            return new AccesosDTO
            {
                AccesoId = createdAcceso.AccesoId,
                UsuarioId = createdAcceso.UsuarioId,
                FechaHoraAcceso = createdAcceso.FechaHoraAcceso
            };
        }
        public async Task<bool> UpdateAccesoAsync(int id, AccesosDTO accesoDto)
        {
            if (id != accesoDto.AccesoId)
            {
                throw new ArgumentException("Acceso ID mismatch");
            }
            var acceso = new Accesos
            {
                AccesoId = accesoDto.AccesoId,
                UsuarioId = accesoDto.UsuarioId,
                FechaHoraAcceso = accesoDto.FechaHoraAcceso
            };
            return await _accesosRepository.UpdateAccesoAsync(acceso);
        }
        public async Task<bool> DeleteAccesoAsync(int id)
        {
            return await _accesosRepository.DeleteAccesosAsync(id);

        }

    }

}

