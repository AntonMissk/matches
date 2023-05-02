using MatchesGame_API.Models.DTO;

namespace MatchesGame_API.Models
{
    public class Move
    {
        public int moveId { get; set; }
        public int moveValue { get; set; }
        public int playerId { get; set; }
        public int moveCount { get; set; }


    }
}
