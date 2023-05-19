using MovieCatalog___Practice_Quest.DTO;
using MovieCatalog___Practice_Quest.Models;

namespace MovieCatalog___Practice_Quest.Interfaces
{
    public interface IMovieService
    {

        Task AddMovie(AddMovieDTO dto);
        Task DeleteMovie(string name);
        Task<Movie?> GetMovieByName(string name);
        Task<Movie?> GetLastAddedMovie();
        IEnumerable<Movie?> GetMoviesByGenre(string genre);
        IEnumerable<Movie?> GetMoviesByYear(string year);

        IEnumerable<Movie?> GetAllMovies();

    }
}
