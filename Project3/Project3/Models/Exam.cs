using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Qexams = new HashSet<Qexam>();
        }

        public int Idexam { get; set; }
        public string Name { get; set; }
        public DateTime Dateexam { get; set; }
        public string Lodifficult { get; set; }
        public int Timemake { get; set; }

        public virtual ICollection<Qexam> Qexams { get; set; }
    }
}
