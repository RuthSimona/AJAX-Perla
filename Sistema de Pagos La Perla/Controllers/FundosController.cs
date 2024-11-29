using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Pagos_La_Perla.Data;
using Sistema_de_Pagos_La_Perla.Models;

namespace Sistema_de_Pagos_La_Perla.Controllers
{
    public class FundosController : Controller
    {
        private readonly GestionPagosContext _context;

        public FundosController(GestionPagosContext context)
        {
            _context = context;
        }

        // Vista principal
        public IActionResult Index()
        {
            return View();
        }

        // Devuelve la lista de fundos para DataTables
        [HttpGet]
        public JsonResult ListaFundos()
        {
            try
            {
                var fundos = _context.Fundos
                    .Select(f => new
                    {
                        f.FundoID,
                        f.NombreFundo,
                        f.Ubicacion,
                        f.Contacto,
                        f.Telefono,
                        Estado = f.Estado ? "✔️ Activo" : "❌ Inactivo",
                        FechaRegistro = f.FechaRegistro.ToString("dd/MM/yyyy")
                    })
                    .ToList();

                return Json(new { data = fundos });
            }
            catch (Exception ex)
            {
                return Json(new { error = $"Error al obtener la lista: {ex.Message}" });
            }
        }

        // Crear o editar un fundo
        [HttpPost]
        public JsonResult Guardar([FromBody] Fundo model)
        {
            bool respuesta = false;
            string mensaje;

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.FundoID == 0) // Crear
                    {
                        _context.Fundos.Add(model);
                        mensaje = "Fundo creado correctamente.";
                    }
                    else // Editar
                    {
                        var fundoExistente = _context.Fundos.FirstOrDefault(f => f.FundoID == model.FundoID);
                        if (fundoExistente != null)
                        {
                            fundoExistente.NombreFundo = model.NombreFundo;
                            fundoExistente.Ubicacion = model.Ubicacion;
                            fundoExistente.Contacto = model.Contacto;
                            fundoExistente.Telefono = model.Telefono;
                            fundoExistente.Estado = model.Estado;
                            mensaje = "Fundo actualizado correctamente.";
                        }
                        else
                        {
                            mensaje = "El fundo especificado no existe.";
                            return Json(new { respuesta, mensaje });
                        }
                    }

                    _context.SaveChanges();
                    respuesta = true;
                }
                else
                {
                    var errores = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    mensaje = "Errores de validación: " + string.Join(", ", errores);
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error interno: {ex.Message}";
            }

            return Json(new { respuesta, mensaje });
        }

        // Eliminar un fundo
        [HttpDelete]
        public JsonResult Eliminar(int id)
        {
            bool respuesta = false;
            string mensaje;

            try
            {
                var fundo = _context.Fundos.FirstOrDefault(f => f.FundoID == id);
                if (fundo != null)
                {
                    _context.Fundos.Remove(fundo);
                    _context.SaveChanges();
                    respuesta = true;
                    mensaje = "Fundo eliminado correctamente.";
                }
                else
                {
                    mensaje = "El fundo especificado no existe.";
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error interno: {ex.Message}";
            }

            return Json(new { respuesta, mensaje });
        }
    }
}
