using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ChessHostService.Services;

namespace ChessHostService.Models
{
    public class ChessPiece
    {
        public Color Color { get; set; }
        public bool HasMoved { get; set; }
        public virtual bool CanMoveMoreThanOneCell { get; set; }

        public virtual string Name { get { throw new NotImplementedException(); } }
        public virtual List<Tuple<int, int>> MovePattern { get; set; }

        public string ShortName
        {
            get { return ChessUtility.NameToChar[Name]; }
        }

        public virtual ChessPieceType Type
        {
            get { throw new NotImplementedException(); }
        }

        public ChessPiece()
        {

        }

        public ChessPiece(Color color)
        {
            Color = color;
        }

        public virtual List<ChessMove> GetAvailableMoves(List<Tuple<int, int>> movePattern, Cell currentCell, ChessBoard board)
        {
            var availableMoves = new List<ChessMove>();

            foreach (var pattern in movePattern)
            {
                var directionX = pattern.Item1;
                var directionY = pattern.Item2;

                while (true)
                {
                    var newCell = board.Cells.SingleOrDefault(cell => cell.X == currentCell.X + directionX && cell.Y == currentCell.Y + directionY);

                    // If cell doesn't exist, or the piece on that cell is the same color as the piece trying to move
                    if (newCell == null || !newCell.IsEmpty() && newCell.Piece.Color == currentCell.Piece.Color)
                    {
                        break;
                    }

                    var action = newCell.IsEmpty() ? ChessAction.MOVE : ChessAction.KILL;

                    availableMoves.Add(new ChessMove(currentCell, newCell, action, currentCell.Piece.Color));

                    // If the piece moved, then try to move another cell in the same direction (except for Knights)
                    if (action == ChessAction.MOVE && currentCell.Piece.CanMoveMoreThanOneCell)
                    {
                        directionX += pattern.Item1;
                        directionY += pattern.Item2;
                        continue;
                    }

                    break;
                }
            }

            return availableMoves;
        }
    }
}