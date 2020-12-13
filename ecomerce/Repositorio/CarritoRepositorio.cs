using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce.DB;
using ecomerce.Modelos;

namespace ecomerce.Repositorio
{
    public class CarritoRepositorio
    {

        public static bool Guardar(M_Carrito c)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = ConvertToDBTable(c);

                db.Carrito.Add(x);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static M_Carrito ObtenerxId(int id)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = db.Carrito.Where(k => k.ID == id).FirstOrDefault();
                return x == null ? null : ConvertToDomain(x);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static List<M_Carrito> ObtenerTodos()
        {
            try
            {
                var db = new EcomerceEntities();
                var Lista = db.Carrito.ToList();

                List<M_Carrito> MiLista = new List<M_Carrito>();

                foreach (var item in Lista)
                {
                    MiLista.Add(new M_Carrito
                    {
                        ID = item.ID,
                        IDCliente = item.IDCliente,
                        IDProducto = item.IDProducto
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

        public static bool Actualizar(M_Carrito c)
        {
            var result = false;
            try
            {
                var db = new EcomerceEntities();
                var x = db.Carrito.SingleOrDefault(k => k.ID == c.ID);

                if (x != null)
                {
                    x.IDCliente=c.IDCliente;
                    x.IDProducto=c.IDProducto;
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
                var e = db.Usuarios.Any(x => x.ID == id);
                return e;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Carrito ConvertToDBTable(M_Carrito c)
        {
            return new Carrito
            {
                ID = c.ID,
                IDCliente = c.IDCliente,
                IDProducto=c.IDProducto,
            };
        }

        public static M_Carrito ConvertToDomain(Carrito c)
        {
            return new M_Carrito
            {
                ID = c.ID,
                IDCliente = c.IDCliente,
                IDProducto = c.IDProducto,
            };
        }
    }
}