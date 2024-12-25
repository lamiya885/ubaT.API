namespace ubaT.DTOs.Games
{
    public class GameSuccessDto
    {

        public int BannedWordCount { get; set; }
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public int Time { get; set; }
        public string LangCode { get; set; }

    }
}
