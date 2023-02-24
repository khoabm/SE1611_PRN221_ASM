using System.Text.Json;

namespace SE1611_PRN221_ASM.Helper
{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            session.SetString(key, JsonSerializer.Serialize(value, options));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}

