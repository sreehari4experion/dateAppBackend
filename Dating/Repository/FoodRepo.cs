using Dating.Models;
using Dating.View_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.Repository
{
    public class FoodRepo : IFoodRepo
    {
        private readonly DateContext dating;
        public FoodRepo(DateContext contextone)
        {
            dating = contextone;
        }
        //public async Task<int> AddFood(Food food)
        //{
        //    if (dating != null)
        //    {
        //        await dating.Food.AddAsync(food);
        //        await dating.SaveChangesAsync();
        //        return food.FoodId;
        //    }
        //    return 0;
        //}

        public async Task<List<FoodView>> GetAllFoods()
        {
            if (dating != null)
            {
                return await (from p in dating.Food
                              select new FoodView
                              {
                                  FoodId = p.FoodId,
                                  FoodName = p.Food1
                              }
                              ).ToListAsync();
            }
            return null;
        }

       

    }
}
