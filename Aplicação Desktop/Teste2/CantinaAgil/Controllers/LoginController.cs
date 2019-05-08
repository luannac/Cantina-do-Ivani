/*
    Programa: Cantina Agil
    Autor: Luann
    Data: 06/04/2019
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using CantinaAgil.Models;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CantinaAgil.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CantinaAgil.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Atendente>("Login");
    builder.EntitySet<Sangria>("Sangria"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class LoginController : ODataController
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();

        // GET: odata/Login
        [EnableQuery]
        public IQueryable<Atendente> GetLogin()
        {
            return db.Atendente;
        }

        // GET: odata/Login(5)
        [EnableQuery]
        public SingleResult<Atendente> GetAtendente([FromODataUri] int key)
        {
            return SingleResult.Create(db.Atendente.Where(atendente => atendente.idAtendente == key));
        }

        // PUT: odata/Login(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Atendente> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Atendente atendente = db.Atendente.Find(key);
            if (atendente == null)
            {
                return NotFound();
            }

            patch.Put(atendente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtendenteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(atendente);
        }

        // POST: odata/Login
        public IHttpActionResult Post(Atendente atendente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atendente.Add(atendente);
            db.SaveChanges();

            return Created(atendente);
        }

        // PATCH: odata/Login(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Atendente> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Atendente atendente = db.Atendente.Find(key);
            if (atendente == null)
            {
                return NotFound();
            }

            patch.Patch(atendente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtendenteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(atendente);
        }

        // DELETE: odata/Login(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Atendente atendente = db.Atendente.Find(key);
            if (atendente == null)
            {
                return NotFound();
            }

            db.Atendente.Remove(atendente);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Login(5)/Sangria
        [EnableQuery]
        public IQueryable<Sangria> GetSangria([FromODataUri] int key)
        {
            return db.Atendente.Where(m => m.idAtendente == key).SelectMany(m => m.Sangria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtendenteExists(int key)
        {
            return db.Atendente.Count(e => e.idAtendente == key) > 0;
        }
        private Task<ActionResult> Log(string user,string password)
        {
            db.Atendente.SqlQuery("SELECT nomeAtendente,senhaAtendente FROM Atendente WHERE nomeAtendente = @login AND senhaAtendente == @key", new SqlParameter("@ login", user));
        }
    }
}
