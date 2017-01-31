using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChessHostService.Data;
using ChessHostService.Models;
using ChessHostService.Services;

namespace ChessHostService.Controllers
{
    public class GameController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Start()
        {
            var chessGame = new ChessGame();
            DataOwner.AddGame(chessGame);

            var runner = new GameRunner(chessGame);
            var result = runner.StartGame();

            if (result == false)
            {
                return BadRequest("Something went wrong");
            }

            return Ok(chessGame);
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            var game = DataOwner.GetGame(id);

            if (game == null)
            {
                return BadRequest();
            }

            return Ok(game);
        }
    }
}
