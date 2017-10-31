using Ruelo.Api.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApiEntityFrame.Controllers
{
    public class ProductoController : ApiController
    {
        private RueloEntities db = new RueloEntities();

        // GET: api/Producto
        public IEnumerable<Producto> GetProducto()
        {
            return db.Producto.Where(p => p.Id < 10100);
        }

        // GET: api/Producto/5
        //[ResponseType(typeof(Producto))]
        [ResponseType(typeof(String))]
        public IHttpActionResult GetProducto(int id)
        {
            Producto Producto = db.Producto.Find(id);
            if (Producto == null)
            {
                return NotFound();
            }

            return Ok(Producto);
            //return Ok("{name: Catalago}");
        }

        //[HttpGet]
        //public IEnumerable<Producto> FindByFilters(long id, string descripcion, string codigo, long idRubro, long idMarca, long idSubrubro)
        //{
        //    IEnumerable<Producto> productos = (from produ in db.Producto
        //                                       where ((id == 0 || produ.Id == id)
        //                                               && (string.IsNullOrWhiteSpace(descripcion) || produ.Descripcion.Contains(descripcion))
        //                                               && (string.IsNullOrWhiteSpace(codigo) || produ.Codigo == codigo)
        //                                               && (idRubro == 0 || produ.IdRubro == idRubro)
        //                                               && (idMarca == 0 || produ.IdMarca == idMarca)
        //                                               && (idSubrubro == 0 || produ.IdSubrubro == idSubrubro))select produ);

        //    return productos;
        //    //(from comprobante in Context.Comprobante1
        //    //                      where(comprobante.Fecha >= fromDate && comprobante.Fecha <= toDate)
        //    //                    select comprobante).ToList();

        //}
        [Route("api/producto/{id}")]
        public IEnumerable<ProductoLista> Get(ProductosFilters pf)
        {
            IEnumerable<ProductoLista> productos = (from produ in db.Producto
                                               where ((pf.Id == 0 || produ.Id == pf.Id)
                                                       && (pf.Descripcion == "" || produ.Descripcion.Contains(pf.Descripcion))
                                                       && (pf.Codigo == "" || produ.Codigo == pf.Codigo)
                                                       && (pf.IdRubro == 0 || produ.IdRubro == pf.IdRubro)
                                                       && (pf.IdMarca == 0 || produ.IdMarca == pf.IdMarca)
                                                       && (pf.IdSubrubro == 0 || produ.IdSubrubro == pf.IdSubrubro)
                                                      )
                                               select new ProductoLista{
                                                   Id = produ.Id,
                                                   Descripcion = produ.Descripcion,
                                                   Marca = produ.Marca.Descripcion
                                               } ).ToList();

            foreach (ProductoLista pl in productos)
            {
                pl.urlImage = string.Format("{0}{1}.png", WebConfigurationManager.AppSettings["UrlImages"],pl.Id.ToString());
            } 
            return productos;
            
        }

        public class ProductosFilters
        {
            public long Id { get; set; }
            public string Descripcion { get; set; }
            public string Codigo { get; set; }
            public long IdMarca { get; set; }
            public long IdRubro { get; set; }
            public long IdSubrubro { get; set; }
        }

        public class ProductoLista
        {
            public long Id { get; set; }
            public string Descripcion { get; set; }
            public string Marca { get; set; }
            public string urlImage { get; set; }
        }

        // PUT: api/Producto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProducto(int id, Producto Producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Producto.Id)
            {
                return BadRequest();
            }

            db.Entry(Producto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Producto
        [ResponseType(typeof(Producto))]
        public IHttpActionResult PostProducto(Producto Producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Producto.Add(Producto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = Producto.Id }, Producto);
        }

        // DELETE: api/Producto/5
        [ResponseType(typeof(Producto))]
        public IHttpActionResult DeleteProducto(int id)
        {
            Producto Producto = db.Producto.Find(id);
            if (Producto == null)
            {
                return NotFound();
            }

            db.Producto.Remove(Producto);
            db.SaveChanges();

            return Ok(Producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoExists(int id)
        {
            return db.Producto.Count(e => e.Id == id) > 0;
        }
    }
}