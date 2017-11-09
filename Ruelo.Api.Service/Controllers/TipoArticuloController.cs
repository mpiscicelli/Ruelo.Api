using Ruelo.Api.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApiEntityFrame.Controllers
{
    public class TipoArticuloController : ApiController
    {
        private RueloEntities db = new RueloEntities();

        // GET: api/TipoArticulo
        public IHttpActionResult GetTipoArticulo()
        {
            return Ok(from tipoArticulo in db.TipoArticulo
                      select new Lista
                      {
                          id = tipoArticulo.Id,
                          name = tipoArticulo.Descripcion
                      });
        }

        class Lista
        {
            public Int64 id { get; set; }
            public string name { get; set; }
        }
        // GET: api/TipoArticulo/5
        [ResponseType(typeof(TipoArticulo))]
        public IHttpActionResult GetTipoArticulo(long id)
        {
            TipoArticulo TipoArticulo = db.TipoArticulo.Find(id);
            if (TipoArticulo == null)
            {
                return NotFound();
            }

            return Ok(TipoArticulo);
        }

        // PUT: api/TipoArticulo/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTipoArticulo(int id, TipoArticulo TipoArticulo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != TipoArticulo.C_id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(TipoArticulo).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TipoArticuloExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/TipoArticulo
        //[ResponseType(typeof(TipoArticulo))]
        //public IHttpActionResult PostTipoArticulo(TipoArticulo TipoArticulo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.TipoArticulo.Add(TipoArticulo);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = TipoArticulo.C_id }, TipoArticulo);
        //}

        // DELETE: api/TipoArticulo/5
        //[ResponseType(typeof(TipoArticulo))]
        //public IHttpActionResult DeleteTipoArticulo(int id)
        //{
        //    TipoArticulo TipoArticulo = db.TipoArticulo.Find(id);
        //    if (TipoArticulo == null)
        //    {
        //        return NotFound();
        //    }

        //    db.TipoArticulo.Remove(TipoArticulo);
        //    db.SaveChanges();

        //    return Ok(TipoArticulo);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool TipoArticuloExists(int id)
        //{
        //    return db.TipoArticulo.Count(e => e.C_id == id) > 0;
        //}
    }
}