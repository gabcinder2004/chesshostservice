using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace ChessHostService.Models
{
    public class ChessMove : IEquatable<ChessMove>, IEqualityComparer<ChessMove>
    {
        public Cell From { get; set; }
        public Cell To { get; set; }
        public TimeSpan Elapsed { get; set; }

        public ChessAction Action { get; set; }
        public Color Turn { get; set; }

        public int Value { get; set; }

        public ChessMove(Cell @from, Cell to, ChessAction action, Color turn)
        {
            From = @from;
            To = to;
            Action = action;
            Turn = turn;
        }

        public bool Equals(ChessMove other)
        {
            if (other == null)
            {
                return false; 
            }

            return other.From == From && other.To == To && Turn == other.Turn;
        }

        public override string ToString()
        {
            var piece = From.Piece.GetType();

            return string.Format("{0} {4} | {1}:{2} | {3} ({5})", Turn, From, To, Action, piece.Name, Elapsed);
        }

        public bool Equals(ChessMove x, ChessMove y)
        {
            if (x.From.Position == y.From.Position && x.To.Position == y.To.Position)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(ChessMove obj)
        {
            if (obj == null)
            {
                return 1;
            }

            return obj.From.Position.GetHashCode() * 17 + obj.To.Position.GetHashCode();
        }
    }
}