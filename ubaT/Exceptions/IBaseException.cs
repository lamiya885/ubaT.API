namespace ubaT.Exceptions
{
    public interface IBaseException
    {
        int StatusCode { get; }
        String ErrorMessage { get; }
    }
}
