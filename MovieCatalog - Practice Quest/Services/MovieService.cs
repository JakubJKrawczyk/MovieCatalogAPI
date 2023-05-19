using MovieCatalog___Practice_Quest.Database;
using MovieCatalog___Practice_Quest.DTO;
using MovieCatalog___Practice_Quest.Interfaces;
using MovieCatalog___Practice_Quest.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace MovieCatalog___Practice_Quest.Services
{
    public class MovieService : IMovieService
    {
        private readonly ILogger<Movie> _logger;
        private readonly AppDbContext _db;

        public MovieService(AppDbContext db, ILogger<Movie> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task AddMovie(AddMovieDTO dto)
        {
            Movie movie = Movie.GetMovieFromDTO(dto);
            await _db.Movies.AddAsync(movie);
            _logger.LogInformation($"\n{DateTime.Now}: Dodano film do biblioteki: \n " +
                $"Id: {movie.Id}\n" +
                $"Nazwa Filmu: {movie.Title}\n" +
                $"Genre: {movie.Genre}\n" +
                $"Year: {movie.Year}\n" +
                $"Description: {movie.Description}");
            _db.SaveChanges();
        }

        public Task DeleteMovie(string name)
        {

            Task task = new Task(() =>
            {
                var movie = GetMovieByName(name).Result;
                if (movie is not null & movie!.Title != "No Data")
                {
                    _db.Movies.Remove(movie);
                    _logger.LogInformation($"{DateTime.Now}: Usunięto film o nazwie {movie.Title}");
                    Debug.Write(movie.Title);
                    _db.SaveChanges();
                }

            });
            task.Start();
            task.Wait();
            return task;
        }

        public IEnumerable<Movie?> GetAllMovies()
        {
            return _db.Movies.ToList();
        }
        public Task<Movie?> GetLastAddedMovie()
        {
            return _db.Movies.LastOrDefaultAsync();
        }

        public Task<Movie?> GetMovieByName(string name) {

            
            Task<Movie?> movie = _db.Movies.FirstOrDefaultAsync(m => m.Title == name);
            if (movie is not null) return movie;
            else return new Task<Movie?>(() =>
            {

                return new Movie()
                {
                    Id = Guid.NewGuid(),
                    Title = "No Data",
                    Year = "No Data",
                    Genre = "No Data",
                    Description = "No Data"

                };
            });  
        }
        public IEnumerable<Movie?> GetMoviesByGenre(string genre)
        {
            return _db.Movies.Where(m => string.Equals(m.Genre, genre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Movie?> GetMoviesByYear(string year)
        {
            return _db.Movies.Where(m => string.Equals(m.Year, year, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
