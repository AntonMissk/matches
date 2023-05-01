using MatchesGame_API.Models;
using MatchesGame_API.Models.DTO;

namespace MatchesGame_API.Data
{
    public class PlayerStore
    {


        public static List<Player> Players = new List<Player> {
            new Player{playerId=0}
        };
    }
}
