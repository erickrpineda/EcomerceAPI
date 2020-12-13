using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce.DB;
using ecomerce.Modelos;

namespace ecomerce.Repositorio
{
    public class DireccionesRepositorio
    {

        public static bool Guardar(M_Direcciones c)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = ConvertToDBTable(c);

                db.Direcciones.Add(x);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static M_Direcciones ObtenerxId(int id)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = db.Direcciones.Where(k => k.ID == id).FirstOrDefault();
                return x == null ? null : ConvertToDomain(x);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static List<M_Direcciones> ObtenerTodos()
        {
            try
            {
                var db = new EcomerceEntities();
                var Lista = db.Direcciones.ToList();

                List<M_Direcciones> MiLista = new List<M_Direcciones>();

                foreach (var item in Lista)
                {
                    MiLista.Add(new M_Direcciones
                    {
                        ID = item.ID,
                        IDCliente = item.IDCliente,
                        Direccion = item.Direccion,
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

        public static bool Actualizar(M_Direcciones c)
        {
            var result = false;
            try
            {
                var db = new EcomerceEntities();
                var x = db.Direcciones.SingleOrDefault(k => k.ID == c.ID);

                if (x != null)
                {
                    x.IDCliente = c.IDCliente;
                    x.Direccion = c.Direccion;
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
                var e = db.Direcciones.Any(x => x.ID == id);
                return e;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Direcciones ConvertToDBTable(M_Direcciones c)
        {
            return new Direcciones
            {
                ID = c.ID,
                IDCliente= c.IDCliente,
                Direccion=c.Direccion,
            };
        }

        public static M_Direcciones ConvertToDomain(Direcciones c)
        {
            return new M_Direcciones
            {
                ID = c.ID,
                IDCliente = c.IDCliente,
                Direccion = c.Direccion,
            };
        }
    }
}
