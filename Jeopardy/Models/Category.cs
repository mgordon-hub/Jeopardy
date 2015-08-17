using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jeopardy.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }


        public virtual List<JeopardyQuestion> JeopardyQuestions { get; set; }

        public virtual List<DoubleJeopardyQuestion> DoubleJeopardyQuestions { get; set; }

        public virtual List<FinalJeopardyQuestion> FinalJeopardyQuestions { get; set; }


    }
}