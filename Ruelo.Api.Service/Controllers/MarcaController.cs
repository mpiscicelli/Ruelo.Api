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
    public class MarcaController : ApiController
    {
        private RueloEntities db = new RueloEntities();

        // GET: api/Marca
        public IHttpActionResult GetMarca()
        {
            return Ok(from marca in db.Marca.OrderBy(o => o.Descripcion)
                                                    select new ListaRequest
                                                    {
                                                        id = marca.Id,
                                                        name = marca.Descripcion
                                                    }) ;
        }

        // GET: api/Marca/5
        [ResponseType(typeof(Marca))]
        public IHttpActionResult GetMarca(long id)
        {
            Marca Marca = db.Marca.Find(id);
            if (Marca == null)
            {
                return NotFound();
            }

            return Ok(Marca);
        }

        // PUT: api/Marca/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMarca(int id, Marca Marca)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != Marca.C_id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(Marca).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MarcaExists(id))
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

        // POST: api/Marca
        //[ResponseType(typeof(Marca))]
        //public IHttpActionResult PostMarca(Marca Marca)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Marca.Add(Marca);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = Marca.C_id }, Marca);
        //}

        // DELETE: api/Marca/5
        //[ResponseType(typeof(Marca))]
        //public IHttpActionResult DeleteMarca(int id)
        //{
        //    Marca Marca = db.Marca.Find(id);
        //    if (Marca == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Marca.Remove(Marca);
        //    db.SaveChanges();

        //    return Ok(Marca);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool MarcaExists(int id)
        //{
        //    return db.Marca.Count(e => e.C_id == id) > 0;
        //}
    }

     
}