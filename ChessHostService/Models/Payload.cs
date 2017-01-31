namespace ChessHostService.Models
{
    public class Payload
    {
        public ChessBoard Board { get; set; }
        public Color Turn { get; set; }
    }
}