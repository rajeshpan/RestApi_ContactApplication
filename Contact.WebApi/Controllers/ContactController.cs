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
using Contact.WebApi.Models;

namespace Contact.WebApi.Controllers
{
   
    public class ContactController : ApiController
    {
        public ContactDBEntities db = new ContactDBEntities();

        // GET: api/Contact
        public IQueryable<ContactInformation> GetContactInformations()
        {
            return db.ContactInformations;
        }

        // GET: api/Contact/5
        [ResponseType(typeof(ContactInformation))]
        public IHttpActionResult GetContactInformation(int id)
        {
            if (id > 0)
            {
                ContactInformation contactInformation = db.ContactInformations.Find(id);
                if (contactInformation == null)
                    return NotFound();
                return Ok(contactInformation);
            }
            return NotFound();
        }

        
        // PUT: api/Contact/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactInformation(int id, ContactInformation contactInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactInformation.ContactId)
            {
                return BadRequest();
            }

            db.Entry(contactInformation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInformationExists(id))
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

        // POST: api/Contact
        [ResponseType(typeof(ContactInformation))]
        public IHttpActionResult PostContactInformation(ContactInformation contactInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContactInformations.Add(contactInformation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactInformation.ContactId }, contactInformation);
        }

        // DELETE: api/Contact/5
        [ResponseType(typeof(ContactInformation))]
        public IHttpActionResult DeleteContactInformation(int id)
        {
            if (id > 0)
            {
                ContactInformation contactInformation = db.ContactInformations.Find(id);
                if (contactInformation == null)
                    return NotFound();

                db.ContactInformations.Remove(contactInformation);
                db.SaveChanges();
                return Ok(contactInformation);
            }
            return NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactInformationExists(int id)
        {
            return db.ContactInformations.Count(e => e.ContactId == id) > 0;
        }
    }
}