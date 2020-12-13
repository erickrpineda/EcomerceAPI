using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce.DB;
using ecomerce.Modelos;

namespace ecomerce.Repositorio
{
    public class PedidosRepositorio
    {

        public static bool Guardar(M_Pedidos c)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = ConvertToDBTable(c);

                db.Pedidos.Add(x);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static M_Pedidos ObtenerxId(int id)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = db.Pedidos.Where(k => k.ID == id).FirstOrDefault();
                return x == null ? null : ConvertToDomain(x);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static List<M_Pedidos> ObtenerTodos()
        {
            try
            {
                var db = new EcomerceEntities();
                var Lista = db.Pedidos.ToList();

                List<M_Pedidos> MiLista = new List<M_Pedidos>();

                foreach (var item in Lista)
                {
                    MiLista.Add(new M_Pedidos
                    {
                        ID = item.ID,
                        IDCliente=item.IDCliente,
                        IDListaPedido=item.IDListaPedido,

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

        public static bool Actualizar(M_Pedidos c)
        {
            var result = false;
            try
            {
                var db = new EcomerceEntities();
                var x = db.Pedidos.SingleOrDefault(k => k.ID == c.ID);

                if (x != null)
                {
                    x.IDCliente = c.IDCliente;
                    x.IDListaPedido = c.IDListaPedido;
                    db.SaveChanges();
                    result = true;
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }

        public static bool Existe(int id)
        {
            try
            {
                var db = new EcomerceEntities();
                var e = db.Pedidos.Any(x => x.ID == id);
                return e;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Pedidos ConvertToDBTable(M_Pedidos c)
        {
            return new Pedidos
            {
                ID = c.ID,
                IDCliente=c.IDCliente,
                IDListaPedido=c.IDListaPedido,

            };
        }

        public static M_Pedidos ConvertToDomain(Pedidos c)
        {
            return new M_Pedidos
            {
                ID = c.ID,
                IDCliente = c.IDCliente,
                IDListaPedido = c.IDListaPedido,
            };
        }
    }
}
