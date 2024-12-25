namespace ubaT.Exceptions.Game
{
    public class GameAllReadyFinished : Exception, IBaseException
    {
        public int StatusCode =>StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public GameAllReadyFinished() 
        {
            ErrorMessage = "Oyun artiq oynanilib";
        }
        public GameAllReadyFinished (string Message)
        {
            ErrorMessage = Message;
        }
    }
}
