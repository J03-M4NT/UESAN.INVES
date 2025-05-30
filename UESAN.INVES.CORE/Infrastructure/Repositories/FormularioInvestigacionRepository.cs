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
    public class FormularioInvestigacionRepository : IFormularioInvestigacionRepository
    {

        private readonly VdiIntranetContext _context;
        public FormularioInvestigacionRepository(VdiIntranetContext context)
        {
            _context = context;
        }

        //Get all formulariosInvestigacion
        public IEnumerable<FormularioInvestigacion> GetAllFormulariosInvestigacion()
        {
            var formularios = _context.FormularioInvestigacion.ToList();
            return formularios;
        }
        //get all formulariosInvestigacion async
        public async Task<List<FormularioInvestigacion>> GetAllFormulariosInvestigacionAsync()
        {
            return await _context.FormularioInvestigacion.ToListAsync();
        }
        //get formularioInvestigacion by id async
        public async Task<FormularioInvestigacion?> GetFormularioInvestigacionByIdAsync(int id)
        {
            var formulario = await _context.FormularioInvestigacion.FirstOrDefaultAsync(f => f.FormularioId == id);
            return formulario;
        }

        // Get all formulariosInvestigacion by user id async
        public async Task<List<FormularioInvestigacion>> GetFormulariosByUserIdAsync(int userId)
        {
            return await _context.FormularioInvestigacion
                .Include(f => f.Asignacion)
                .Where(f => f.Asignacion != null && f.Asignacion.UsuarioId == userId)
                .ToListAsync();
        }

        //create formularioInvestigacion async
        public async Task<FormularioInvestigacion> CreateFormularioInvestigacionAsync(FormularioInvestigacion formulario)
        {
            _context.FormularioInvestigacion.Add(formulario);
            await _context.SaveChangesAsync();
            return formulario;
        }
        //delete formularioInvestigacion async
        public async Task<bool> DeleteFormularioInvestigacionAsync(int id)
        {
            var formulario = await _context.FormularioInvestigacion.FindAsync(id);
            if (formulario == null)
            {
                return false;
            }
            _context.FormularioInvestigacion.Remove(formulario);
            await _context.SaveChangesAsync();
            return true;
        }
        //update formularioInvestigacion async
        public async Task<bool> UpdateFormularioInvestigacionAsync(FormularioInvestigacion formulario)
        {
            var existingFormulario = await _context.FormularioInvestigacion.FindAsync(formulario.FormularioId);
            if (existingFormulario == null)
            {
                return false;
            }

            existingFormulario.Dni = formulario.Dni;
            existingFormulario.Apellidos = formulario.Apellidos;
            existingFormulario.Nombres = formulario.Nombres;
            existingFormulario.GradoAcademico = formulario.GradoAcademico;
            existingFormulario.FechaSolicitud = formulario.FechaSolicitud;
            existingFormulario.PosgradoPregrado = formulario.PosgradoPregrado;
            existingFormulario.RegimenDedicacion = formulario.RegimenDedicacion;
            existingFormulario.CategoriaRenacyt = formulario.CategoriaRenacyt;
            existingFormulario.TituloProyecto = formulario.TituloProyecto;
            existingFormulario.NombrePublicacion = formulario.NombrePublicacion;
            existingFormulario.EditorialUniversidad = formulario.EditorialUniversidad;
            existingFormulario.Pais = formulario.Pais;
            existingFormulario.IssnIsbn = formulario.IssnIsbn;
            existingFormulario.MontoApc = formulario.MontoApc;
            existingFormulario.LineaInvestigacion = formulario.LineaInvestigacion;

            _context.FormularioInvestigacion.Update(existingFormulario);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}
