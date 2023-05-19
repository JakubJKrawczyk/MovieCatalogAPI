using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCatalog___Practice_Quest.Database;
using MovieCatalog___Practice_Quest.DTO;
using MovieCatalog___Practice_Quest.Models;
using MovieCatalog___Practice_Quest.Services;
namespace MovieCatalogTests
{
    [TestFixture]
    public class MovieServiceTest
    {
        private AppDbContext _db;
        private MovieService _service;
        private Logger<Movie> _logger;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("Atrapa");
            
            _db = new AppDbContext(options.Options);
            _logger = new Logger<Movie>(new LoggerFactory());
            _service = new MovieService(_db, _logger);




        }

        [Test, Order(1)]
        public async Task TestAddMovie()
        {
            await _service.AddMovie(new AddMovieDTO()
            {
                Title = "Title1",
                Genre = "Genre1",
                Year = "Year1"
            });

            await _service.AddMovie(new AddMovieDTO()
            {
                Title = "Title2",
                Genre = "Genre3",
                Year = "Year3"
            });

            await _service.AddMovie(new AddMovieDTO()
            {
                Title = "Title3",
                Genre = "Genre3",
                Year = "Year3"
            });

            Assert.That(_db.Movies.Count, Is.EqualTo(3));
        }

        [Test, Order(2)]
        public void TestRemoveMovie()
        {

            _service.DeleteMovie("Title3");
            Assert.That(_db.Movies.Count(), Is.EqualTo(2));
        }
        [Test, Order(3)]
        public void TestGetMovieByName()
        {
           var movie =  _service.GetMovieByName("Title1").Result;
            Assert.NotNull(movie);
            Assert.That(movie.Title, Is.EqualTo("Title1"));
        }

        [Test,Order(4)]
        public void TestGetAllMovies()
        {
            var Movies = _service.GetAllMovies();
            Assert.That(Movies.Count(), Is.EqualTo(2));
        }

        [Test,Order(5)]
        public void TestGetMovieByGenre()
        {
            var movie = _service.GetMoviesByGenre("Genre3");
            Assert.That(movie.Count(), Is.EqualTo(1));
            Assert.That(movie.Select(m => m.Genre), Is.All.EqualTo("Genre3"));
        }
        [Test,Order(6)]
        public void TestGetMovieByYear()
        {
            var movie = _service.GetMoviesByYear("Year3");
            Assert.That(movie.Count(), Is.EqualTo(1));
            Assert.That(movie.Select(m => m.Year), Is.All.EqualTo("Year3"));
        }
    }
}
