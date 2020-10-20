namespace AirAstana.Flights.Core.Models
{
    public abstract class ResponseMessage
    {
        public bool Success { get; }
        public string Message { get; }

        protected ResponseMessage(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }

        public bool IsFailure() => !Success;
    }
}
