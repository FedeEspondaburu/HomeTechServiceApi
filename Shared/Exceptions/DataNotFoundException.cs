namespace Shared.Exceptions
{
    public class DataNotFoundException : Exception
    {
        private readonly string _message;
        public DataNotFoundException(string notfoundInfo)
        {
            _message = $"The requested data was not found: {notfoundInfo}";
        }
        public override string Message => _message;
    }
}