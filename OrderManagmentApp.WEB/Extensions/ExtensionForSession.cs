using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace OrderManagmentApp.WEB.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value) where T:class
        {
            session.SetString(key, JsonSerializer.Serialize<T>(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}