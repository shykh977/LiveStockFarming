using PwDbAssistant.Common;
using PwDbAssistant.DbConnect;

namespace PwDbAssistant.DbConnecter
{
    public class ConnectionFactory :IConnection
    {
        public string ConnectionString
        {
            get
            {
                return APIConfig.Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            }
        }
    }
}
