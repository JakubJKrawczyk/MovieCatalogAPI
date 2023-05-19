using Moq;
using MovieCatalog___Practice_Quest.Controllers;
using MovieCatalog___Practice_Quest.DTO;
using MovieCatalog___Practice_Quest.Interfaces;
using MovieCatalog___Practice_Quest.Models;
using NuGet.Frameworks;

namespace MovieCatalogTests
{
    [TestFixture]
    public class MovieControllerTest
    {

        private MovieCatalogController _controller = null!;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IMovieService>();
            mock.Setup(x => x.GetLastAddedMovie()).ReturnsAsync(new Movie());
            mock.Setup(x => x.GetMoviesByGenre("Fantasy")).Returns(new[] { new Movie(), new Movie() } );
            mock.Setup(x => x.GetMoviesByYear("2019")).Returns(new[] { new Movie(), new Movie(), new Movie(), new Movie() } );
            _controller = new MovieCatalogController(mock.Object);
        }
        [Test]
        public void TestGetByGenres()
        {
            var movies = _controller.GetMovieByGenre("Fantasy");
            Assert.That(movies.Count() == 2);
        }
        [Test]
        public void TestGetByYear()
        {
            var moviesByYear = _controller.GetMovieByYear("2019");

            Assert.That(moviesByYear.Count() == 4);
        }
        [Test]
        public void TestGetLastAddedMovie()
        {
            var movie = _controller.GetLastMovie();

            Assert.NotNull(movie);
        }
       
    }
}
