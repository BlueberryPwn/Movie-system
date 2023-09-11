namespace Movie_system.Models
{
    public class LikedGenres
    {
        public int LikedGenreId { get; set; }
        public int GenreId { get; set; }
        public int UserId { get; set; }
    }
}
