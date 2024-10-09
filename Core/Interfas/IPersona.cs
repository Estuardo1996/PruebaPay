using Core.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfas
{
    public interface IPersona
    {
        Task<Persona> GetByIdAsync(int id);
        Task<IEnumerable<Persona>> GetAllAsync();
        Task <string> AddAsync(Persona persona);
        Task<string> UpdateAsync(Persona persona);
        Task<string> DeleteAsync(int id);
    }
}
