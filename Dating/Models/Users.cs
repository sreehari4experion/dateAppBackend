using System;
using System.Collections.Generic;

namespace Dating.Models
{
    public partial class Users
    {
        public Users()
        {
            Foodlist = new HashSet<Foodlist>();
            Hobbylist = new HashSet<Hobbylist>();
        }

        public int UserId { get; set; }
        public string Cname { get; set; }
        public int? Age { get; set; }
        public string Occupation { get; set; }
        public long? Phone { get; set; }
        public string Sex { get; set; }
        public string Password { get; set; }
        public int? MovId { get; set; }

        public virtual Movie Mov { get; set; }
        public virtual ICollection<Foodlist> Foodlist { get; set; }
        public virtual ICollection<Hobbylist> Hobbylist { get; set; }
    }
}
