namespace Movie_system.Models
{
    public class Movies
    {
        public int MovieId { get; set; }
        public string? MovieName { get; set; }
        public int MovieGenre { get; set; }
        public string? MovieDescription { get; set; }
        public string? Link { get; set; }
        public int UserId { get; set; }
    }
}
