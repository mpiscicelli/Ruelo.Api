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
    public class SubrubroController : ApiController
    {
        private RueloEntities db = new RueloEntities();

        // GET: api/Subrubro
        public IHttpActionResult GetSubrubro()
        {
            return Ok(from subrubro in db.Subrubro
                      select new Lista
                      {
                          id = subrubro.Id,
                          name = subrubro.Descripcion
                      });
        }

        class Lista
        {
            public Int64 id { get; set; }
            public string name { get; set; }
        }

        // GET: api/Subrubro/5
        [ResponseType(typeof(Subrubro))]
        public IHttpActionResult GetSubrubro(long id)
        {
            Subrubro Subrubro = db.Subrubro.Find(id);
            if (Subrubro == null)
            {
                return NotFound();
            }

            return Ok(Subrubro);
        }

        // PUT: api/Subrubro/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutSubrubro(int id, Subrubro Subrubro)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != Subrubro.C_id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(Subrubro).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SubrubroExists(id))
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

        // POST: api/Subrubro
        //[ResponseType(typeof(Subrubro))]
        //public IHttpActionResult PostSubrubro(Subrubro Subrubro)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Subrubro.Add(Subrubro);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = Subrubro.C_id }, Subrubro);
        //}

        // DELETE: api/Subrubro/5
        //[ResponseType(typeof(Subrubro))]
        //public IHttpActionResult DeleteSubrubro(int id)
        //{
        //    Subrubro Subrubro = db.Subrubro.Find(id);
        //    if (Subrubro == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Subrubro.Remove(Subrubro);
        //    db.SaveChanges();

        //    return Ok(Subrubro);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool SubrubroExists(int id)
        //{
        //    return db.Subrubro.Count(e => e.C_id == id) > 0;
        //}
    }
}