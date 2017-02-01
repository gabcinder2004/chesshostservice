using System;
using System.Collections.Generic;

namespace ChessHostService.Models
{
    public class Bishop : ChessPiece
    {
        public Bishop()
        {

        }

        public Bishop(Bishop orig)
        {
            Color = orig.Color;
        }

        public override ChessPiece Clone()
        {
            return new Bishop(this);
        }

        public override string Name
        {
            get { return "Bishop"; }
        }

        public override int Value { get { return 2; } }

        public override ChessPieceType Type
        {
            get { return ChessPieceType.Bishop; }
        }

        public override bool CanMoveMoreThanOneCell { get { return true; } }
        public override List<Tuple<int, int>> MovePattern
        {
            get
            {
                return new List<Tuple<int, int>>
                {
                    new Tuple<int, int>(1, 1),
                    new Tuple<int, int>(1, -1),
                    new Tuple<int, int>(-1, 1),
                    new Tuple<int, int>(-1,-1),
                };

            }
        }
    }
}