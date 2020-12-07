using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce.Repositorio;

namespace ecomerce
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = ClientesRepositorio.ObtenerTodos();

            foreach (var item in x)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Nombre);
                Console.WriteLine(item.Apellido);
                Console.WriteLine(item.Telefono);
                Console.WriteLine(item.CorreoE);
                Console.ReadKey();
            }
        }
    }
}
