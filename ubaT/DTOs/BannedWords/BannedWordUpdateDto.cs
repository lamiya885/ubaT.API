using ubaT.Entities;

namespace ubaT.DTOs.BannedWords
{
    public class BannedWordUpdateDto
    {
        public string Text { get; set; }
        public int WordId { get; set; }
        public string wordText { get; set; }
        public Word Word { get; set; }
    }
}
