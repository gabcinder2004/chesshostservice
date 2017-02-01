using System;
using ChessHostService.Services;

namespace ChessHostService.Models
{
    public class Cell : IEquatable<Cell>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ChessPiece Piece { get; set; }

        public string Position
        {
            get
            {
                return ChessUtility.NumberToLetter[X] + Y;
            }
        }

        public Cell(int x, int y, ChessPiece piece)
        {
            X = x;
            Y = y;
            Piece = piece;
        }

        public override string ToString()
        {
            if (Piece == null)
            {
                return string.Format("{0}", Position);
            }

            return string.Format("{0}", Position);
        }

        public bool IsEmpty()
        {
            return Piece == null;
        }

        public object Clone()
        {
            return new Cell(X, Y, IsEmpty() ? null : Piece.Clone());
        }

        public bool Equals(Cell other)
        {
            if (other == null)
            {
                return false;
            }

            return other.X == X && other.Y == Y;
        }
    }
}