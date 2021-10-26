using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class Rating
    {
        public int Rank { get; set; }
        public int Id { get; set; }

        public virtual Result RankNavigation { get; set; }
    }
}
