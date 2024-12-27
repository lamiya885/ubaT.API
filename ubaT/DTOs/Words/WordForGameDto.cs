namespace ubaT.DTOs.Words
{
    public class WordForGameDto
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string WordText { get; set; }
        public IEnumerable<string> BannedWords { get; set; }
    }
}
