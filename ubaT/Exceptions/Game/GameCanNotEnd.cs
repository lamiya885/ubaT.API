namespace ubaT.Exceptions.Game
{
    public class GameCanNotEnd : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public GameCanNotEnd() 
        {
            ErrorMessage = "oyunu bitirmek mumkun olmadi";
        }
        public GameCanNotEnd(string message)
        {
            ErrorMessage = message;
        }
    }
}
