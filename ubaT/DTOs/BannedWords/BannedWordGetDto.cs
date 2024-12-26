using ubaT.Entities;

namespace ubaT.DTOs.BannedWords
{
    public class BannedWordGetDto
    {
        public string Text { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
    }
}
