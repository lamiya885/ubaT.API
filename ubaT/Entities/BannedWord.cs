﻿namespace ubaT.Entities
{
    public class BannedWord
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int  WordId { get; set; }
        public string WordText { get; set; }
        public Word Word { get; set; }
    }
}
