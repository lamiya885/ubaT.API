namespace ubaT.Exceptions.Game
{
    public class GameAllreadyNotStarted : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
    }
}
