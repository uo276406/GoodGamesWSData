namespace GoodGames.Data.Model
{
    public class Game
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public GameStatus Status { get; set; }
        public required User Player { get; set; }
        public double Mark { get; set; }
        public string? Review { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}