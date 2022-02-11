using Dating.Models;
using Dating.Repository;
using Dating.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly IHobbies _hobbyR;

        //constructor injection
        public HobbiesController(IHobbies hobby)
        {
            _hobbyR = hobby;
        }
        [HttpGet]
        public async Task<List<HobbyView>> GetAllHobbies()
        {
            return await _hobbyR.GetAllHobbies();
        }
        //[HttpPost]
        //public async Task<int> AddHobby(Hobby hobby)
        //{
        //    return await _hobbyR.AddHobby(hobby);
        //}
        //public async Task<IActionResult> UpdateHobby(Hobby hobby)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _hobbyR.UpdateHobby(hobby);
        //            return Ok();
        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    return BadRequest();
        //}
    }
}
