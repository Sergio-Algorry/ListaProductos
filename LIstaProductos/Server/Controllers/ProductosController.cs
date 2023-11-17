using ListaProductos.BD.Data;
using ListaProductos.BD.Data.Entity;
using LIstaProductos.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LIstaProductos.Server.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly Context context;

        public ProductosController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()  //api/productos
        {
            return await context.Productos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> GetById(int id)   //api/productos/2
        {
            bool existe = await context.Productos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El producto de id={id} no existe en la base de datos");
            }

            return await context.Productos.FirstOrDefaultAsync(x => x.Id==id);
        }

        [HttpGet("{cod}")]
        public async Task<ActionResult<Producto>> GetByCod(string cod)  //api/productos/ABA
        {
            bool existe = await context.Productos.AnyAsync(x => x.Codigo == cod);
            if (!existe)
            {
                return NotFound($"El producto de código={cod} no existe en la base de datos");
            }

            return await context.Productos.FirstOrDefaultAsync(x => x.Codigo == cod);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ProductoDTO entidad)
        {
            Producto prod = new Producto();
            prod.Nombre = entidad.Nombre;
            prod.Codigo = entidad.Codigo;
            prod.Precio = entidad.Precio;

            context.Add(prod);
            await context.SaveChangesAsync();

            return prod.Id;

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ProductoDTO entidad, int id)
        {
            if(id==0)
            {
                return BadRequest("Número de Id incorrecto");
            }

            bool existe = await context.Productos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El producto de id={id} no existe en la base de datos");
            }

            Producto prod = new Producto();
            prod.Id = id;
            prod.Nombre = entidad.Nombre;
            prod.Codigo = entidad.Codigo;
            prod.Precio = entidad.Precio;

            context.Update(prod);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool existe = await context.Productos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El producto de id={id} no existe en la base de datos");
            }

            Producto prod = new Producto();

            prod.Id = id;

            context.Remove(prod);

            await context.SaveChangesAsync();

            return Ok();

        }

    }
}