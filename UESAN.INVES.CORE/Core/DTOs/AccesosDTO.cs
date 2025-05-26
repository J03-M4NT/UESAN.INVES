using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Core.DTOs
{
    public class AccesosDTO
    {
        public int AccesoId { get; set; }

        public int? UsuarioId { get; set; }

        public DateTime? FechaHoraAcceso { get; set; }

        public virtual Usuarios? Usuario { get; set; }
    }

    public class AccesosIdDTO
    {
        public int AccesoId { get; set; }

        public int? UsuarioId { get; set; }
    }

    public class AccesosUsuarioDTO
    {
        public int AccesoId { get; set; }
        public string? UsuarioNombre { get; set; }
        public DateTime? FechaHoraAcceso { get; set; }
    }

    public class AccesosFechaDTO
    {
        public int? UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }

        public DateTime? FechaHoraAcceso { get; set; }

    }

    public class AccesosCreateDTO
    {
        public int? UsuarioId { get; set; }
        public DateTime? FechaHoraAcceso { get; set; }
    }


}