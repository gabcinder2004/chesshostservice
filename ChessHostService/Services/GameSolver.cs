using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ChessHostService.Models;

namespace ChessHostService.Services
{
    public class GameSolver
    {
        public bool GameOver;

        public Color Winner = Color.None;
        public ChessGame Game { get; set; }
        public List<GameResult> Results { get; set; }

        public Stopwatch Stopwatch { get; set; }

        public GameSolver(ChessGame game)
        {
            Game = game;
            Results = new List<GameResult>();
        }

        public ChessMove NextMove(ChessBoard board, Color colorTurn)
        {
            FindMoves(board, colorTurn, new List<ChessMove>());

            return null;
        }

        private void FindMoves(ChessBoard board, Color colorTurn, List<ChessMove> allMoves)
        {
            if (allMoves.Count > 3)
            {
                Results.Add(new GameResult() { Moves = allMoves, Winner = Color.None });
                return;
            }

            var cells = board.Cells.Where(cell => !cell.IsEmpty() && cell.Piece.Color == colorTurn).ToList();
            cells.ForEach(c => c.Piece.AvailableMoves = c.Piece.GetAvailableMoves(c.Piece.MovePattern, c, board));
            var availableMoves = cells.SelectMany(x => x.Piece.AvailableMoves).ToList();

            // If the color cannot make any moves, they lose.
            if (!availableMoves.Any())
            {
                Results.Add(new GameResult() { Moves = allMoves, Winner = colorTurn == Color.White ? Color.Black : Color.White });
                return;
            }

            // If the color can kill the opposing king, they win.
            if (availableMoves.Any(move => !move.To.IsEmpty() && move.To.Piece.Type == ChessPieceType.King && move.Action == ChessAction.KILL))
            {
                var move = availableMoves.First(m => !m.To.IsEmpty() && m.To.Piece.Type == ChessPieceType.King && m.Action == ChessAction.KILL);
                allMoves.Add(move);
                Results.Add(new GameResult() { Moves = allMoves, Winner = colorTurn });
                return;
            }

            if (DetectRepeatedMoves(allMoves, colorTurn))
            {
                return;
            }

            // Game cannot end this turn, search for a game result.
            foreach (var move in availableMoves)
            {
                var currentMoves = new List<ChessMove>();
                Debug.WriteLine(move);
                currentMoves.AddRange(allMoves);
                var newBoard = board.Clone();

                newBoard.MakeMove(move);
                currentMoves.Add(move);

                var nextColor = colorTurn == Color.White ? Color.Black : Color.White;
                FindMoves(newBoard, nextColor, currentMoves);
            }
        }

        private bool DetectRepeatedMoves(List<ChessMove> moves, Color turn)
        {
            if (moves.Count < 8)
            {
                return false;
            }

            var lastMoves = moves.TakeLast(8).ToList().Where(x => x.From.Piece.Color == turn).ToList();

            var count = lastMoves.Count(x => x.From.Position == lastMoves[0].From.Position && x.To.Position == lastMoves[0].To.Position);
            var count2 = lastMoves.Count(x => x.From.Position == lastMoves[1].From.Position && x.To.Position == lastMoves[1].To.Position);

            if (count > 1 && count2 > 1)
            {
                return true;
            }

            return false;
        }
    }

    public class GameResult
    {
        public List<ChessMove> Moves { get; set; }
        public Color Winner { get; set; }
    }
}