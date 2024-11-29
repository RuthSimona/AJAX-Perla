using Sistema_de_Pagos_La_Perla.Models;
using Sistema_de_Pagos_La_Perla.Repositories;

namespace Sistema_de_Pagos_La_Perla.Services
{
    public class TrabajadorService
    {
        private readonly TrabajadorRepository _repository;

        public TrabajadorService(TrabajadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Trabajador>> ObtenerTodosAsync()
        {
            return await _repository.ObtenerTodosAsync();
        }

        public async Task<bool> GuardarAsync(Trabajador trabajador)
        {
            if (trabajador.TrabajadorID == 0)
            {
                return await _repository.CrearAsync(trabajador);
            }
            else
            {
                return await _repository.ActualizarAsync(trabajador);
            }
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repository.EliminarAsync(id);
        }
    }
}
