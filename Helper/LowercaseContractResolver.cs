using Newtonsoft.Json.Serialization;

namespace PwDbAssistant.Helper
{
    public class LowercaseContractResolver : DefaultContractResolver
    {

        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName;//.ToLower();
        }

    }
}
