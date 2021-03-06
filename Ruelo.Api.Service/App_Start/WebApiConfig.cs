﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Ruelo.Api.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ProductoRpcApiAction",
                routeTemplate: "producto/{action}/{productofilter}",
                defaults: new
                {
                    productofilter = RouteParameter.Optional,
                    controller = "ProductoController",
                    action = "GetProductos"
                });

//            RouteTable.Routes.MapHttpRoute(
//    name: "AlbumRpcApiAction",
//    routeTemplate: "albums/{action}/{title}",
//    defaults: new
//    {
//        title = RouteParameter.Optional,
//        controller = "AlbumApi",
//        action = "GetAblums"
//    }
//);

            //config.Routes.MapHttpRoute(
            //    name: "Get",
            //    routeTemplate: "api/{controller}/{id}/{descripcion}/{codigo}/{idRubro}/{idMarca}/{idSubrubro}"
            //);

        }
    }
}
