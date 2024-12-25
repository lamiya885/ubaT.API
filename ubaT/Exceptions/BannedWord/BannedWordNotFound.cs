namespace ubaT.Exceptions.BannedWord
{
    public class BannedWordNotFound : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public BannedWordNotFound()
        {
            ErrorMessage = "Axtardiginiz qadagan edilmis soz tapilmadi ";
        }
        public BannedWordNotFound(string Message)
        {
            ErrorMessage = Message;
        }
    }

}
