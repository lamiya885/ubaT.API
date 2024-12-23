namespace ubaT.Exceptions.BannedWord
{
    public class BannedWordExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public BannedWordExistException()
        {
            ErrorMessage = "Bu qadagan edilmis soz movcuddur";
        }
        public BannedWordExistException(string message):base(message)
        {
            ErrorMessage= message;
            
        }
    }

}
