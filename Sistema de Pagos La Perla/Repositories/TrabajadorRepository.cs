using Microsoft.EntityFrameworkCore;
using Sistema_de_Pagos_La_Perla.Data;
using Sistema_de_Pagos_La_Perla.Models;

namespace Sistema_de_Pagos_La_Perla.Repositories
{
    public class TrabajadorRepository
    {
        private readonly GestionPagosContext _context;

        public TrabajadorRepository(GestionPagosContext context)
        {
            _context = context;
        }

        public async Task<List<Trabajador>> ObtenerTodosAsync()
        {
            return await _context.Trabajadores.ToListAsync();
        }

        public async Task<bool> CrearAsync(Trabajador trabajador)
        {
            _context.Trabajadores.Add(trabajador);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarAsync(Trabajador trabajador)
        {
            _context.Trabajadores.Update(trabajador);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);
            if (trabajador != null)
            {
                _context.Trabajadores.Remove(trabajador);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
