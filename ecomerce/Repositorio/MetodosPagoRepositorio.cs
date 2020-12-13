using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce.DB;
using ecomerce.Modelos;

namespace ecomerce.Repositorio
{
    public class MetodosPagoRepositorio
    {

        public static bool Guardar(M_MetodosPago c)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = ConvertToDBTable(c);

                db.MetodosPago.Add(x);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static M_MetodosPago ObtenerxId(int id)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = db.MetodosPago.Where(k => k.ID == id).FirstOrDefault();
                return x == null ? null : ConvertToDomain(x);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static List<M_MetodosPago> ObtenerTodos()
        {
            try
            {
                var db = new EcomerceEntities();
                var Lista = db.MetodosPago.ToList();

                List<M_MetodosPago> MiLista = new List<M_MetodosPago>();

                foreach (var item in Lista)
                {
                    MiLista.Add(new M_MetodosPago
                    {
                        ID = item.ID,
                        IDCliente = item.IDCliente,
                        Nombre = item.Nombre,
                        Empresa = item.Empresa,
                        NumTarjeta=item.NumTarjeta,
                        CCV = item.CCV,

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

        public static bool Actualizar(M_MetodosPago c)
        {
            var result = false;
            try
            {
                var db = new EcomerceEntities();
                var x = db.MetodosPago.SingleOrDefault(k => k.ID == c.ID);

                if (x != null)
                {
                    x.IDCliente = c.IDCliente;
                    x.Nombre = c.Nombre;
                    x.Empresa = c.Empresa;
                    x.NumTarjeta = c.NumTarjeta;
                    x.CCV = c.CCV;
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
                var e = db.MetodosPago.Any(x => x.ID == id);
                return e;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static MetodosPago ConvertToDBTable(M_MetodosPago c)
        {
            return new MetodosPago
            {
                ID = c.ID,
                IDCliente = c.IDCliente,
                Nombre = c.Nombre,
                Empresa = c.Empresa,
                NumTarjeta = c.NumTarjeta,
                CCV = c.CCV
            };
        }

        public static M_MetodosPago ConvertToDomain(MetodosPago c)
        {
            return new M_MetodosPago
            {
                ID = c.ID,
                IDCliente = c.IDCliente,
                Nombre = c.Nombre,
                Empresa = c.Empresa,
                NumTarjeta = c.NumTarjeta,
                CCV = c.CCV
            };
        }
    }
}
