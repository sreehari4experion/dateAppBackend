using Dating.Models;
using Dating.Repository;
using Dating.View_Model;
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
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepo _movie;

        //constructor injection
        public MoviesController(IMovieRepo movie)
        {
            _movie = movie;
        }
        [HttpGet]
        public async Task<List<MovieView>> GetAllMovies()
        {
            return await _movie.GetAllMovies();
        }

    }
}
