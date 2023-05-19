using MovieCatalog___Practice_Quest.DTO;

namespace MovieCatalog___Practice_Quest.Models
{
    [Serializable]
    public class Movie 
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Genre { get; set; } = null!;
        public string Year { get; set; } = null!;

        public static Movie GetMovieFromDTO(AddMovieDTO amd)
        {
            return new Movie()
            {

                Id = Guid.NewGuid(),
                Title = amd.Title,
                Description = amd.Description,
                Genre = amd.Genre,
                Year = amd.Year

            };
        }
    }
}
