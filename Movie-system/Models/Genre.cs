namespace Movie_system.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string? GenreTitle { get; set; }
        public string? GenreDescription { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
    }
}
