using System;
using System.Collections.Generic;

namespace Dating.Models
{
    public partial class Hobby
    {
        public Hobby()
        {
            Hobbylist = new HashSet<Hobbylist>();
        }

        public int HobbyId { get; set; }
        public string Hobby1 { get; set; }

        public virtual ICollection<Hobbylist> Hobbylist { get; set; }
    }
}
