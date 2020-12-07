using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce.DB;
using ecomerce.Modelos;

namespace ecomerce.Repositorio
{
    public class UsuariosRepositorio
    {
        public static bool Guardar(M_Usuarios c)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = ConvertToDBTable(c);

                db.Usuarios.Add(x);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static M_Usuarios ObtenerxId(int id)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = db.Usuarios.Where(k => k.ID == id).FirstOrDefault();
                return x == null ? null : ConvertToDomain(x);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static List<M_Usuarios> ObtenerTodos()
        {
            try
            {
                var db = new EcomerceEntities();
                var Lista = db.Usuarios.ToList();

                List<M_Usuarios> MiLista = new List<M_Usuarios>();

                foreach (var item in Lista)
                {
                    MiLista.Add(new M_Usuarios
                    {
                        ID = item.ID,
                        Tipo = item.Tipo,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        usuario = item.usuario,
                        contraseña = item.contraseña
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

        public static bool Actualizar(M_Usuarios c)
        {
            var result = false;
            try
            {
                var db = new EcomerceEntities();
                var x = db.Usuarios.SingleOrDefault(k => k.ID == c.ID);

                if (x != null)
                {
                    x.Nombre = c.Nombre;
                    x.Tipo = c.Tipo;
                    x.Nombre = c.Nombre;
                    x.Apellido = c.Apellido;
                    x.usuario = c.usuario;
                    x.contraseña = c.contraseña;
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

        public static Usuarios ConvertToDBTable(M_Usuarios c)
        {
            return new Usuarios
            {
                ID = c.ID,
                Tipo = c.Tipo,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                usuario = c.usuario,
                contraseña = c.contraseña
            };
        }

        public static M_Usuarios ConvertToDomain(Usuarios c)
        {
            return new M_Usuarios
            {
                ID = c.ID,
                Tipo = c.Tipo,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                usuario = c.usuario,
                contraseña = c.contraseña
            };
        }
    }
}
