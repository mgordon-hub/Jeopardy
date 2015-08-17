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
    public class JeopardyQuestionsController : ApiController
    {
        private JeopardyDB db = new JeopardyDB();

        // GET: api/JeopardyQuestions
        public IQueryable<JeopardyQuestion> GetJeopardyQuestions()
        {
            return db.JeopardyQuestions;
        }

        // GET: api/JeopardyQuestions/5
        [ResponseType(typeof(JeopardyQuestion))]
        public IHttpActionResult GetJeopardyQuestion(int id)
        {
            JeopardyQuestion jeopardyQuestion = db.JeopardyQuestions.Find(id);
            if (jeopardyQuestion == null)
            {
                return NotFound();
            }

            return Ok(jeopardyQuestion);
        }

        // PUT: api/JeopardyQuestions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJeopardyQuestion(int id, JeopardyQuestion jeopardyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jeopardyQuestion.JeopardyQuestionId)
            {
                return BadRequest();
            }

            db.Entry(jeopardyQuestion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JeopardyQuestionExists(id))
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

        // POST: api/JeopardyQuestions
        [ResponseType(typeof(JeopardyQuestion))]
        public IHttpActionResult PostJeopardyQuestion(JeopardyQuestion jeopardyQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           

            db.JeopardyQuestions.Add(jeopardyQuestion);
            db.SaveChanges();

            Category categoryQuestion = db.Categorys.Find(jeopardyQuestion.CategoryId);
            categoryQuestion.JeopardyQuestions.Add(jeopardyQuestion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jeopardyQuestion.JeopardyQuestionId }, jeopardyQuestion);
        }

        // DELETE: api/JeopardyQuestions/5
        [ResponseType(typeof(JeopardyQuestion))]
        public IHttpActionResult DeleteJeopardyQuestion(int id)
        {
            JeopardyQuestion jeopardyQuestion = db.JeopardyQuestions.Find(id);
            if (jeopardyQuestion == null)
            {
                return NotFound();
            }

            db.JeopardyQuestions.Remove(jeopardyQuestion);
            db.SaveChanges();

            return Ok(jeopardyQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JeopardyQuestionExists(int id)
        {
            return db.JeopardyQuestions.Count(e => e.JeopardyQuestionId == id) > 0;
        }
    }
}