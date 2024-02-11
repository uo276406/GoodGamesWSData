namespace GoodGames.Data.Model
{
    public class Game
    {
        public int Id { get; set; }
        public GameStatus Status { get; set; }
        public User Player { get; set; }
        public double Mark { get; set; }
    }
}