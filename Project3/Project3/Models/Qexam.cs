using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class Qexam
    {
        public int Idexam { get; set; }
        public DateTime Datemake { get; set; }
        public int Question { get; set; }
        public int Id { get; set; }

        public virtual Exam IdexamNavigation { get; set; }
        public virtual Question QuestionNavigation { get; set; }
    }
}
