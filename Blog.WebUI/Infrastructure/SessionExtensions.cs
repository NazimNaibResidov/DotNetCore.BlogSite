

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Blog.WebUI.Infrastructure
{
    public static class SessionExtensions
    {
       public static void Set(this ISession session,string key,object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T Get<T>(this ISession session,string key)
        {
            var data = session.GetString(key);
            return data == null ? default(T) : JsonConvert.DeserializeObject<T>(data);
        }
    }
}
