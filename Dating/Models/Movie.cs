using System;
using System.Collections.Generic;

namespace Dating.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Users = new HashSet<Users>();
        }

        public int MovId { get; set; }
        public string MovieGenre { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
