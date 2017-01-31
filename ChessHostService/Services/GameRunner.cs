using System.Collections.Generic;
using System.Configuration;
using ChessHostService.Models;

namespace ChessHostService.Services
{
    public class GameRunner
    {
        public ChessGame Game { get; set; }
        public Dictionary<Color, Player> Players { get; set; }

        public GameRunner(ChessGame game)
        {
            Game = game;
        }

        public bool StartGame()
        {
            if (Game == null)
            {
                Game = new ChessGame();
            }

            InitializePlayers();
            return NextMove(Color.White);
        }

        public void InitializePlayers()
        {
            var player1Name = ConfigurationManager.AppSettings["Player1"];
            var player1Url = ConfigurationManager.AppSettings["Player1Url"];

            var player1 = new Player { Name = player1Name, ServiceUrl = player1Url };

            var player2Name = ConfigurationManager.AppSettings["Player2"];
            var player2Url = ConfigurationManager.AppSettings["Player2Url"];

            var player2 = new Player { Name = player2Name, ServiceUrl = player2Url };

            if (Utility.Randomize(1, 2) == 1)
            {
                Players[Color.White] = player1;
                Players[Color.Black] = player2;
                return;
            }

            Players[Color.Black] = player1;
            Players[Color.White] = player2;
        }

        public bool NextMove(Color turn)
        {
            var player = Players[turn];
            var move = player.NextMove(Game.Board, turn);

            if (move == null)
            {
                return false;
            }

            var validMove = ValidateMove(move);

            if (!validMove)
            {
                return false;
            }

            Game.Board.MakeMove(move);
            Game.Moves.Add(move);

            if (Game.IsGameOver())
            {
                return true;
            }

            return NextMove(turn == Color.White ? Color.Black : Color.White);
        }

        public bool ValidateMove(ChessMove move)
        {
            var validMoves = move.From.Piece.GetAvailableMoves(move.From.Piece.MovePattern, move.From, Game.Board);

            return validMoves.Contains(move);
        }
    }
}