using Sistema_de_Pagos_La_Perla.Models;

public class Asignacion
{
    public int AsignacionID { get; set; }
    public int FundoID { get; set; }
    public Fundo Fundo { get; set; } = new Fundo();
    public string Tarea { get; set; } = string.Empty;
    public decimal? Descuento { get; set; }
    public decimal Tarifa { get; set; }
    public string? Descripcion { get; set; }
    public string Turno { get; set; } = string.Empty;
    public string UsuarioRegistro { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public DateTime FechaAsignacion { get; set; }
    public bool Estado { get; set; } = true;
    public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
}
