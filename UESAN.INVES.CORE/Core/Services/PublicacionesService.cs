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
    public class PublicacionesService : IPublicacionesService
    {
        private readonly IPublicacionesRepository _publicacionesRepository;

        public PublicacionesService(IPublicacionesRepository publicacionesRepository)
        {
            _publicacionesRepository = publicacionesRepository;
        }

        public async Task<IEnumerable<PublicacionesDTO>> GetAllPublicacionesAsync()
        {
            var publicaciones = await _publicacionesRepository.GetAllPublicacionesAsync();
            return publicaciones.Select(p => new PublicacionesDTO
            {
                PublicacionId = p.PublicacionId,
                Titulo = p.Nombre, // Asumiendo que "Nombre" es el título
                FechaPublicacion = p.FechaPublicacion.HasValue ? p.FechaPublicacion.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null
            });
        }

        public async Task<PublicacionesDTO?> GetPublicacionByIdAsync(int id)
        {
            var publicacion = await _publicacionesRepository.GetPublicacionByIdAsync(id);
            if (publicacion == null) return null;

            return new PublicacionesDTO
            {
                PublicacionId = publicacion.PublicacionId,
                Titulo = publicacion.Nombre,
                FechaPublicacion = publicacion.FechaPublicacion.HasValue ? publicacion.FechaPublicacion.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null
            };
        }

        public async Task<PublicacionesDTO> CreatePublicacionAsync(PublicacionesCreateDTO dto)
        {
            var publicacion = new Publicaciones
            {
                Nombre = dto.Titulo,
                FechaPublicacion = dto.FechaPublicacion.HasValue
                    ? DateOnly.FromDateTime(dto.FechaPublicacion.Value)
                    : (DateOnly?)null
            };

            var creada = await _publicacionesRepository.CreatePublicacionAsync(publicacion);

            return new PublicacionesDTO
            {
                PublicacionId = creada.PublicacionId,
                Titulo = creada.Nombre,
                FechaPublicacion = creada.FechaPublicacion.HasValue ? creada.FechaPublicacion.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null
            };
        }

        public async Task<PublicacionesDTO?> UpdatePublicacionAsync(PublicacionesUpdateDTO dto)
        {
            var publicacion = new Publicaciones
            {
                PublicacionId = dto.PublicacionId,
                Nombre = dto.Titulo,
                FechaPublicacion = dto.FechaPublicacion.HasValue
                    ? DateOnly.FromDateTime(dto.FechaPublicacion.Value)
                    : (DateOnly?)null
            };

            var actualizada = await _publicacionesRepository.UpdatePublicacionAsync(publicacion);
            if (actualizada == null) return null;

            return new PublicacionesDTO
            {
                PublicacionId = actualizada.PublicacionId,
                Titulo = actualizada.Nombre,
                FechaPublicacion = actualizada.FechaPublicacion.HasValue ? actualizada.FechaPublicacion.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null
            };
        }

        public async Task<bool> DeletePublicacionAsync(int id)
        {
            return await _publicacionesRepository.DeletePublicacionAsync(id);
        }

        public async Task<IEnumerable<PublicacionesResumenDTO>> GetResumenPublicacionesAsync()
        {
            var publicaciones = await _publicacionesRepository.GetAllPublicacionesAsync();
            return publicaciones.Select(p => new PublicacionesResumenDTO
            {
                PublicacionId = p.PublicacionId,
                Titulo = p.Nombre,
                FechaPublicacion = p.FechaPublicacion.HasValue
                    ? p.FechaPublicacion.Value.ToDateTime(new TimeOnly(0))
                    : (DateTime?)null
            });
        }


    }
}
