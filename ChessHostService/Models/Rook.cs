using System;
using System.Collections.Generic;

namespace ChessHostService.Models
{
    public class Rook : ChessPiece
    {
        public override string Name
        {
            get { return "Rook"; }
        }

        public override ChessPieceType Type
        {
            get { return ChessPieceType.Rook;}
        }

        public Rook()
        {

        }

        public Rook(Rook orig)
        {
            Color = orig.Color;
        }

        public override bool CanMoveMoreThanOneCell { get { return true; } }

        public override List<Tuple<int, int>> MovePattern
        {
            get
            {
                return new List<Tuple<int, int>>
                {
                    new Tuple<int, int>(1, 0),
                    new Tuple<int, int>(-1, 0),
                    new Tuple<int, int>(0, 1),
                    new Tuple<int, int>(0,-1),
                };

            }
        }
    }
}