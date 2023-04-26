using System.Text.Json;

namespace BaiThucTap.Controllers
{

        public static class SessionExtensions
        {
            public static T GetObjectFromJson<T>(this ISession session, string key)
            {
                string data = session.GetString(key);
                if (data == null)
                {
                    return default(T);
                }
                return JsonSerializer.Deserialize<T>(data);
            }

            public static void SetObjectAsJson(this ISession session, string key, object value)
            {
                session.SetString(key, JsonSerializer.Serialize(value));
            }
        }
    
}
