namespace Sistema_de_Pagos_La_Perla.Models
{
    public class Asistencia
    {
        public int AsistenciaID { get; set; } // Clave primaria
        public DateTime FechaAsistencia { get; set; } // Fecha principal para guiar la asistencia
        public int AsignacionID { get; set; } // Relación con Asignaciones
        public Asignacion Asignacion { get; set; } // Propiedad de navegación
        public int TrabajadorID { get; set; } // Relación con Trabajadores
        public Trabajador Trabajador { get; set; } // Propiedad de navegación
        public int? CantidadCompletada { get; set; } // Cantidad de trabajo completada
        public string UsuarioRegistro { get; set; } // Usuario que registró la asistencia
        public DateTime FechaRegistro { get; set; } = DateTime.Now; // Fecha de registro
        public string Estado { get; set; } // Estado de la asistencia (asistió, falta)
    }
}
