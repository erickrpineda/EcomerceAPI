using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce.DB;
using ecomerce.Modelos;

namespace ecomerce.Repositorio
{
    public class CategoriasRepositorio
    {

        public static bool Guardar(M_Categorias c)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = ConvertToDBTable(c);

                db.Categorias.Add(x);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static M_Categorias ObtenerxId(int id)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = db.Categorias.Where(k => k.ID == id).FirstOrDefault();
                return x == null ? null : ConvertToDomain(x);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static List<M_Categorias> ObtenerTodos()
        {
            try
            {
                var db = new EcomerceEntities();
                var Lista = db.Categorias.ToList();

                List<M_Categorias> MiLista = new List<M_Categorias>();

                foreach (var item in Lista)
                {
                    MiLista.Add(new M_Categorias
                    {
                        ID = item.ID,
                        Nombre = item.Nombre,
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

        public static bool Actualizar(M_Categorias c)
        {
            var result = false;
            try
            {
                var db = new EcomerceEntities();
                var x = db.Categorias.SingleOrDefault(k => k.ID == c.ID);

                if (x != null)
                {
                    x.Nombre = c.Nombre;
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
                var e = db.Categorias.Any(x => x.ID == id);
                return e;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Categorias ConvertToDBTable(M_Categorias c)
        {
            return new Categorias
            {
                ID = c.ID,
                Nombre = c.Nombre,
            };
        }

        public static M_Categorias ConvertToDomain(Categorias c)
        {
            return new M_Categorias
            {
                ID = c.ID,
                Nombre = c.Nombre,
            };
        }
    }
}
