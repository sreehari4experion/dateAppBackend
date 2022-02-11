using Dating.Repository;
using Dating.View_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : Controller
    {
        private readonly IFoodRepo _movie;

        //constructor injection
        public FoodController(IFoodRepo movie)
        {
            _movie = movie;
        }
        [HttpGet]
        public async Task<List<FoodView>> GetAllFoods()
        {
            return await _movie.GetAllFoods();
        }
    }
}
