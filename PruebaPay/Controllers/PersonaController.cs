using Core.Entidad;
using Core.Interfas;
using Infraestructura.Context;
using Microsoft.AspNetCore.Mvc;

namespace PruebaPay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersona _context;

        public PersonaController(IPersona context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetAll()
        {
            var persons = await _context.GetAllAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Add(Persona persona)
        {
            var result = await _context.AddAsync(persona);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetById(int id)
        {
            var person = await _context.GetByIdAsync(id);
            return Ok(person);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Update(int id, [FromBody] Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest("ID mismatch");
            }

            var result = await _context.UpdateAsync(persona);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var result = await _context.DeleteAsync(id);
            return Ok(result);
        }

    }
}
