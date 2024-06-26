namespace PwDbAssistant.Common
{
    public static class Commons
    {


       public  const string ServerUrl = "http://192.168.18.14:707/UploadedReels/";
        // public  const string ServerUrl = "https://localhost:7247/wwwroot/UploadedReels/";

        public static readonly string BaseUrl = APIConfig.Configuration?.GetSection("BaseUrl")["Url"];
        public static readonly string WebUrl = APIConfig.Configuration?.GetSection("WebUrl")["Url"];


        
    }
}
