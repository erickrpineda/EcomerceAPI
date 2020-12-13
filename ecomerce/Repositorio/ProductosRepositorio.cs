using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce.DB;
using ecomerce.Modelos;

namespace ecomerce.Repositorio
{
    public class ProductosRepositorio
    {

        public static bool Guardar(M_Productos c)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = ConvertToDBTable(c);

                db.Productos.Add(x);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static M_Productos ObtenerxId(int id)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = db.Productos.Where(k => k.ID == id).FirstOrDefault();
                return x == null ? null : ConvertToDomain(x);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static List<M_Productos> ObtenerTodos()
        {
            try
            {
                var db = new EcomerceEntities();
                var Lista = db.Productos.ToList();

                List<M_Productos> MiLista = new List<M_Productos>();

                foreach (var item in Lista)
                {
                    MiLista.Add(new M_Productos
                    {
                        ID = item.ID,
                        NombreProducto =item.NombreProducto,
                        Descripcion=item.Descripcion,
                        Precio=item.Precio,
                        IDCategoria=item.IDCategoria,
                        Existencias=item.Existencias,
                        Foto=item.Foto

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

        public static bool Actualizar(M_Productos c)
        {
            var result = false;
            try
            {
                var db = new EcomerceEntities();
                var x = db.Productos.SingleOrDefault(k => k.ID == c.ID);

                if (x != null)
                {

                    x.NombreProducto = c.NombreProducto;
                    x.Descripcion = c.Descripcion;
                    x.Precio = c.Precio;
                    x.IDCategoria = c.IDCategoria;
                    x.Existencias = c.Existencias;
                    x.Foto = c.Foto;
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
                var e = db.Productos.Any(x => x.ID == id);
                return e;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Productos ConvertToDBTable(M_Productos c)
        {
            return new Productos
            {
                ID = c.ID,
                NombreProducto = c.NombreProducto,
                Descripcion = c.Descripcion,
                Precio = c.Precio,
                IDCategoria = c.IDCategoria,
                Existencias = c.Existencias,
                Foto = c.Foto
            };
        }

        public static M_Productos ConvertToDomain(Productos c)
        {
            return new M_Productos
            {
                ID = c.ID,
                NombreProducto = c.NombreProducto,
                Descripcion = c.Descripcion,
                Precio = c.Precio,
                IDCategoria = c.IDCategoria,
                Existencias = c.Existencias,
                Foto = c.Foto
            };
        }
    }
}
