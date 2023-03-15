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
using NameCompany.Models;


namespace NameCompany.Controllers
{
    public class AccountInfoesController : ApiController
    {
        private user16Entities db = new user16Entities();

        [HttpPost]
        public IHttpActionResult Login(string login, string password)
        {
            return Ok(db.AccountInfo.FirstOrDefault(i => i.Login == login && i.Password == password));
        } 




        // GET: api/AccountInfoes
        public IQueryable<AccountInfo> GetAccountInfo()
        {
            return db.AccountInfo;
        }

        // GET: api/AccountInfoes/5
        [ResponseType(typeof(AccountInfo))]
        public IHttpActionResult GetAccountInfo(int id)
        {
            AccountInfo accountInfo = db.AccountInfo.Find(id);
            if (accountInfo == null)
            {
                return NotFound();
            }

            return Ok(accountInfo);
        }

        // PUT: api/AccountInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountInfo(int id, AccountInfo accountInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(accountInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountInfoExists(id))
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

        // POST: api/AccountInfoes
        [ResponseType(typeof(AccountInfo))]
        public IHttpActionResult PostAccountInfo(AccountInfo accountInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountInfo.Add(accountInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountInfoExists(accountInfo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountInfo.Id }, accountInfo);
        }

        // DELETE: api/AccountInfoes/5
        [ResponseType(typeof(AccountInfo))]
        public IHttpActionResult DeleteAccountInfo(int id)
        {
            AccountInfo accountInfo = db.AccountInfo.Find(id);
            if (accountInfo == null)
            {
                return NotFound();
            }

            db.AccountInfo.Remove(accountInfo);
            db.SaveChanges();

            return Ok(accountInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountInfoExists(int id)
        {
            return db.AccountInfo.Count(e => e.Id == id) > 0;
        }
    }
}