using System;

namespace ChessHostService.Services
{
    public static class Utility
    {
        public static int Randomize(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}