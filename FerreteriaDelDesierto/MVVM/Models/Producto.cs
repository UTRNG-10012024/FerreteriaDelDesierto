using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaDelDesierto.MVVM.Models
{
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; } // Para el filtrado
    }
}