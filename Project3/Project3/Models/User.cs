using System;
using System.Collections.Generic;

#nullable disable

namespace Project3.Models
{
    public partial class User
    {
        public User()
        {
            Results = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
