namespace MatchesGame_API.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public DateTime CreateDate { get; set; }
        public int matchesStart { get; set; }
        public int totalMatches { get; set; }
        public Player Winner { get; set; }
        public List<Move> Moves { get; set; }
        public List<Player> Players { get; set; }
    }
}
