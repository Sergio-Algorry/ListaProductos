using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaProductos.BE
{
    public class ListaProducto
    {
        private int ProximoRenglon = 0;
        public Producto[] Productos { get; set; } = new Producto[3];

        public bool Agregar(Producto aPr)
        {
            bool resp = false;

            Productos[ProximoRenglon] = aPr;

            ProximoRenglon = ProximoRenglon + 1;

            return resp;
        }

        public string Listar()
        {
            string resp = "Lista de productos";

            for (int i = 0; i < Productos.Length; i++)
            {
                if (i==ProximoRenglon)
                {
                    break;
                }
                resp = resp 
                       + "\r\n"
                       + $"{Productos[i].Codigo} {Productos[i].Decripcion} {(Productos[i].txtPrecio)}";

                //+ $"{Productos[i].Codigo} {Productos[i].Decripcion} {(Productos[i].Precio.ToString())}";
            }

            return resp;    

        }
            
    }
}
