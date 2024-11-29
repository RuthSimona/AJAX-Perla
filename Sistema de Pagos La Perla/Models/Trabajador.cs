using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Pagos_La_Perla.Models
{
    public class Trabajador
    {
        // Clave primaria
        public int TrabajadorID { get; set; }

        // Nombre completo del trabajador, es obligatorio
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        // RUT único del trabajador, obligatorio y con validación de longitud
        [Required(ErrorMessage = "El RUT es obligatorio.")]
        [MaxLength(15, ErrorMessage = "El RUT no puede superar los 15 caracteres.")]
        public string Rut { get; set; } = string.Empty;

        // Fecha de nacimiento opcional
        [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no tiene un formato válido.")]
        public DateTime? FechaNacimiento { get; set; }

        // Usuario que registró al trabajador, opcional
        [MaxLength(50, ErrorMessage = "El usuario de registro no puede superar los 50 caracteres.")]
        public string? UsuarioRegistro { get; set; }

        // Fecha de registro automática, no requiere ingreso manual
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Estado del trabajador: Activo o Inactivo
        public bool Estado { get; set; }

        // Relación con Asistencia (1:N), inicializada para evitar errores de referencia nula
        public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
    }
}
