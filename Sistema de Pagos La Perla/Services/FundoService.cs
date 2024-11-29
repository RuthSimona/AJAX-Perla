using Sistema_de_Pagos_La_Perla.Models;
using Sistema_de_Pagos_La_Perla.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema_de_Pagos_La_Perla.Services
{
    public class FundoService
    {
        private readonly IRepository<Fundo> _repository;

        public FundoService(IRepository<Fundo> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Fundo>> ObtenerTodos()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Fundo> ObtenerPorId(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> Crear(Fundo fundo)
        {
            if (string.IsNullOrEmpty(fundo.NombreFundo) || string.IsNullOrEmpty(fundo.Ubicacion))
            {
                return false;
            }

            await _repository.AddAsync(fundo);
            return true;
        }

        public async Task<bool> Editar(Fundo fundo)
        {
            if (string.IsNullOrEmpty(fundo.NombreFundo) || string.IsNullOrEmpty(fundo.Ubicacion))
            {
                return false;
            }

            await _repository.UpdateAsync(fundo);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var fundo = await _repository.GetByIdAsync(id);
            if (fundo == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
