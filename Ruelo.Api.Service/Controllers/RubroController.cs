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
using Ruelo.Api.Service.Models;

namespace WebApiEntityFrame.Controllers
{
    public class RubroController : ApiController
    {
        private RueloEntities db = new RueloEntities();

        // GET: api/Rubro
        public IHttpActionResult GetRubro()
        {
         return Ok(from rubro in db.Rubro.OrderBy(o => o.Descripcion)
                   select new ListaRequest
                   {
                                         id = rubro.Id,
                                         name= rubro.Descripcion
                                     });
        }

        // GET: api/Rubro/5
        [ResponseType(typeof(Rubro))]
        public IHttpActionResult GetRubro(long id)
        {
            Rubro Rubro = db.Rubro.Find(id);
            if (Rubro == null)
            {
                return NotFound();
            }

            return Ok(Rubro);
        }

        // PUT: api/Rubro/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutRubro(int id, Rubro Rubro)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != Rubro.C_id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(Rubro).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RubroExists(id))
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

        // POST: api/Rubro
        //[ResponseType(typeof(Rubro))]
        //public IHttpActionResult PostRubro(Rubro Rubro)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Rubro.Add(Rubro);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = Rubro.C_id }, Rubro);
        //}

        // DELETE: api/Rubro/5
        //[ResponseType(typeof(Rubro))]
        //public IHttpActionResult DeleteRubro(int id)
        //{
        //    Rubro Rubro = db.Rubro.Find(id);
        //    if (Rubro == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Rubro.Remove(Rubro);
        //    db.SaveChanges();

        //    return Ok(Rubro);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool RubroExists(int id)
        //{
        //    return db.Rubro.Count(e => e.C_id == id) > 0;
        //}
    }
}