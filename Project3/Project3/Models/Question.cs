using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class Question
    {
        public Question()
        {
            Qexams = new HashSet<Qexam>();
        }

        public int Idquestion { get; set; }
        public string Contentq { get; set; }
        public string Answertrue { get; set; }
        public string Answer1false { get; set; }
        public string Answer2false { get; set; }
        public string Answer3false { get; set; }
        public string Lodifficult { get; set; }
        public DateTime Dateq { get; set; }
        public decimal Point { get; set; }

        public virtual ICollection<Qexam> Qexams { get; set; }
    }
}
