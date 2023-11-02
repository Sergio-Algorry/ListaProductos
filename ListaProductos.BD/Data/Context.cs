using ListaProductos.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaProductos.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

    }
}
