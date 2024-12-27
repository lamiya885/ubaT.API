using ubaT.DTOs.Words;
using ubaT.Entities;

namespace ubaT.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Success { get; set; }
        public byte Fail { get; set; }
        public byte Skip { get; set; }
        public int  Score { get; set; }
        public Stack<WordForGameDto> Words { get; set; }
        public IEnumerable<int> UssedWordIds { get; set; }
        public int MaxSkipCount { get; set; }
    }
}
