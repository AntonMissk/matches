using MatchesGame_API.Models;
using MatchesGame_API.Models.DTO;

namespace MatchesGame_API.Data
{
    public class MoveStore
    {
        public static List<Move> Moves = new List<Move> {
             new Move{moveId= 0, moveCount=0 },
        };
    }
}
