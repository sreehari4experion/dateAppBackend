using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.View_Model
{
    public class UserView
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string Password { get; set; }

        public long? Phone { get; set; }
        public List<string> Hobby { get; set; }
        public string MovieGenre { get; set; }
        public List<string> Food { get; set; }
    }
}
