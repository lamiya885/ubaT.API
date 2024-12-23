namespace ubaT.Exceptions.Language
{
    public class LanguageExistException : Exception, IBaseException
    {
        public int StatusCode =>StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }

        public LanguageExistException()
        {
            ErrorMessage = "Dil movcuddur";
        }
        public LanguageExistException(string Message):base(Message) 
        {
            ErrorMessage =Message;
        }
    }
}
