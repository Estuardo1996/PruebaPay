using Core.Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Context
{
    public class Data : DbContext
    {
        public Data(DbContextOptions<Data> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
