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
    public class FinalJeopardyQuestionsController : ApiController
    {
        private JeopardyDB db = new JeopardyDB();

        // GET: api/FinalJeopardyQuestions
        public IQueryable<FinalJeopardyQuestion> GetFinalJeopardyQuestions()
        {
            return db.FinalJeopardyQuestions;
        }

        // GET: api/FinalJeopardyQuestions/5
        [ResponseType(typeof(FinalJeopardyQuestion))]
        public IHttpActionResult GetFinalJeopardyQuestion(int id)
        {
            FinalJeopardyQuestion finalJeopardyQuestion = db.FinalJeopardyQuestions.Find(id);
            if (finalJeopardyQuestion == null)
            {
                return NotFound();
            }

            return Ok(finalJeopardyQuestion);
        }

        // PUT: api/FinalJeopardyQuestions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinalJeopardyQuestion(int id, FinalJeopardyQuestion finalJeopardyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != finalJeopardyQuestion.FinalJeopardyQuestionId)
            {
                return BadRequest();
            }

            db.Entry(finalJeopardyQuestion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalJeopardyQuestionExists(id))
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

        // POST: api/FinalJeopardyQuestions
        [ResponseType(typeof(FinalJeopardyQuestion))]
        public IHttpActionResult PostFinalJeopardyQuestion(FinalJeopardyQuestion finalJeopardyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinalJeopardyQuestions.Add(finalJeopardyQuestion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = finalJeopardyQuestion.FinalJeopardyQuestionId }, finalJeopardyQuestion);
        }

        // DELETE: api/FinalJeopardyQuestions/5
        [ResponseType(typeof(FinalJeopardyQuestion))]
        public IHttpActionResult DeleteFinalJeopardyQuestion(int id)
        {
            FinalJeopardyQuestion finalJeopardyQuestion = db.FinalJeopardyQuestions.Find(id);
            if (finalJeopardyQuestion == null)
            {
                return NotFound();
            }

            db.FinalJeopardyQuestions.Remove(finalJeopardyQuestion);
            db.SaveChanges();

            return Ok(finalJeopardyQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinalJeopardyQuestionExists(int id)
        {
            return db.FinalJeopardyQuestions.Count(e => e.FinalJeopardyQuestionId == id) > 0;
        }
    }
}