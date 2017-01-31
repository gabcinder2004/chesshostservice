using System;
using System.Collections.Generic;

namespace ChessHostService.Models
{
    public class Queen : ChessPiece
    {
        public Queen()
        {

        }

        public Queen(Queen queen)
        {
            Color = queen.Color;
        }

        public override string Name
        {
            get { return "Queen"; }
        }

        public override ChessPieceType Type
        {
            get { return ChessPieceType.Queen; }
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
                    new Tuple<int, int>(-1, -1),
                    new Tuple<int, int>(0, 1),
                    new Tuple<int, int>(0, -1),
                    new Tuple<int, int>(1, 0),
                    new Tuple<int, int>(-1, 0),
                };

            }
        }
    }
}