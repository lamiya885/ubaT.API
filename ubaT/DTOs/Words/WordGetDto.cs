namespace ubaT.DTOs.Words
{
    public class WordGetDto
    {
        public string Text { get; set; }
        public string LangCode { get; set; }
        public HashSet<string> BannedWords { get; set; }
    }
}
