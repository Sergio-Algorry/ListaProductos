using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaProductos.BE
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Decripcion { get; set; }
        public decimal Precio { get; set; }

        public string txtPrecio
        { 
            get 
            { 
                string pepe = Precio.ToString();
                return pepe;
            }   
        }
    }
}
