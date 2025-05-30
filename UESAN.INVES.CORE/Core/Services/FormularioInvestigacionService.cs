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
    public class FormularioInvestigacionService : IFormularioInvestigacionService
    {
        private readonly IFormularioInvestigacionRepository _formularioInvestigacionRepository;

        public FormularioInvestigacionService(IFormularioInvestigacionRepository formularioInvestigacionRepository)
        {
            _formularioInvestigacionRepository = formularioInvestigacionRepository;
        }

        public async Task<IEnumerable<FormularioInvestigacionDTO>> GetAllFormulariosAsync()
        {
            var formularios = await _formularioInvestigacionRepository.GetAllFormulariosInvestigacionAsync();
            return formularios.Select(f => new FormularioInvestigacionDTO
            {
                FormularioId = f.FormularioId,
                Dni = f.Dni,
                Apellidos = f.Apellidos,
                Nombres = f.Nombres,
                GradoAcademico = f.GradoAcademico,
                FechaSolicitud = f.FechaSolicitud,
                TituloProyecto = f.TituloProyecto
            });
        }

        public async Task<FormularioInvestigacionDTO?> GetFormularioByIdAsync(int id)
        {
            var f = await _formularioInvestigacionRepository.GetFormularioInvestigacionByIdAsync(id);
            if (f == null) return null;

            return new FormularioInvestigacionDTO
            {
                FormularioId = f.FormularioId,
                Dni = f.Dni,
                Apellidos = f.Apellidos,
                Nombres = f.Nombres,
                GradoAcademico = f.GradoAcademico,
                FechaSolicitud = f.FechaSolicitud,
                TituloProyecto = f.TituloProyecto
            };
        }

        public async Task<FormularioInvestigacionDTO> CreateFormularioAsync(FormularioInvestigacionCreateDTO dto)
        {
            var nuevo = new FormularioInvestigacion
            {
                Dni = dto.Dni,
                Apellidos = dto.Apellidos,
                Nombres = dto.Nombres,
                GradoAcademico = dto.GradoAcademico,
                FechaSolicitud = dto.FechaSolicitud ?? DateOnly.FromDateTime(DateTime.Now),
                TituloProyecto = dto.TituloProyecto
            };

            var creado = await _formularioInvestigacionRepository.CreateFormularioInvestigacionAsync(nuevo);

            return new FormularioInvestigacionDTO
            {
                FormularioId = creado.FormularioId,
                Dni = creado.Dni,
                Apellidos = creado.Apellidos,
                Nombres = creado.Nombres,
                GradoAcademico = creado.GradoAcademico,
                FechaSolicitud = creado.FechaSolicitud,
                TituloProyecto = creado.TituloProyecto
            };
        }

        public async Task<bool> UpdateFormularioAsync(FormularioInvestigacionUpdateDTO dto)
        {
            var actualizar = new FormularioInvestigacion
            {
                FormularioId = dto.FormularioId,
                Dni = dto.Dni,
                Apellidos = dto.Apellidos,
                Nombres = dto.Nombres,
                GradoAcademico = dto.GradoAcademico,
                FechaSolicitud = dto.FechaSolicitud ?? DateOnly.FromDateTime(DateTime.Now),
                TituloProyecto = dto.TituloProyecto
            };

            return await _formularioInvestigacionRepository.UpdateFormularioInvestigacionAsync(actualizar);
        }

        public async Task<bool> DeleteFormularioAsync(int id)
        {
            return await _formularioInvestigacionRepository.DeleteFormularioInvestigacionAsync(id);
        }
    }
}
