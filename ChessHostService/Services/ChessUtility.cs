using System.Collections.Generic;

namespace ChessHostService.Services
{
    public static class ChessUtility
    {
        public static Dictionary<string, int> LetterToNumber = new Dictionary<string, int>()
        {
            {"A", 1},
            {"B", 2},
            {"C", 3},
            {"D", 4},
            {"E", 5},
            {"F", 6},
            {"G", 7},
            {"H", 8},
        };

        public static Dictionary<int, string> NumberToLetter = new Dictionary<int, string>()
        {
            {1, "A"},
            {2, "B"},
            {3, "C"},
            {4, "D"},
            {5, "E"},
            {6, "F"},
            {7, "G"},
            {8, "H"}
        };

        public static Dictionary<string, string> NameToChar = new Dictionary<string, string>()
        {
            {"Pawn", "P"},
            {"Rook", "R"},
            {"Knight", "N"},
            {"Bishop", "B"},
            {"Queen", "Q"},
            {"King", "K"},
        };
    }
}