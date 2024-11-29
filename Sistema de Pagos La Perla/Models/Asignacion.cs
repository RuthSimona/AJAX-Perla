using Sistema_de_Pagos_La_Perla.Models;

public class Asignacion
{
    public int AsignacionID { get; set; }
    public DateTime FechaAsignacion { get; set; }
    public int FundoID { get; set; }
    public Fundo Fundo { get; set; } = new Fundo();
    public string Tarea { get; set; } = string.Empty;
    public decimal? Descuento { get; set; }
    public decimal Tarifa { get; set; }
    public string? Descripcion { get; set; }
    public string Turno { get; set; } = string.Empty;
    public string UsuarioRegistro { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public bool Estado { get; set; } = true;
    [Newtonsoft.Json.JsonIgnore] // Ignorar en serialización para evitar problemas
    public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
}
