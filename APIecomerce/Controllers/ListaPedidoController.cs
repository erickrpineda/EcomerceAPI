using APIecomerce.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ecomerce.Repositorio;
using ecomerce.Modelos;

namespace APIEcomerce.Controllers
{
    public class ListaPedidoController : BaseAPIController
    {


        [System.Web.Http.HttpGet]
        [ActionName("ObtenerTodos")]
        public HttpResponseMessage ObtenerTodos()
        {
            try
            {
                if (ValidarAutorizacion())
                {
                    var x = ListaPedidoRepositorio.ObtenerTodos();
                    return OkResponse(x);
                }
                else
                {
                    return OkResponse("No tiene acceso");
                }
            }
            catch (Exception)
            {
                return ErrorResponse("Ha ocurrido un error al Obtener Todos");
                throw;
            }
        }

        [System.Web.Http.HttpPost]
        [ActionName("Guardar")]
        public HttpResponseMessage Guardar([FromBody] M_ListaPedido c)
        {
            try
            {
                if (ValidarAutorizacion())
                {

                    var x = ListaPedidoRepositorio.Guardar(c);

                    if (x == false)
                    {
                        return OkResponse("Hubo un error al recuperar el registro");
                    }
                    else
                    {
                        return OkResponse(x);
                    }
                }
                else
                {
                    return OkResponse("No tiene acceso");
                }

            }
            catch (Exception)
            {
                return ErrorResponse("Ha ocurrido un error");
                throw;
            }
        }


        
    }
}
