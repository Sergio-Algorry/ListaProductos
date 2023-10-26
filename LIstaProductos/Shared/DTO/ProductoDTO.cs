using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIstaProductos.Shared.DTO
{
    public class ProductoDTO
    {
        [Required(ErrorMessage ="El código es obligatorio.")]
        [MaxLength(3, ErrorMessage ="Solo se aceptan códigos de 3 caracteres")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El código es obligatorio.")]
        public string Nombre { get; set;}
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        [Range(4,8, ErrorMessage ="fuera de rango")]
        public decimal Precio { get; set;}
    }
}
