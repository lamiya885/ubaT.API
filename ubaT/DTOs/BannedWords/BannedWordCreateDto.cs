using ubaT.Entities;

namespace ubaT.DTOs.BannedWords
{
    public class BannedWordCreateDto
    {
        public string Text { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
    }
}
