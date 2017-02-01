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

        public override ChessPiece Clone()
        {
            return new Pawn(this);
        }
        public override string Name
        {
            get { return "Pawn"; }
        }

        public override int Value { get { return 1; } }

        public override ChessPieceType Type
        {
            get { return ChessPieceType.Pawn; }
        }

        public override List<Tuple<int, int>> MovePattern
        {
            get
            {
                return new List<Tuple<int, int>> { };
            }
        }

        public override List<ChessMove> GetAvailableMoves(List<Tuple<int, int>> movePattern, Cell currentCell, ChessBoard board)
        {
            var pattern = MovePattern;

            var direction = currentCell.Piece.Color == Color.White ? 1 : -1;

            pattern.Add(new Tuple<int, int>(0, 1 * direction));

            if (!HasMoved)
            {
                pattern.Add(new Tuple<int, int>(0, 2 * direction));
            }

            var cell1 = board.Cells.FirstOrDefault(cell => cell.X == currentCell.X + 1 && cell.Y == currentCell.Y + (1 * direction));
            if (cell1 != null && !cell1.IsEmpty() && cell1.Piece.Color != currentCell.Piece.Color)
            {
                pattern.Add(new Tuple<int, int>(1, 1 * direction));
            }

            var cell2 = board.Cells.FirstOrDefault(cell => cell.X == currentCell.X - 1 && cell.Y == currentCell.Y + (1 * direction));
            if (cell2 != null && !cell2.IsEmpty() && cell2.Piece.Color != currentCell.Piece.Color)
            {
                pattern.Add(new Tuple<int, int>(-1, 1 * direction));
            }

            return base.GetAvailableMoves(pattern, currentCell, board);
        }
    }
}