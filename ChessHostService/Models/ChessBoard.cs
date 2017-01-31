using System.Collections.Generic;

namespace ChessHostService.Models
{
    public class ChessBoard
    {
        public const int MaxX = 8;
        public const int MaxY = 8;
        public List<Cell> Cells { get; set; }

        public ChessBoard()
        {
            Cells = new List<Cell>
            {
                // White Side
                new Cell(1,1, new Rook  {Color = Color.White}),
                new Cell(2,1, new Knight {Color = Color.White}),
                new Cell(3,1, new Bishop {Color = Color.White}),
                new Cell(4,1, new Queen {Color = Color.White}),
                new Cell(5,1, new King  {Color = Color.White}),
                new Cell(6,1, new Bishop {Color = Color.White}),
                new Cell(7,1, new Knight {Color = Color.White}),
                new Cell(8,1, new Rook  {Color = Color.White}),
                new Cell(1,2, new Pawn  {Color = Color.White}),
                new Cell(2,2, new Pawn  {Color = Color.White}),
                new Cell(3,2, new Pawn  {Color = Color.White}),
                new Cell(4,2, new Pawn  {Color = Color.White}),
                new Cell(5,2, new Pawn  {Color = Color.White}),
                new Cell(6,2, new Pawn  {Color = Color.White}),
                new Cell(7,2, new Pawn  {Color = Color.White}),
                new Cell(8,2, new Pawn  {Color = Color.White}),
                // Black Side            
                new Cell(1,8, new Rook  {Color = Color.Black}),
                new Cell(2,8, new Knight {Color = Color.Black}),
                new Cell(3,8, new Bishop {Color = Color.Black}),
                new Cell(4,8, new Queen {Color = Color.Black}),
                new Cell(5,8, new King  {Color = Color.Black}),
                new Cell(6,8, new Bishop {Color = Color.Black}),
                new Cell(7,8, new Knight {Color = Color.Black}),
                new Cell(8,8, new Rook  {Color = Color.Black}),
                new Cell(1,7, new Pawn  {Color = Color.Black}),
                new Cell(2,7, new Pawn  {Color = Color.Black}),
                new Cell(3,7, new Pawn  {Color = Color.Black}),
                new Cell(4,7, new Pawn  {Color = Color.Black}),
                new Cell(5,7, new Pawn  {Color = Color.Black}),
                new Cell(6,7, new Pawn  {Color = Color.Black}),
                new Cell(7,7, new Pawn  {Color = Color.Black}),
                new Cell(8,7, new Pawn  {Color = Color.Black}),
            };

            for (int y = 3; y <= 6; y++)
            {
                for (int x = 1; x <= 8; x++)
                {
                    Cells.Add(new Cell(x, y, null));
                }
            }
        }

        public void MakeMove(ChessMove move)
        {
            var from = Cells.Find(x => x.Equals(move.From));
            var to = Cells.Find(x => x.Equals(move.To));

            to.Piece = from.Piece;
            to.Piece.HasMoved = true;
            from.Piece = null;
        }
    }
}