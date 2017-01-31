using System;
using System.Collections.Generic;

namespace ChessHostService.Models
{
    public class Knight : ChessPiece
    {
        public Knight()
        {

        }

        public Knight(Knight orig)
        {
            Color = orig.Color;
        }

        public override string Name
        {
            get { return "Knight"; }
        }

        public override ChessPieceType Type
        {
            get { return ChessPieceType.Knight; }
        }

        public override List<Tuple<int, int>> MovePattern
        {
            get
            {
                return new List<Tuple<int, int>>
                {
                    new Tuple<int, int>(1, 2),
                    new Tuple<int, int>(1, -2),
                    new Tuple<int, int>(-1, 2),
                    new Tuple<int, int>(-1,-2),
                    new Tuple<int, int>(2, 1),
                    new Tuple<int, int>(2, -1),
                    new Tuple<int, int>(-2, 1),
                    new Tuple<int, int>(-2, -1)
                };
            }
        }
    }
}