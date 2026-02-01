namespace Shared.Exceptions
{
    public class DataNotFoundException : Exception
    {
        private readonly string _message;
        public DataNotFoundException(string notfoundInfo)
        {
            _message = $"The '{notfoundInfo}' was not found.";
        }
        public override string Message => _message;
    }
}