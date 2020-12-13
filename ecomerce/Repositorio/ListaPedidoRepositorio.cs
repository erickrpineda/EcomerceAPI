using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce.DB;
using ecomerce.Modelos;

namespace ecomerce.Repositorio
{
    public class ListaPedidoRepositorio
    {

        public static bool Guardar(M_ListaPedido c)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = ConvertToDBTable(c);

                db.ListaPedido.Add(x);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }


        public static List<M_ListaPedido> ObtenerTodos()
        {
            try
            {
                var db = new EcomerceEntities();
                var Lista = db.ListaPedido.ToList();

                List<M_ListaPedido> MiLista = new List<M_ListaPedido>();

                foreach (var item in Lista)
                {
                    MiLista.Add(new M_ListaPedido
                    {
                        IDPedido = item.IDPedido,
                        IDProducto = item.IDProducto,
                        cantidad = item.cantidad,
                    });
                }
                return MiLista == null ? null : MiLista;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static ListaPedido ConvertToDBTable(M_ListaPedido c)
        {
            return new ListaPedido
            {
                IDPedido = c.IDPedido,
                IDProducto = c.IDProducto,
                cantidad = c.cantidad,
            };
        }

        public static M_ListaPedido ConvertToDomain(ListaPedido c)
        {
            return new M_ListaPedido
            {
                IDPedido = c.IDPedido,
                IDProducto = c.IDProducto,
                cantidad = c.cantidad,
            };
        }
    }
}
