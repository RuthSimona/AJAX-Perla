using Microsoft.AspNetCore.Mvc;
using Sistema_de_Pagos_La_Perla.Services;
using Sistema_de_Pagos_La_Perla.Models;

namespace Sistema_de_Pagos_La_Perla.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly TrabajadorService _service;

        public TrabajadoresController(TrabajadorService service)
        {
            _service = service;
        }

        // GET: Trabajadores (vista principal)
        public IActionResult Index()
        {
            return View();
        }

        // GET: Trabajadores/ListaTrabajadores (para DataTables)
        [HttpGet]
        public async Task<JsonResult> ListaTrabajadores()
        {
            var trabajadores = await _service.ObtenerTodosAsync();
            var resultado = trabajadores.Select(t => new
            {
                t.TrabajadorID,
                t.Nombre,
                t.Rut,
                FechaNacimiento = t.FechaNacimiento?.ToString("dd/MM/yyyy") ?? "-",
                FechaRegistro = t.FechaRegistro.ToString("dd/MM/yyyy"),
                Estado = t.Estado ? "Activo" : "Inactivo"
            });

            return Json(new { data = resultado });
        }

        // POST: Trabajadores/Guardar (crear o editar)
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] Trabajador model)
        {
            bool respuesta;
            string mensaje;

            try
            {
                respuesta = await _service.GuardarAsync(model);
                mensaje = respuesta ? "Trabajador guardado correctamente." : "Error al guardar el trabajador.";
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = $"Error interno: {ex.Message}";
            }

            return Json(new { respuesta, mensaje });
        }

        // DELETE: Trabajadores/Eliminar
        [HttpDelete]
        public async Task<JsonResult> Eliminar(int id)
        {
            bool respuesta;
            string mensaje;

            try
            {
                respuesta = await _service.EliminarAsync(id);
                mensaje = respuesta ? "Trabajador eliminado correctamente." : "Error al eliminar el trabajador.";
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = $"Error interno: {ex.Message}";
            }

            return Json(new { respuesta, mensaje });
        }
    }
}
