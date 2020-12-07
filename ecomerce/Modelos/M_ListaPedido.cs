using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.Modelos
{
    public class M_ListaPedido
    {
        public int IDPedido { get; set; }
        public Nullable<int> IDProducto { get; set; }
        public Nullable<int> cantidad { get; set; }
    }
}
