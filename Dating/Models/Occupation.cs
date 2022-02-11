using System;
using System.Collections.Generic;

namespace Dating.Models
{
    public partial class Occupation
    {
        public Occupation()
        {
            Users = new HashSet<Users>();
        }

        public int OppId { get; set; }
        public string Occupation1 { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
