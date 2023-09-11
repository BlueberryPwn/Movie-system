namespace Movie_system.Models
{
    public class LikedGenre
    {
        public int LikedGenreId { get; set; }
        public int GenreId { get; set; }
        public int LikedByUserId { get; set; }
    }
}
