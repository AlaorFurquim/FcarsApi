using Fcar.Application;
using Fcar.Domain.Enitites;
using Fcar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcar.Infrastructure
{
    public class ModeloRepository : IMarcaRepositoty
    {
        private readonly AppDbContext _context;

        public ModeloRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marca>> GetAllAsync()
            => await _context.Marcas.Include(c => c.Modelos).ToListAsync();

        public async Task<Marca?> GetByIdAsync(int id)
           => await _context.Marcas.Include(c => c.Modelos).FirstOrDefaultAsync(c => c.Id == id);

        public async Task AddAsync(Marca marca)
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Marca marca)
        {
            _context.Marcas.Update(marca);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if(marca != null)
            {
                _context.Marcas.Remove(marca);
                await _context.SaveChangesAsync();
            }
           
        }
    }
}
