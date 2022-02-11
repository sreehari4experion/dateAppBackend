using System;
using System.Collections.Generic;

namespace Dating.Models
{
    public partial class Foodlist
    {
        public int FoodListId { get; set; }
        public int? FoodId { get; set; }
        public int? UserId { get; set; }

        public virtual Food Food { get; set; }
        public virtual Users User { get; set; }
    }
}
