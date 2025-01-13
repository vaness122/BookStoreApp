using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BookStoreApp.Helpers
{
    public static class SessionHelper
    {
        // Serialize an object and store it in the session
        public static void SetObjectAsJson(ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Retrieve a deserialized object from the session
        public static T GetObjectFromJson<T>(ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
