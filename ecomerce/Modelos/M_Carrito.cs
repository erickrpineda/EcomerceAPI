using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.Modelos
{
    public class M_Carrito
    {
        public int ID { get; set; }
        public Nullable<int> IDCliente { get; set; }
        public Nullable<int> IDProducto { get; set; }
    }
}
