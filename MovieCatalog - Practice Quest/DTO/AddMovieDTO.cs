namespace MovieCatalog___Practice_Quest.DTO
{
    public class AddMovieDTO
    {

        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string? Description { get; set; }
    }
}
