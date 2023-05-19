﻿namespace MovieCatalog___Practice_Quest.Models
{
    [Serializable]
    public class Movie 
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
    }
}
