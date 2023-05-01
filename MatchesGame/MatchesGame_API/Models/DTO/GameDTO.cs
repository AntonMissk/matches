namespace MatchesGame_API.Models.DTO
{
    public class GameDTO
    {

        public int GameId { get; set; }
        public int matchesStart { get; set; }
        public int totalMatches { get; set; }
        public Player Winner { get; set; }
        public List<Move> Moves { get; set; }
        public List<Player> Players { get; set; }
    }
}
