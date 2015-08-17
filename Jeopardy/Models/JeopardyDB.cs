using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Jeopardy.Models
{
    public class JeopardyDB : DbContext
    {
            public JeopardyDB(): base("JeopardyDB")
        {

        }

        public DbSet<JeopardyQuestion> JeopardyQuestions { get; set; }
        public DbSet<DoubleJeopardyQuestion> DoubleJeopardyQuestions { get; set; }
        public DbSet<FinalJeopardyQuestion> FinalJeopardyQuestions { get; set; }
        public DbSet<Category> Categorys { get; set; }
    }
}