using System;
using System.Collections.Generic;

namespace Dating.Models
{
    public partial class Food
    {
        public Food()
        {
            Foodlist = new HashSet<Foodlist>();
        }

        public int FoodId { get; set; }
        public string Food1 { get; set; }

        public virtual ICollection<Foodlist> Foodlist { get; set; }
    }
}
