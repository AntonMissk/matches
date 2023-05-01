using MatchesGame_API.Data;
using MatchesGame_API.Models;
using MatchesGame_API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MatchesGame_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Game> GetGame() {
            return Ok(GameStore.Games.Last());
        }

        [HttpPut]
        public IActionResult GameMove([FromBody]Move move)
        {
            var actualGame = GameStore.Games.Last();

            if (actualGame == null)
            {
                return BadRequest();
            }

            if (move.moveValue >= 0 && move.moveValue <= actualGame.matchesStart)
            {

                move.moveCount = actualGame.Moves.Last().moveCount + 1;
                if (move.moveCount % 2 == 0)
                {
                    move.playerId = actualGame.Players.Last().playerId;
                    var player1 = actualGame.Players.Last();
                    player1.matchesHave += move.moveValue;
                    actualGame.totalMatches -= move.moveValue;

                }
                else
                {
                    move.playerId = actualGame.Players.First().playerId;
                    var player2 = actualGame.Players.First();
                    player2.matchesHave += move.moveValue;
                    actualGame.totalMatches -= move.moveValue;
                }
                move.moveId = MoveStore.Moves.OrderByDescending(u => u.moveId).FirstOrDefault().moveId + 1;
                actualGame.Moves.Add(move);

            }
            else
            {
                return BadRequest();
            }

            if (actualGame.totalMatches == 0)
            {
                if(actualGame.Players.First().matchesHave > actualGame.Players.Last().matchesHave)
                {
                    actualGame.Winner.playerId = actualGame.Players.First().playerId;
                    actualGame.Winner.playerName = actualGame.Players.First().playerName;
                    actualGame.Winner.matchesHave = actualGame.Players.First().matchesHave;
                }
                else
                {
                    actualGame.Winner.playerId = actualGame.Players.Last().playerId;
                    actualGame.Winner.playerName = actualGame.Players.Last().playerName;
                    actualGame.Winner.matchesHave = actualGame.Players.Last().matchesHave;
                }
            }
            return NoContent();
        }

    }

      
}
  