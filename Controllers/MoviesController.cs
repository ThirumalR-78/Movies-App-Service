using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PocketCinemaAPIService.Models;
using PocketCinemaAPIService.Dao;

namespace PocketCinemaAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=moviesdb;User=root;Password=root");

        IConfiguration configuration;
        private MoviesDao moviesDao;
        private readonly DBContextClass _context;
       /* public MoviesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }*/
/*        public MoviesController(DBContextClass context)
        {
            _context = context;
        }*/

        public MoviesController(MoviesDao moviesDao)
        {
            this.moviesDao = moviesDao;
        }

        [HttpGet(Name = "getMovies")]
        public List<Movie>? GetMovies()
        {
            try
            {
                /*var res = _context.Movies.ToList();*/
                var res = moviesDao.GetAllMovies();

                res.ForEach(movie => { movie.Genres.AddRange(movie.Genre.Split(',').ToList()); });
                Console.WriteLine(res);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection failed!");
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetById(int id)
        {
            /*var movie = await _context.Movies.FindAsync(id);*/
            Movie movie = await moviesDao.GetMoviebyId(id);


            if (movie == null)
            {
                return NotFound();
            }
            movie.Genres.AddRange(movie.Genre.Split(',').ToList());
            return movie;
        }

        [HttpPost("addMovie")]
        public async Task<string> addMovies(Movie movie)
        {
            return await moviesDao.AddMovies(movie);
            /*_context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);*/
        }

    }
}
