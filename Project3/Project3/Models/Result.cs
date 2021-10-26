using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class Result
    {
        public Result()
        {
            Ratings = new HashSet<Rating>();
        }

        public int Iduser { get; set; }
        public decimal Point { get; set; }
        public int Idresult { get; set; }

        public virtual User IduserNavigation { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
