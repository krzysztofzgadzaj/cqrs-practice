namespace FullCqrsApp.Core.Exception.Exceptions
{
    public abstract class NotFoundException : ApplicationException
    {
        protected NotFoundException(string message)
            : base("Not Found", message)
        {
        }
    }
}
