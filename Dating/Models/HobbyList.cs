using System;
using System.Collections.Generic;

namespace Dating.Models
{
    public partial class Hobbylist
    {
        public int HobbylistId { get; set; }
        public int? UserId { get; set; }
        public int? HobbyId { get; set; }

        public virtual Hobby Hobby { get; set; }
        public virtual Users User { get; set; }
    }
}
