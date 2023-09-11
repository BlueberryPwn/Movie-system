namespace Movie_system.Models
{
    public class Movies
    {
        public int MovieId { get; set; }
        public string? MovieName { get; set; }
        public string? MovieGenre { get; set; }
        public string? MovieDescription { get; set; }
        public int MovieLink { get; set; }
        public int UserId { get; set; }
    }
}
