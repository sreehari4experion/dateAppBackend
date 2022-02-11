using Dating.Models;
using Dating.View_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.Repository
{
    public class MovieRepo : IMovieRepo
    {
        private readonly DateContext dating;
        public MovieRepo(DateContext contextone)
        {
            dating = contextone;
        }


        public async Task<List<MovieView>> GetAllMovies()
        {
            if (dating != null)
            {
                return await (from p in dating.Movie

                              select new MovieView
                              {
                                  MovieId = p.MovId,
                                  MovieName = p.MovieGenre
                              }
                              ).ToListAsync();
            }
            return null;
        }
    }
}
