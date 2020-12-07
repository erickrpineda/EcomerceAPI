using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.Modelos
{
    public class M_MetodosPago
    {
        public int ID { get; set; }
        public Nullable<int> IDCliente { get; set; }
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public Nullable<int> NumTarjeta { get; set; }
        public Nullable<int> CCV { get; set; }
    }
}
