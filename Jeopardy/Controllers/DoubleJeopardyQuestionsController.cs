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
using Jeopardy.Models;

namespace Jeopardy.Controllers
{
    public class DoubleJeopardyQuestionsController : ApiController
    {
        private JeopardyDB db = new JeopardyDB();

        // GET: api/DoubleJeopardyQuestions
        public IQueryable<DoubleJeopardyQuestion> GetDoubleJeopardyQuestions()
        {
            return db.DoubleJeopardyQuestions;
        }

        // GET: api/DoubleJeopardyQuestions/5
        [ResponseType(typeof(DoubleJeopardyQuestion))]
        public IHttpActionResult GetDoubleJeopardyQuestion(int id)
        {
            DoubleJeopardyQuestion doubleJeopardyQuestion = db.DoubleJeopardyQuestions.Find(id);
            if (doubleJeopardyQuestion == null)
            {
                return NotFound();
            }

            return Ok(doubleJeopardyQuestion);
        }

        // PUT: api/DoubleJeopardyQuestions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoubleJeopardyQuestion(int id, DoubleJeopardyQuestion doubleJeopardyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doubleJeopardyQuestion.DoubleJeopardyQuestionId)
            {
                return BadRequest();
            }

            db.Entry(doubleJeopardyQuestion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoubleJeopardyQuestionExists(id))
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

        // POST: api/DoubleJeopardyQuestions
        [ResponseType(typeof(DoubleJeopardyQuestion))]
        public IHttpActionResult PostDoubleJeopardyQuestion(DoubleJeopardyQuestion doubleJeopardyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DoubleJeopardyQuestions.Add(doubleJeopardyQuestion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = doubleJeopardyQuestion.DoubleJeopardyQuestionId }, doubleJeopardyQuestion);
        }

        // DELETE: api/DoubleJeopardyQuestions/5
        [ResponseType(typeof(DoubleJeopardyQuestion))]
        public IHttpActionResult DeleteDoubleJeopardyQuestion(int id)
        {
            DoubleJeopardyQuestion doubleJeopardyQuestion = db.DoubleJeopardyQuestions.Find(id);
            if (doubleJeopardyQuestion == null)
            {
                return NotFound();
            }

            db.DoubleJeopardyQuestions.Remove(doubleJeopardyQuestion);
            db.SaveChanges();

            return Ok(doubleJeopardyQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoubleJeopardyQuestionExists(int id)
        {
            return db.DoubleJeopardyQuestions.Count(e => e.DoubleJeopardyQuestionId == id) > 0;
        }
    }
}