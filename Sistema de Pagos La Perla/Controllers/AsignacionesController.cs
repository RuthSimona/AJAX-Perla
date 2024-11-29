using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Pagos_La_Perla.Data;
using Sistema_de_Pagos_La_Perla.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Pagos_La_Perla.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly GestionPagosContext _context;

        public AsignacionesController(GestionPagosContext context)
        {
            _context = context;
        }

        // Acción principal para mostrar la vista Index
        public IActionResult Index()
        {
            return View();
        }

        // Obtener lista de asignaciones para DataTables (operación asincrónica)
        [HttpGet]
        public async Task<IActionResult> ListaAsignaciones()
        {
            var asignaciones = await _context.Asignaciones
                .Include(a => a.Fundo)
                .Select(a => new
                {
                    asignacionID = a.AsignacionID,
                    fechaAsignacion = a.FechaAsignacion.ToString("dd/MM/yyyy"),
                    tarea = a.Tarea,
                    fundoNombre = a.Fundo != null ? a.Fundo.NombreFundo : "Sin fundo",
                    turno = a.Turno,
                    tarifa = a.Tarifa,
                    estado = a.Estado ? "Activo" : "Inactivo"
                })
                .ToListAsync();

            return Json(asignaciones);
        }

        // Obtener lista de Fundos con paginación y búsqueda
        [HttpGet]
        public async Task<IActionResult> ListaFundos(int start = 0, int length = 10, string search = "")
        {
            var query = _context.Fundos.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(f => f.NombreFundo.Contains(search) || f.Ubicacion.Contains(search));
            }

            var totalCount = await query.CountAsync();

            var fundos = await query.Skip(start).Take(length)
                .Select(f => new
                {
                    fundoID = f.FundoID,
                    nombreFundo = f.NombreFundo,
                    ubicacion = f.Ubicacion,
                    contacto = f.Contacto
                })
                .ToListAsync();

            return Json(new { draw = 1, recordsTotal = totalCount, recordsFiltered = totalCount, data = fundos });
        }

        // Guardar asignación (crear o editar)
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Asignacion asignacion)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { respuesta = false, mensaje = "Datos inválidos", errores = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            try
            {
                // Validar que FundoID exista
                var fundoExiste = await _context.Fundos.AnyAsync(f => f.FundoID == asignacion.FundoID);
                if (!fundoExiste)
                {
                    return Json(new { respuesta = false, mensaje = "El Fundo seleccionado no existe." });
                }

                if (asignacion.AsignacionID == 0)
                {
                    // Crear nueva asignación
                    await _context.Asignaciones.AddAsync(asignacion);
                }
                else
                {
                    // Editar asignación existente
                    _context.Asignaciones.Update(asignacion);
                }

                await _context.SaveChangesAsync();
                return Json(new { respuesta = true, mensaje = "Asignación guardada con éxito." });
            }
            catch (Exception ex)
            {
                // Log para depuración
                Console.WriteLine(ex.Message);
                return Json(new { respuesta = false, mensaje = $"Error al guardar: {ex.Message}" });
            }
        }
    }
}
