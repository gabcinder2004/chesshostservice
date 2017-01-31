using System;

namespace ChessHostService.Models
{
    public class ChessMove : IEquatable<ChessMove>
    {
        public Cell From { get; set; }
        public Cell To { get; set; }
        public TimeSpan Elapsed { get; set; }

        public ChessAction Action { get; set; }
        public Color Turn { get; set; }

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
    }
}