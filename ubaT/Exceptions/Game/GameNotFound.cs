namespace ubaT.Exceptions.Game
{
    public class GameNotFound : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public GameNotFound()
        {
            ErrorMessage = "Oyun tapilmadi";
        }
        public GameNotFound(string Message)
        {
            ErrorMessage = Message;
        }
    }
}
