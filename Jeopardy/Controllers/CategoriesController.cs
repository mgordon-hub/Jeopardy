﻿using System;
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
    public class CategoriesController : ApiController
    {
        private JeopardyDB db = new JeopardyDB();

        // GET: api/Categories
        public IEnumerable<CategoryViewModel> GetCategorys()
        {
            List<CategoryViewModel> listOfCategories = new List<CategoryViewModel>();
            
            foreach (var cat in db.Categorys)
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel();
                categoryViewModel.CategoryName = cat.CategoryName;
                categoryViewModel.CategoryID = cat.CategoryId;
               
                listOfCategories.Add(categoryViewModel);
            }
            IEnumerable<CategoryViewModel> categories = listOfCategories;

            return categories;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categorys.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categorys.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categorys.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categorys.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categorys.Count(e => e.CategoryId == id) > 0;
        }
    }
}