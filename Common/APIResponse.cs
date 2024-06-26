namespace PwDbAssistant.Common
{
    public class APIResponse
    {
       // public int StatusCode { get; set; } = APIResponseCodes.STATUSCODEOK;
        public string StatusMessage { get; set; }

        public object Response { get; set; }
        public APIResponse()
        {

        }
    }
}
