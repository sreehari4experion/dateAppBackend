using Dating.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.Repository
{
    public interface IFoodRepo
    {
        Task<List<FoodView>> GetAllFoods();
    }
}
