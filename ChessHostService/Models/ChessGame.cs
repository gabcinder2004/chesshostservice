using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessHostService.Models
{
    public class ChessGame
    {
        public Guid Id { get; set; }
        public string Status { get { return GameStatus.ToString(); } }
        private GameStatus GameStatus { get; set; }
        public ChessBoard Board { get; set; }
        public List<ChessMove> Moves { get; set; }

        public TimeSpan TotalGameTime
        {
            get
            {
                var time = TimeSpan.Zero;
                Moves.ForEach(x => time = time.Add(x.Elapsed));
                return time;
            }
        }

        public ChessGame()
        {
            Id = Guid.NewGuid();
            Board = new ChessBoard();
        }

        public Color Winner
        {
            get
            {
                return IsGameOver()
                    ? Color.None
                    : Board.Cells.Any(x => x.Piece.Color == Color.White && x.Piece.Name == "King") ? Color.White : Color.Black;
            }
        }

        public bool IsGameOver()
        {
            return Board.Cells.Count(c => c.Piece.Type == ChessPieceType.King) == 2;
        }

        public void SetStatus(GameStatus status)
        {
            GameStatus = status;
        }
    }
}