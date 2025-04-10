using Fcar.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcar.Application
{
    public interface IMarcaRepositoty
    {
        Task<IEnumerable<Marca>> GetAllAsync();
        Task<Marca?>GetByIdAsync(int id);
        Task AddAsync(Marca marca);
        Task UpdateAsync(Marca marca);
        Task DeleteAsync(int id);

    }
}
