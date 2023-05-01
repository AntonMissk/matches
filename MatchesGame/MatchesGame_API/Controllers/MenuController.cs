using MatchesGame_API.Data;
using MatchesGame_API.Models;
using MatchesGame_API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchesGame_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpGet]
        [Route("GetGames")]
       
        public IEnumerable<Game> GetGames()
        {
            return GameStore.Games;
        }
        [HttpGet]
        [Route("GetPlayers")]
        public IEnumerable<Player> GetPlayers()
        {
            return PlayerStore.Players;
        }

        [HttpPost]
        [Route("CreateGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Game> CreateGame([FromBody] GameDTO gameDTO)
        {
            if (gameDTO == null)
            {
                return BadRequest();
            }
            if (gameDTO.GameId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Game game = new Game
            {
                matchesStart = gameDTO.matchesStart,
                totalMatches = gameDTO.totalMatches,
                Players = gameDTO.Players,
                Moves = gameDTO.Moves,
                Winner = gameDTO.Winner,
            };
            
            game.GameId = GameStore.Games.OrderByDescending(u => u.GameId).FirstOrDefault().GameId + 1;
            
           
            GameStore.Games.Add(game);
            return Ok(game);
        }

        [HttpPost]
        [Route("CreatePlayer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Player> CreatePlayer([FromBody] PlayerDTO playerDTO)
        {
            if (playerDTO == null)
            {
                return BadRequest();
            }
            if (playerDTO.playerId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Player player = new Player
            {
                playerName = playerDTO.playerName,
            };

            player.playerId = PlayerStore.Players.OrderByDescending(u => u.playerId).FirstOrDefault().playerId + 1;


            PlayerStore.Players.Add(player);
            return Ok(player);
        }

    }
}
