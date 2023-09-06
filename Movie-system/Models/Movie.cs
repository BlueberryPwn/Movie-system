namespace Movie_system.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public string? MovieDescription { get; set; }
        public string? MovieLink { get; set; }
        public int MovieUserId { get; set; }
    }
}
