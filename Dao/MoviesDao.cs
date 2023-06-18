using Microsoft.AspNetCore.Mvc;
using PocketCinemaAPIService.Models;

namespace PocketCinemaAPIService.Dao
{
    public class MoviesDao:ControllerBase
    {
        IConfiguration configuration;
        private readonly DBContextClass _context;
        public MoviesDao(DBContextClass context)
        {
            _context = context;
        }

        public List<Movie>? GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public async Task<Movie?> GetMoviebyId(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<string> AddMovies(Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }


            //CreatedAtAction(nameof(GetMoviebyId), new { id = movie.Id }, movie);
        }
    }
}
