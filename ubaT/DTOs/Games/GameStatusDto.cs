using ubaT.Entities;

namespace ubaT.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Success { get; set; }
        public byte Fail { get; set; }
        public byte Skip { get; set; }
        public Stack<Word> Words { get; set; }
        public int[] UssedWordId { get; set; }
    }
}
