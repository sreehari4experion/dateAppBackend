using Dating.Models;
using Dating.Repository;
using Dating.View_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _userR;
        private readonly DateContext date;

        //constructor injection
    public UsersController(IUsers user,DateContext dates)
        { 
            _userR = user;
            date = dates;
        }
        [HttpGet]
       // [Authorize]
        [Route("GetUsers")]
        public async Task<List<UserView>> GetUsers()
        {
            return await _userR.GetUsers();
        }
        [HttpGet]
        [Route("GetMostLikedHobby")]

        public async Task<ActionResult<HobbyView>> GetMostLikedHobby()
        {
            return await _userR.GetMostLikedHobby();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserView>> GetUserById(int? id)
        {
            try
            {
                var userTwo = await _userR.GetUserbyId(id);
                if (userTwo == null)
                {
                    return NotFound();
                }
                return userTwo;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpPost]
        public async Task<int> AddUser(Users user)
        {
            return await _userR.AddUser(user);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(Users user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userR.UpdateUser(user);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #region delete User by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _userR.DeleteUser(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok("User deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


    }
}
