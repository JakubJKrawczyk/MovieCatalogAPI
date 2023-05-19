using Microsoft.AspNetCore.Mvc;
using MovieCatalog___Practice_Quest.DTO;
using MovieCatalog___Practice_Quest.Interfaces;
using MovieCatalog___Practice_Quest.Models;
using MovieCatalog___Practice_Quest.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MovieCatalog___Practice_Quest.Controllers
{
    [ApiController, Route("/")]
    public class MovieCatalogController : Controller
    {

        private readonly IMovieService _movieService;

        public MovieCatalogController(IMovieService movieservice)
        {
            _movieService = movieservice;
        }
        [HttpPost("/add")]
        public void AddMovie(AddMovieDTO amd)
        {
            _movieService.AddMovie(amd);

        }
        [HttpPost("/delete/{movie}")]
        public void DeleteMovie(string movie)
        {
            _movieService.DeleteMovie(movie);
        }

        [HttpGet("/last")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Database is empty")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Success")]
        public async Task<Movie> GetLastMovie() => (await _movieService.GetLastAddedMovie())!;
        

        [HttpGet("/year/{year}")]
        public IEnumerable<Movie> GetMovieByYear(string year) => _movieService.GetMoviesByYear(year)!;
        

        [HttpGet("/genre/{genre}")]
        public IEnumerable<Movie> GetMovieByGenre(string genre) => _movieService.GetMoviesByGenre(genre)!;
        
        [HttpGet("/all")]
        public IEnumerable<Movie> GetAllMovies() => _movieService.GetAllMovies()!;

        [HttpGet("/movie/{name}")]
        public Task<Movie> GetMovieByName(string name)
        {
            return _movieService.GetMovieByName(name)!;
        }
    }
}
