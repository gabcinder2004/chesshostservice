using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessHostService.Models
{
    public class Pawn : ChessPiece
    {
        public Pawn()
        {

        }

        public Pawn(Pawn orig)
        {
            Color = orig.Color;
        }

        public override string Name
        {
            get { return "Pawn"; }
        }

        public override ChessPieceType Type
        {
            get { return ChessPieceType.Pawn; }
        }

        public override List<Tuple<int, int>> MovePattern
        {
            get
            {
                return new List<Tuple<int, int>>
                {
                    new Tuple<int, int>(0, 1)
                };
            }
        }

        public override List<ChessMove> GetAvailableMoves(List<Tuple<int, int>> movePattern, Cell currentCell, ChessBoard board)
        {
            var pattern = MovePattern;

            if (!HasMoved)
            {
                pattern.Add(new Tuple<int, int>(0, 2));
            }
            else
            {
                MovePattern.RemoveAll(x => x.Item1 == 2 && x.Item2 == 0);
            }

            var topRightCell = board.Cells.FirstOrDefault(cell => cell.X == currentCell.X + 1 && cell.Y == currentCell.Y + 1);
            if (topRightCell != null && !topRightCell.IsEmpty() && topRightCell.Piece.Color != currentCell.Piece.Color)
            {
                pattern.Add(new Tuple<int, int>(1, 1));
            }

            var topLeftCell = board.Cells.FirstOrDefault(cell => cell.X == currentCell.X - 1 && cell.Y == currentCell.Y + 1);
            if (topLeftCell != null && !topLeftCell.IsEmpty() && topLeftCell.Piece.Color != currentCell.Piece.Color)
            {
                pattern.Add(new Tuple<int, int>(1, 1));
            }

            return base.GetAvailableMoves(pattern, currentCell, board);
        }
    }
}