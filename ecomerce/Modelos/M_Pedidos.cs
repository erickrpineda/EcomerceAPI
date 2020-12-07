using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.Modelos
{
    class M_Pedidos
    {
        public int ID { get; set; }
        public Nullable<int> IDCliente { get; set; }
        public Nullable<int> IDListaPedido { get; set; }
    }
}
