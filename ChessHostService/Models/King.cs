using System;
using System.Collections.Generic;

namespace ChessHostService.Models
{
    public class King : ChessPiece
    {
        public King()
        {

        }

        public King(Pawn orig)
        {
            Color = orig.Color;
        }

        public override string Name
        {
            get { return "King"; }
        }

        public override ChessPieceType Type
        {
            get { return ChessPieceType.King; }
        }

        public override List<Tuple<int, int>> MovePattern
        {
            get
            {
                return new List<Tuple<int, int>>
                {
                    new Tuple<int, int>(1, 1),
                    new Tuple<int, int>(1, -1),
                    new Tuple<int, int>(-1, 1),
                    new Tuple<int, int>(-1, -1),
                    new Tuple<int, int>(0, 1),
                    new Tuple<int, int>(0, -1),
                    new Tuple<int, int>(1, 0),
                    new Tuple<int, int>(-1, 0)
                };
            }
        }
    }
}