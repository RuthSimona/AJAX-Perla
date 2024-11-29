using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Pagos_La_Perla.Models
{
    public class Fundo
    {
        public int FundoID { get; set; } // Clave primaria

        [Required(ErrorMessage = "El nombre del fundo es obligatorio.")]
        public string NombreFundo { get; set; } // Nombre del fundo

        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        public string Ubicacion { get; set; } // Dirección del fundo

        public string? Contacto { get; set; } // Persona de contacto (opcional)
        public string? Telefono { get; set; } // Teléfono del contato (opcional)

        public DateTime FechaRegistro { get; set; } = DateTime.Now; // Fecha de registro
        public bool Estado { get; set; } // Activo/Inactivo

        // Relación con Asignaciones (1:N)
        [Newtonsoft.Json.JsonIgnore] // Ignorar en serialización para evitar problemas
        public ICollection<Asignacion> Asignaciones { get; set; } = new List<Asignacion>();
    }
}
