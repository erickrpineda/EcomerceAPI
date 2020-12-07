using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.Modelos
{
    public class M_Productos
    {
        public int ID { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<int> IDCategoria { get; set; }
        public Nullable<int> Existencias { get; set; }
        public byte[] Foto { get; set; }
    }
}
