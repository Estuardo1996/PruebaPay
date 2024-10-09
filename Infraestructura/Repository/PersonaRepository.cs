using Core.Entidad;
using Core.Interfas;
using Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repository
{
    public class PersonaRepository : IPersona
    {
        private readonly Data _context;

        public PersonaRepository(Data context)
        {
            _context = context;
        }
        public async Task<string> AddAsync(Core.Entidad.Persona persona)
        {

            Persona persona1 = new Persona
            {
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Email = persona.Email,
                FechaNacimiento = persona.FechaNacimiento,
                Direccion = persona.Direccion
            };
            _context.Personas.Add(persona1);
             await _context.SaveChangesAsync();
            
            return ("Proceso Exitoso");

        }

        public async Task<string> DeleteAsync(int id)
        {
            var persona1 = _context.Personas.Where(x => x.Id == id).FirstAsync().Result;

           _context.Personas.Remove(persona1);
            await _context.SaveChangesAsync();

            return ("Proceso Exitoso");
        }

        public async Task<IEnumerable<Core.Entidad.Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Core.Entidad.Persona> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<string> UpdateAsync(Core.Entidad.Persona persona)
        {
            var existingPersona = await _context.Personas.FindAsync(persona.Id);
            if (existingPersona == null)
            {
                return "Persona not found";
            }

            existingPersona.Nombre = persona.Nombre;
            existingPersona.Apellido = persona.Apellido;
            existingPersona.Email = persona.Email;
            existingPersona.FechaNacimiento = persona.FechaNacimiento;
            existingPersona.Direccion = persona.Direccion;

            await _context.SaveChangesAsync();

            return "Persona updated successfully";
        }

      
    }
}
