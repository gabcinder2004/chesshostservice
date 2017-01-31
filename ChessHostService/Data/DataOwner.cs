using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChessHostService.Models;

namespace ChessHostService.Data
{
    public static class DataOwner
    {
        private static List<ChessGame> Games = new List<ChessGame>();
        
        public static void AddGame(ChessGame game)
        {
            Games.Add(game);
        }

        public static ChessGame GetGame(Guid guid)
        {
            return Games.FirstOrDefault(g => g.Id == guid);
        }
    }
}