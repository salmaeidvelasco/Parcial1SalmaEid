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
using Parcial1SalmaEid.Models;

namespace Parcial1SalmaEid.Controllers
{
    public class CountriesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Countries
        [Authorize]
        public IQueryable<Country> GetCountries()
        {
            return db.Countries;
        }

        // GET: api/Countries/5
        [Authorize]
        [ResponseType(typeof(Country))]
        public IHttpActionResult GetCountry(string id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // PUT: api/Countries/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCountry(string id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.alpha3code)
            {
                return BadRequest();
            }

            db.Entry(country).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        [Authorize]
        [ResponseType(typeof(Country))]
        public IHttpActionResult PostCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Countries.Add(country);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CountryExists(country.alpha3code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = country.alpha3code }, country);
        }

        // DELETE: api/Countries/5
        [Authorize]
        [ResponseType(typeof(Country))]
        public IHttpActionResult DeleteCountry(string id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            db.Countries.Remove(country);
            db.SaveChanges();

            return Ok(country);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryExists(string id)
        {
            return db.Countries.Count(e => e.alpha3code == id) > 0;
        }
    }
}