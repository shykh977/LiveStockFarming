namespace PwDbAssistant.DataAccessLayer
{
    public class ApiMiddleware
    {
        private readonly RequestDelegate _next;
        private
        const string DbUsername = "DbUsername";
        const string DbPass = "DbPass";
        public ApiMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var DbUname = context.Request.Headers.TryGetValue(DbUsername, out var extractedDbUserName);
            var DbPAssword = context.Request.Headers.TryGetValue(DbPass, out var extractedDbPass);

            if(DbUname.ToString() == "Pw@BTG@303" && DbPAssword.ToString() == "BTG@303Pw")
            {
                context.Response.StatusCode = 900;

                await context.Response.WriteAsync("Access Denied");
                return;
            }
            
            var remoteIpAddress = context.Response.HttpContext.Connection.RemoteIpAddress;

            if (!context.Request.Headers.TryGetValue(DbUsername, out
                    var extractedApiKey))
            {
                context.Response.StatusCode = 808;
               
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }
            
                if (DbUname.ToString() == "Pw@BTG@303" && DbPAssword.ToString() == "BTG@303Pw")
                {
                    context.Response.StatusCode = 900;

                    await context.Response.WriteAsync("Access Denied");
                    return;
                }
            
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(DbUsername);
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 808;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }
            await _next(context);
        }
    }
}
