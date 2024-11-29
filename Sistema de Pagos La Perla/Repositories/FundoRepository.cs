using Microsoft.EntityFrameworkCore;
using Sistema_de_Pagos_La_Perla.Data;
using Sistema_de_Pagos_La_Perla.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema_de_Pagos_La_Perla.Repositories
{
    public class FundoRepository : IRepository<Fundo>
    {
        private readonly GestionPagosContext _context;

        public FundoRepository(GestionPagosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fundo>> GetAllAsync()
        {
            return await _context.Fundos.ToListAsync();
        }

        public async Task<Fundo> GetByIdAsync(int id)
        {
            return await _context.Fundos.FindAsync(id);
        }

        public async Task AddAsync(Fundo entity)
        {
            await _context.Fundos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fundo entity)
        {
            _context.Fundos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fundo = await GetByIdAsync(id);
            if (fundo != null)
            {
                _context.Fundos.Remove(fundo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
